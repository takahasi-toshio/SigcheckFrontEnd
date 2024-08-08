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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SigcheckFrontEndMainForm));
            FilePathHeader = new ColumnHeader();
            FileListView = new ListView();
            DigitalSignHeader = new ColumnHeader();
            DateHeader = new ColumnHeader();
            PublisherHeader = new ColumnHeader();
            DescriptionHeader = new ColumnHeader();
            FileVersionHeader = new ColumnHeader();
            ProductHeader = new ColumnHeader();
            ProductVersionHeader = new ColumnHeader();
            CopyrightHeader = new ColumnHeader();
            FileListViewSmallImageList = new ImageList(components);
            ToolBar = new ToolStrip();
            ClearAllButton = new ToolStripButton();
            FilterTextBox = new ToolStripTextBox();
            FilterTypeComboBox = new ToolStripComboBox();
            FilterTimer = new System.Windows.Forms.Timer(components);
            StatusBar = new StatusStrip();
            ItemCountLabel = new ToolStripStatusLabel();
            ProgressBar = new ToolStripProgressBar();
            ToolBar.SuspendLayout();
            StatusBar.SuspendLayout();
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
            FileListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FileListView.Columns.AddRange(new ColumnHeader[] { FilePathHeader, DigitalSignHeader, DateHeader, PublisherHeader, DescriptionHeader, FileVersionHeader, ProductHeader, ProductVersionHeader, CopyrightHeader });
            FileListView.Location = new Point(0, 28);
            FileListView.Margin = new Padding(0);
            FileListView.Name = "FileListView";
            FileListView.Size = new Size(1264, 435);
            FileListView.SmallImageList = FileListViewSmallImageList;
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
            DateHeader.Width = 100;
            // 
            // PublisherHeader
            // 
            PublisherHeader.Text = "署名者名";
            PublisherHeader.Width = 100;
            // 
            // DescriptionHeader
            // 
            DescriptionHeader.Text = "ファイルの説明";
            DescriptionHeader.Width = 100;
            // 
            // FileVersionHeader
            // 
            FileVersionHeader.DisplayIndex = 6;
            FileVersionHeader.Text = "ファイルバージョン";
            FileVersionHeader.Width = 100;
            // 
            // ProductHeader
            // 
            ProductHeader.DisplayIndex = 5;
            ProductHeader.Text = "製品名";
            // 
            // ProductVersionHeader
            // 
            ProductVersionHeader.Text = "プロダクトバージョン";
            // 
            // CopyrightHeader
            // 
            CopyrightHeader.Text = "著作権";
            // 
            // FileListViewSmallImageList
            // 
            FileListViewSmallImageList.ColorDepth = ColorDepth.Depth32Bit;
            FileListViewSmallImageList.ImageStream = (ImageListStreamer)resources.GetObject("FileListViewSmallImageList.ImageStream");
            FileListViewSmallImageList.TransparentColor = Color.Transparent;
            FileListViewSmallImageList.Images.SetKeyName(0, "チェックボックスアイコン.png");
            FileListViewSmallImageList.Images.SetKeyName(1, "太いバツのアイコン3.png");
            // 
            // ToolBar
            // 
            ToolBar.Items.AddRange(new ToolStripItem[] { ClearAllButton, FilterTextBox, FilterTypeComboBox });
            ToolBar.Location = new Point(0, 0);
            ToolBar.Name = "ToolBar";
            ToolBar.Size = new Size(1264, 25);
            ToolBar.TabIndex = 1;
            ToolBar.Text = "toolStrip1";
            // 
            // ClearAllButton
            // 
            ClearAllButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ClearAllButton.Image = (Image)resources.GetObject("ClearAllButton.Image");
            ClearAllButton.ImageTransparentColor = Color.Magenta;
            ClearAllButton.Name = "ClearAllButton";
            ClearAllButton.Size = new Size(23, 22);
            ClearAllButton.Text = "すべて削除";
            ClearAllButton.ToolTipText = "すべて削除";
            ClearAllButton.Click += ClearAllButton_Click;
            // 
            // FilterTextBox
            // 
            FilterTextBox.Name = "FilterTextBox";
            FilterTextBox.Size = new Size(100, 25);
            FilterTextBox.ToolTipText = "絞り込み";
            FilterTextBox.TextChanged += FilterTextBoxTextChanged;
            // 
            // FilterTypeComboBox
            // 
            FilterTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            FilterTypeComboBox.Items.AddRange(new object[] { "を含む", "で終わる", "から始まる" });
            FilterTypeComboBox.Name = "FilterTypeComboBox";
            FilterTypeComboBox.Size = new Size(121, 25);
            FilterTypeComboBox.SelectedIndexChanged += FilterTypeComboBoxChanged;
            // 
            // FilterTimer
            // 
            FilterTimer.Interval = 1000;
            FilterTimer.Tick += FilterTimer_Tick;
            // 
            // StatusBar
            // 
            StatusBar.Items.AddRange(new ToolStripItem[] { ItemCountLabel, ProgressBar });
            StatusBar.Location = new Point(0, 466);
            StatusBar.Name = "StatusBar";
            StatusBar.Size = new Size(1264, 22);
            StatusBar.TabIndex = 2;
            StatusBar.Text = "statusStrip1";
            // 
            // ItemCountLabel
            // 
            ItemCountLabel.Name = "ItemCountLabel";
            ItemCountLabel.Size = new Size(32, 17);
            ItemCountLabel.Text = "(0/0)";
            // 
            // ProgressBar
            // 
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(100, 16);
            ProgressBar.Style = ProgressBarStyle.Marquee;
            ProgressBar.Visible = false;
            // 
            // SigcheckFrontEndMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 488);
            Controls.Add(StatusBar);
            Controls.Add(ToolBar);
            Controls.Add(FileListView);
            Name = "SigcheckFrontEndMainForm";
            Text = "Sigcheck Front End";
            ToolBar.ResumeLayout(false);
            ToolBar.PerformLayout();
            StatusBar.ResumeLayout(false);
            StatusBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView FileListView;
        private ColumnHeader FilePathHeader;
        private ColumnHeader DigitalSignHeader;
        private ColumnHeader DateHeader;
        private ColumnHeader PublisherHeader;
        private ImageList FileListViewSmallImageList;
        private ColumnHeader DescriptionHeader;
        private ColumnHeader ProductHeader;
        private ColumnHeader FileVersionHeader;
        private ColumnHeader ProductVersionHeader;
        private ColumnHeader CopyrightHeader;
        private ToolStrip ToolBar;
        private ToolStripButton ClearAllButton;
        private ToolStripTextBox FilterTextBox;
        private System.Windows.Forms.Timer FilterTimer;
        private StatusStrip StatusBar;
        private ToolStripProgressBar ProgressBar;
        private ToolStripComboBox FilterTypeComboBox;
        private ToolStripStatusLabel ItemCountLabel;
    }
}
