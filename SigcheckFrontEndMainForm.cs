using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;

namespace SigcheckFrontEnd
{
    public partial class SigcheckFrontEndMainForm : Form
    {
        public SigcheckFrontEndMainForm()
        {
            InitializeComponent();
        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            FileListView.Items.Clear();
            FullFileListViewItems.Clear();
        }

        private void FilterTimer_Tick(object sender, EventArgs e)
        {
            FilterTimer.Stop();
            DoFilter(FilterTextBox.Text);
        }

        protected void FileListViewDragEnter(object s, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        protected async void FileListViewDragDrop(object s, DragEventArgs e)
        {
            var data = e.Data;
            if (data != null)
            {
                if (data.GetDataPresent(DataFormats.FileDrop))
                {
                    var paths = data.GetData(DataFormats.FileDrop);
                    if (paths != null)
                    {
                        var filter = FilterTextBox.Text;
                        FileListView.AllowDrop = false;
                        ProgressBar.Visible = true;
                        foreach (string path in (string[])paths)
                        {
                            List<ListViewItem> items = await RunSigcheck(path);
                            foreach (var item in items)
                            {
                                FullFileListViewItems.Add(item);
                                if ((filter.Length == 0) || (item.Text.Contains(filter, StringComparison.OrdinalIgnoreCase)))
                                {
                                    FileListView.Items.Add(item);
                                }
                            }
                        }
                        ProgressBar.Visible = false;
                        FileListView.AllowDrop = true;
                    }
                }
            }
        }

        protected void FilterTextBoxTextChanged(object s, EventArgs e)
        {
            FilterTimer.Stop();
            FilterTimer.Start();
        }

        protected void DoFilter(string filter)
        {
            FileListView.Items.Clear();

            foreach (var item in FullFileListViewItems)
            {
                if ((filter.Length == 0) || (item.Text.Contains(filter, StringComparison.OrdinalIgnoreCase)))
                {
                    FileListView.Items.Add(item);
                }
            }
        }

        protected async Task<List<ListViewItem>> RunSigcheck(string targetPath)
        {
            var ret = new List<ListViewItem>();
            var dir = Path.GetDirectoryName(Application.ExecutablePath);
            if (dir != null)
            {
                string output = Path.GetTempFileName();

                string[] paths = { dir, "sigcheck.exe" };
                string sigcheckPath = Path.Combine(paths);
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = sigcheckPath;
                    process.StartInfo.CreateNoWindow = true;
                    if ((File.GetAttributes(targetPath) & FileAttributes.Directory) != 0)
                    {
                        process.StartInfo.Arguments = "-c -s -a -w \"" + output + "\" \"" + targetPath + "\"";
                    }
                    else
                    {
                        process.StartInfo.Arguments = "-c -a -w \"" + output + "\" \"" + targetPath + "\"";
                    }
                    if (process.Start())
                    {
                        await process.WaitForExitAsync();
                        using (TextFieldParser parser = new TextFieldParser(output))
                        {
                            parser.SetDelimiters(",");
                            bool firstLine = true;
                            while (!parser.EndOfData)
                            {
                                var values = parser.ReadFields();
                                if (values == null)
                                {
                                    break;
                                }

                                if (firstLine)
                                {
                                    firstLine = false;
                                }
                                else if (values != null)
                                {
                                    string path = values[0];
                                    string verified = values[1];
                                    string date = values[2];
                                    string publisher = values[3];
                                    string description = values[5];
                                    string product = values[6];
                                    string productVersion = values[7];
                                    string fileVersion = values[8];
                                    string copyright = values[13];
                                    ListViewItem item = new ListViewItem(path);
                                    item.SubItems.Add(verified);
                                    if (verified == "Signed")
                                    {
                                        item.ImageIndex = 0;
                                        item.SubItems.Add(date);
                                        item.SubItems.Add(publisher);
                                    }
                                    else
                                    {
                                        item.ImageIndex = 1;
                                        item.SubItems.Add("");
                                        item.SubItems.Add("");
                                    }
                                    item.SubItems.Add(description);
                                    item.SubItems.Add(fileVersion);
                                    item.SubItems.Add(product);
                                    item.SubItems.Add(productVersion);
                                    item.SubItems.Add(copyright);

                                    ret.Add(item);
                                }
                            }
                        }
                    }
                }

                File.Delete(output);
            }

            return ret;
        }

        private List<ListViewItem> FullFileListViewItems = new List<ListViewItem>();
    }
}
