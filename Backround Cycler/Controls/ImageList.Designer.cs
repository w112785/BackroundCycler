namespace Backround_Cycler.Control
{
    partial class ImageList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose ();
                }

            }
            base.Dispose ( disposing );
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerStepThrough ()]
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container ();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager ( typeof ( ImageList ) );
            this.ltvFiles = new System.Windows.Forms.ListView ();
            this.columnImageName = new System.Windows.Forms.ColumnHeader ();
            this.contextMenuStripFileList = new System.Windows.Forms.ContextMenuStrip ( this.components );
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip ();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem ();
            this.clearListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.loadFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog ();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog ();
            this.chkSubfolders = new System.Windows.Forms.CheckBox ();
            this.contextMenuStripFileList.SuspendLayout ();
            this.menuStrip1.SuspendLayout ();
            this.SuspendLayout ();
            // 
            // ltvFiles
            // 
            this.ltvFiles.Columns.AddRange ( new System.Windows.Forms.ColumnHeader[] {
            this.columnImageName} );
            this.ltvFiles.ContextMenuStrip = this.contextMenuStripFileList;
            resources.ApplyResources ( this.ltvFiles, "ltvFiles" );
            this.ltvFiles.Name = "ltvFiles";
            this.ltvFiles.UseCompatibleStateImageBehavior = false;
            this.ltvFiles.View = System.Windows.Forms.View.Details;
            this.ltvFiles.KeyDown += new System.Windows.Forms.KeyEventHandler ( this.ltvFiles_KeyDown );
            // 
            // columnImageName
            // 
            resources.ApplyResources ( this.columnImageName, "columnImageName" );
            // 
            // contextMenuStripFileList
            // 
            this.contextMenuStripFileList.Items.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem,
            this.saveToolStripMenuItem} );
            this.contextMenuStripFileList.Name = "contextMenuStripFileList";
            resources.ApplyResources ( this.contextMenuStripFileList, "contextMenuStripFileList" );
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources ( this.clearToolStripMenuItem, "clearToolStripMenuItem" );
            this.clearToolStripMenuItem.Click += new System.EventHandler ( this.btnClear_Click );
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            resources.ApplyResources ( this.deleteSelectedToolStripMenuItem, "deleteSelectedToolStripMenuItem" );
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler ( this.deleteSelectedToolStripMenuItem_Click );
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources ( this.saveToolStripMenuItem, "saveToolStripMenuItem" );
            this.saveToolStripMenuItem.Click += new System.EventHandler ( this.btnSave_Click );
            // 
            // menuStrip1
            // 
            this.menuStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.menuStrip1.Items.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.clearListToolStripMenuItem,
            this.loadFileToolStripMenuItem,
            this.loadFolderToolStripMenuItem} );
            resources.ApplyResources ( this.menuStrip1, "menuStrip1" );
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            resources.ApplyResources ( this.saveToolStripMenuItem1, "saveToolStripMenuItem1" );
            this.saveToolStripMenuItem1.Click += new System.EventHandler ( this.btnSave_Click );
            // 
            // clearListToolStripMenuItem
            // 
            this.clearListToolStripMenuItem.Name = "clearListToolStripMenuItem";
            resources.ApplyResources ( this.clearListToolStripMenuItem, "clearListToolStripMenuItem" );
            this.clearListToolStripMenuItem.Click += new System.EventHandler ( this.btnClear_Click );
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            resources.ApplyResources ( this.loadFileToolStripMenuItem, "loadFileToolStripMenuItem" );
            this.loadFileToolStripMenuItem.Click += new System.EventHandler ( this.btnLoadFile_Click );
            // 
            // loadFolderToolStripMenuItem
            // 
            this.loadFolderToolStripMenuItem.Name = "loadFolderToolStripMenuItem";
            resources.ApplyResources ( this.loadFolderToolStripMenuItem, "loadFolderToolStripMenuItem" );
            this.loadFolderToolStripMenuItem.Click += new System.EventHandler ( this.btnLoadFolder_Click );
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources ( this.folderBrowserDialog1, "folderBrowserDialog1" );
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // chkSubfolders
            // 
            resources.ApplyResources ( this.chkSubfolders, "chkSubfolders" );
            this.chkSubfolders.Checked = global::Backround_Cycler.Properties.Settings.Default.SubFolders;
            this.chkSubfolders.DataBindings.Add ( new System.Windows.Forms.Binding ( "Checked", global::Backround_Cycler.Properties.Settings.Default, "SubFolders", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
            this.chkSubfolders.Name = "chkSubfolders";
            this.chkSubfolders.UseVisualStyleBackColor = true;
            // 
            // ImageList
            // 
            resources.ApplyResources ( this, "$this" );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add ( this.chkSubfolders );
            this.Controls.Add ( this.ltvFiles );
            this.Controls.Add ( this.menuStrip1 );
            this.Name = "ImageList";
            this.contextMenuStripFileList.ResumeLayout ( false );
            this.menuStrip1.ResumeLayout ( false );
            this.menuStrip1.PerformLayout ();
            this.ResumeLayout ( false );
            this.PerformLayout ();

        }

        #endregion

        private System.Windows.Forms.ListView ltvFiles;
        private System.Windows.Forms.ColumnHeader columnImageName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFileList;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearListToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkSubfolders;
    }
}
