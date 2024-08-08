using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;

namespace SigcheckFrontEnd
{
    public partial class SigcheckFrontEndMainForm : Form
    {
        public SigcheckFrontEndMainForm()
        {
            InitializeComponent();
            FilterTypeComboBox.SelectedIndex = 0;
        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            FileListView.Items.Clear();
            FullFileListViewItems.Clear();
            UpdateItemCount();
        }

        private void FilterTimer_Tick(object sender, EventArgs e)
        {
            FilterTimer.Stop();
            DoFilter();
        }

        protected void FileListViewDragEnter(object s, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        protected async void FileListViewDragDrop(object s, DragEventArgs e)
        {
            var paths = e.Data?.GetData(DataFormats.FileDrop);
            if (paths != null)
            {
                FileListView.AllowDrop = false;
                ProgressBar.Visible = true;
                foreach (string path in (string[])paths)
                {
                    List<ListViewItem> items = await RunSigcheck(path);
                    foreach (var item in items)
                    {
                        FullFileListViewItems.Add(item);
                        if (IsMatch(item))
                        {
                            FileListView.Items.Add(item);
                        }
                    }
                }
                ProgressBar.Visible = false;
                FileListView.AllowDrop = true;
                FileListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                UpdateItemCount();
            }
        }

        protected void FilterTextBoxTextChanged(object s, EventArgs e)
        {
            FilterTimer.Stop();
            FilterTimer.Start();
        }

        protected void DoFilter()
        {
            FileListView.Items.Clear();

            foreach (var item in FullFileListViewItems)
            {
                if (IsMatch(item))
                {
                    FileListView.Items.Add(item);
                }
            }

            UpdateItemCount();
        }

        protected bool IsMatch(ListViewItem item)
        {
            if (ShowDigitalSignTargetOnlyButton.Checked)
            {
                string[] extensions = { ".appx", ".msix", ".appxbundle", ".msixbundle", ".cab", ".dll", ".exe", ".js", ".vbs", ".wsf", "msi", ".msp", ".mst", ".ocx", ".ps1", ".stl", ".sys" };
                bool bFound = false;
                foreach (var extension in extensions)
                {
                    if (item.Text.EndsWith(extension, StringComparison.OrdinalIgnoreCase))
                    {
                        bFound = true;
                        break;
                    }
                }
                if (!bFound)
                {
                    return false;
                }
            }

            string filter = FilterTextBox.Text;
            if (filter.Length == 0)
            {
                return true;
            }

            switch (FilterTypeComboBox.SelectedIndex)
            {
                case 1:
                    return item.Text.EndsWith(filter, StringComparison.OrdinalIgnoreCase);
                case 2:
                    return item.Text.StartsWith(filter, StringComparison.OrdinalIgnoreCase);
                default:
                    return item.Text.Contains(filter, StringComparison.OrdinalIgnoreCase);

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

        private void FilterTypeComboBoxChanged(object sender, EventArgs e)
        {
            FilterTimer.Stop();
            FilterTimer.Start();
        }

        private void UpdateItemCount()
        {
            int countAll = FullFileListViewItems.Count;
            int countVisible = FileListView.Items.Count;
            ItemCountLabel.Text = $"({countVisible}/{countAll})";
        }

        private List<ListViewItem> FullFileListViewItems = new List<ListViewItem>();

        private void ShowDigitalSignTargetOnlyButton_CheckedChanged(object sender, EventArgs e)
        {
            FilterTimer.Stop();
            FilterTimer.Start();
        }
    }
}
