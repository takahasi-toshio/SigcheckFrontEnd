using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;

namespace SigcheckFrontEnd
{
    partial class SigcheckFrontEndMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected void FileListViewDragEnter(object s, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        protected void FileListViewDragDrop(object s, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (string path in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    RunSigcheck(path);
                }
            }
        }

        protected void RunSigcheck(string targetPath)
        {
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string[] paths = { dir, "sigcheck.exe" };
            string sigcheckPath = Path.Combine(paths);

            string output = Path.GetTempFileName();

            using (Process process = new Process())
            {
                process.StartInfo.FileName = sigcheckPath;
                process.StartInfo.Arguments = "-c -s -w \"" + output + "\" \"" + targetPath + "\"";
                if (process.Start())
                {
                    process.WaitForExit();
                    using (TextFieldParser parser = new TextFieldParser(output))
                    {
                        parser.SetDelimiters(",");
                        bool firstLine = true;
                        while (!parser.EndOfData)
                        {
                            string[] values = parser.ReadFields();
                            if (firstLine)
                            {
                                firstLine = false;
                            }
                            else
                            {
                                string path = values[0];
                                string verified = values[1];
                                string date = values[2];
                                ListViewItem item = new ListViewItem(path);
                                item.SubItems.Add(verified);
                                if (verified == "Signed")
                                {
                                    item.SubItems.Add(date);
                                }
                                else
                                {
                                    item.SubItems.Add("");
                                }
                                FileListView.Items.Add(item);
                            }
                        }
                    }
                }
            }

            File.Delete(output);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FilePathHeader = new ColumnHeader();
            FileListView = new ListView();
            DigitalSignHeader = new ColumnHeader();
            DateHeader = new ColumnHeader();
            SuspendLayout();
            // 
            // FilePathHeader
            // 
            FilePathHeader.Text = "ファイルパス";
            FilePathHeader.Width = 200;
            // 
            // FileListView
            // 
            FileListView.AllowDrop = true;
            FileListView.Columns.AddRange(new ColumnHeader[] { FilePathHeader, DigitalSignHeader, DateHeader });
            FileListView.Dock = DockStyle.Fill;
            FileListView.Location = new Point(0, 0);
            FileListView.Name = "FileListView";
            FileListView.Size = new Size(800, 450);
            FileListView.TabIndex = 0;
            FileListView.UseCompatibleStateImageBehavior = false;
            FileListView.View = View.Details;
            FileListView.DragDrop += FileListViewDragDrop;
            FileListView.DragEnter += FileListViewDragEnter;
            // 
            // DigitalSignHeader
            // 
            DigitalSignHeader.Text = "デジタル署名";
            DigitalSignHeader.Width = 100;
            // 
            // DateHeader
            // 
            DateHeader.Text = "タイムスタンプ";
            // 
            // SigcheckFrontEndMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(FileListView);
            Name = "SigcheckFrontEndMainForm";
            Text = "Sigcheck Front End";
            ResumeLayout(false);
        }

        #endregion

        private ListView FileListView;
        private ColumnHeader FilePathHeader;
        private ColumnHeader DigitalSignHeader;
        private ColumnHeader DateHeader;
    }
}
