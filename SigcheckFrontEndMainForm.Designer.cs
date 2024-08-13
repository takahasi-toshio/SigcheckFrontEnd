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
            FileListViewMenu = new ContextMenuStrip(components);
            FileListViewCopyMenuItem = new ToolStripMenuItem();
            FileListViewSelectAllMenuItem = new ToolStripMenuItem();
            FileListViewSmallImageList = new ImageList(components);
            ToolBar = new ToolStrip();
            ClearAllButton = new ToolStripButton();
            FilterTextBox = new ToolStripTextBox();
            FilterTypeComboBox = new ToolStripComboBox();
            ShowDigitalSignTargetOnlyButton = new ToolStripButton();
            FilterTimer = new System.Windows.Forms.Timer(components);
            StatusBar = new StatusStrip();
            ItemCountLabel = new ToolStripStatusLabel();
            ProgressBar = new ToolStripProgressBar();
            FileListViewMenu.SuspendLayout();
            ToolBar.SuspendLayout();
            StatusBar.SuspendLayout();
            SuspendLayout();
            // 
            // FilePathHeader
            // 
            resources.ApplyResources(FilePathHeader, "FilePathHeader");
            // 
            // FileListView
            // 
            FileListView.AllowDrop = true;
            resources.ApplyResources(FileListView, "FileListView");
            FileListView.Columns.AddRange(new ColumnHeader[] { FilePathHeader, DigitalSignHeader, DateHeader, PublisherHeader, DescriptionHeader, FileVersionHeader, ProductHeader, ProductVersionHeader, CopyrightHeader });
            FileListView.ContextMenuStrip = FileListViewMenu;
            FileListView.FullRowSelect = true;
            FileListView.Name = "FileListView";
            FileListView.SmallImageList = FileListViewSmallImageList;
            FileListView.UseCompatibleStateImageBehavior = false;
            FileListView.View = View.Details;
            FileListView.DragDrop += FileListViewDragDrop;
            FileListView.DragEnter += FileListViewDragEnter;
            // 
            // DigitalSignHeader
            // 
            resources.ApplyResources(DigitalSignHeader, "DigitalSignHeader");
            // 
            // DateHeader
            // 
            resources.ApplyResources(DateHeader, "DateHeader");
            // 
            // PublisherHeader
            // 
            resources.ApplyResources(PublisherHeader, "PublisherHeader");
            // 
            // DescriptionHeader
            // 
            resources.ApplyResources(DescriptionHeader, "DescriptionHeader");
            // 
            // FileVersionHeader
            // 
            resources.ApplyResources(FileVersionHeader, "FileVersionHeader");
            // 
            // ProductHeader
            // 
            resources.ApplyResources(ProductHeader, "ProductHeader");
            // 
            // ProductVersionHeader
            // 
            resources.ApplyResources(ProductVersionHeader, "ProductVersionHeader");
            // 
            // CopyrightHeader
            // 
            resources.ApplyResources(CopyrightHeader, "CopyrightHeader");
            // 
            // FileListViewMenu
            // 
            FileListViewMenu.Items.AddRange(new ToolStripItem[] { FileListViewCopyMenuItem, FileListViewSelectAllMenuItem });
            FileListViewMenu.Name = "FileListViewMenu";
            resources.ApplyResources(FileListViewMenu, "FileListViewMenu");
            // 
            // FileListViewCopyMenuItem
            // 
            FileListViewCopyMenuItem.Name = "FileListViewCopyMenuItem";
            resources.ApplyResources(FileListViewCopyMenuItem, "FileListViewCopyMenuItem");
            FileListViewCopyMenuItem.Click += FileListViewCopyMenuItem_Click;
            // 
            // FileListViewSelectAllMenuItem
            // 
            FileListViewSelectAllMenuItem.Name = "FileListViewSelectAllMenuItem";
            resources.ApplyResources(FileListViewSelectAllMenuItem, "FileListViewSelectAllMenuItem");
            FileListViewSelectAllMenuItem.Click += FileListViewSelectAllMenuItem_Click;
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
            ToolBar.Items.AddRange(new ToolStripItem[] { ClearAllButton, FilterTextBox, FilterTypeComboBox, ShowDigitalSignTargetOnlyButton });
            resources.ApplyResources(ToolBar, "ToolBar");
            ToolBar.Name = "ToolBar";
            // 
            // ClearAllButton
            // 
            ClearAllButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(ClearAllButton, "ClearAllButton");
            ClearAllButton.Name = "ClearAllButton";
            ClearAllButton.Click += ClearAllButton_Click;
            // 
            // FilterTextBox
            // 
            FilterTextBox.Name = "FilterTextBox";
            resources.ApplyResources(FilterTextBox, "FilterTextBox");
            FilterTextBox.TextChanged += FilterTextBoxTextChanged;
            // 
            // FilterTypeComboBox
            // 
            FilterTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            FilterTypeComboBox.Items.AddRange(new object[] { resources.GetString("FilterTypeComboBox.Items"), resources.GetString("FilterTypeComboBox.Items1"), resources.GetString("FilterTypeComboBox.Items2") });
            FilterTypeComboBox.Name = "FilterTypeComboBox";
            resources.ApplyResources(FilterTypeComboBox, "FilterTypeComboBox");
            FilterTypeComboBox.SelectedIndexChanged += FilterTypeComboBoxChanged;
            // 
            // ShowDigitalSignTargetOnlyButton
            // 
            ShowDigitalSignTargetOnlyButton.CheckOnClick = true;
            ShowDigitalSignTargetOnlyButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(ShowDigitalSignTargetOnlyButton, "ShowDigitalSignTargetOnlyButton");
            ShowDigitalSignTargetOnlyButton.Name = "ShowDigitalSignTargetOnlyButton";
            ShowDigitalSignTargetOnlyButton.CheckedChanged += ShowDigitalSignTargetOnlyButton_CheckedChanged;
            // 
            // FilterTimer
            // 
            FilterTimer.Interval = 1000;
            FilterTimer.Tick += FilterTimer_Tick;
            // 
            // StatusBar
            // 
            StatusBar.Items.AddRange(new ToolStripItem[] { ItemCountLabel, ProgressBar });
            resources.ApplyResources(StatusBar, "StatusBar");
            StatusBar.Name = "StatusBar";
            // 
            // ItemCountLabel
            // 
            ItemCountLabel.Name = "ItemCountLabel";
            resources.ApplyResources(ItemCountLabel, "ItemCountLabel");
            // 
            // ProgressBar
            // 
            ProgressBar.Name = "ProgressBar";
            resources.ApplyResources(ProgressBar, "ProgressBar");
            ProgressBar.Style = ProgressBarStyle.Marquee;
            // 
            // SigcheckFrontEndMainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(StatusBar);
            Controls.Add(ToolBar);
            Controls.Add(FileListView);
            Name = "SigcheckFrontEndMainForm";
            FormClosing += SigcheckFrontEndMainForm_FormClosing;
            Load += SigcheckFrontEndMainForm_Load;
            FileListViewMenu.ResumeLayout(false);
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
        private ToolStripButton ShowDigitalSignTargetOnlyButton;
        private ContextMenuStrip FileListViewMenu;
        private ToolStripMenuItem FileListViewCopyMenuItem;
        private ToolStripMenuItem FileListViewSelectAllMenuItem;
    }
}
