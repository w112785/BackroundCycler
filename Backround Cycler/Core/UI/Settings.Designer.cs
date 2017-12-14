namespace Backround_Cycler.Core.UI
{
    partial class Setting 
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
            if ( disposing && ( components != null ) )
            {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("About");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Settings");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Pictures Folder");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new Backround_Cycler.Control.ImageList();
            this.about1 = new Backround_Cycler.Control.About();
            this.behaviorSettings1 = new Backround_Cycler.Control.BehaviorSettings();
            this.debug1 = new Backround_Cycler.Control.DEBUG();
            this.appmenuStrip = new System.Windows.Forms.MenuStrip();
            this.cyclebutton = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportABugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutbutton = new System.Windows.Forms.ToolStripMenuItem();
            this.appNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.appContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutBackroundCyclerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changebackroundtimer = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.appmenuStrip.SuspendLayout();
            this.appContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(728, 367);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(728, 391);
            this.toolStripContainer1.TabIndex = 6;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.appmenuStrip);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.imageList1);
            this.splitContainer1.Panel2.Controls.Add(this.about1);
            this.splitContainer1.Panel2.Controls.Add(this.behaviorSettings1);
            this.splitContainer1.Panel2.Controls.Add(this.debug1);
            this.splitContainer1.Size = new System.Drawing.Size(728, 367);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "About";
            treeNode1.Text = "About";
            treeNode2.Name = "Behavior";
            treeNode2.Text = "Settings";
            treeNode3.Name = "Pictures";
            treeNode3.Text = "Pictures Folder";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeView1.Size = new System.Drawing.Size(175, 367);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageList1.Location = new System.Drawing.Point(0, 0);
            this.imageList1.Name = "imageList1";
            this.imageList1.Size = new System.Drawing.Size(547, 366);
            this.imageList1.TabIndex = 0;
            // 
            // about1
            // 
            this.about1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.about1.Location = new System.Drawing.Point(0, 0);
            this.about1.Name = "about1";
            this.about1.Size = new System.Drawing.Size(547, 366);
            this.about1.TabIndex = 1;
            // 
            // behaviorSettings1
            // 
            this.behaviorSettings1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.behaviorSettings1.Location = new System.Drawing.Point(0, 0);
            this.behaviorSettings1.Name = "behaviorSettings1";
            this.behaviorSettings1.Size = new System.Drawing.Size(547, 366);
            this.behaviorSettings1.TabIndex = 0;
            this.behaviorSettings1.MinutesChanged += new System.EventHandler<Backround_Cycler.EventArguments.DecimalChangedEventArgs>(this.behaviorSettings1_MinutesChanged);
            this.behaviorSettings1.RotateCheckboxChanged += new System.EventHandler<Backround_Cycler.EventArguments.BoolChangedEventArgs>(this.behaviorSettings1_RotateCheckboxChanged);
            this.behaviorSettings1.AdvancedOptionsChecked += new System.EventHandler<Backround_Cycler.EventArguments.BoolChangedEventArgs>(this.behaviorSettings1_AdvancedOptionsChecked);
            // 
            // debug1
            // 
            this.debug1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.debug1.Location = new System.Drawing.Point(0, 0);
            this.debug1.Name = "debug1";
            this.debug1.Size = new System.Drawing.Size(547, 366);
            this.debug1.TabIndex = 2;
            // 
            // appmenuStrip
            // 
            this.appmenuStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.appmenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.appmenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.appmenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cyclebutton,
            this.optionsToolStripMenuItem,
            this.aboutbutton});
            this.appmenuStrip.Location = new System.Drawing.Point(0, 0);
            this.appmenuStrip.Name = "appmenuStrip";
            this.appmenuStrip.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.appmenuStrip.Size = new System.Drawing.Size(728, 24);
            this.appmenuStrip.TabIndex = 5;
            this.appmenuStrip.Text = "menuStrip1";
            // 
            // cyclebutton
            // 
            this.cyclebutton.Image = global::Backround_Cycler.Properties.Resources.view_refresh;
            this.cyclebutton.Name = "cyclebutton";
            this.cyclebutton.Size = new System.Drawing.Size(144, 20);
            this.cyclebutton.Text = "Change &BackGround";
            this.cyclebutton.Click += new System.EventHandler(this.changeNowToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.donateToolStripMenuItem,
            this.reportABugToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeWindowToolStripMenuItem,
            this.quitProgramToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Image = global::Backround_Cycler.Properties.Resources.money;
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // reportABugToolStripMenuItem
            // 
            this.reportABugToolStripMenuItem.Image = global::Backround_Cycler.Properties.Resources.bug;
            this.reportABugToolStripMenuItem.Name = "reportABugToolStripMenuItem";
            this.reportABugToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.reportABugToolStripMenuItem.Text = "&Report a Bug";
            this.reportABugToolStripMenuItem.Click += new System.EventHandler(this.reportABugToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(147, 6);
            // 
            // closeWindowToolStripMenuItem
            // 
            this.closeWindowToolStripMenuItem.Name = "closeWindowToolStripMenuItem";
            this.closeWindowToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.closeWindowToolStripMenuItem.Text = "&Close Window";
            this.closeWindowToolStripMenuItem.Click += new System.EventHandler(this.showSettingsToolStripMenuItem_Click);
            // 
            // quitProgramToolStripMenuItem
            // 
            this.quitProgramToolStripMenuItem.Name = "quitProgramToolStripMenuItem";
            this.quitProgramToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.quitProgramToolStripMenuItem.Text = "&Quit Program";
            this.quitProgramToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // aboutbutton
            // 
            this.aboutbutton.Name = "aboutbutton";
            this.aboutbutton.Size = new System.Drawing.Size(52, 20);
            this.aboutbutton.Text = "&About";
            this.aboutbutton.Click += new System.EventHandler(this.aboutBackroundCyclerToolStripMenuItem_Click);
            // 
            // appNotifyIcon
            // 
            this.appNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.appNotifyIcon.BalloonTipTitle = "Backround Cycler";
            this.appNotifyIcon.ContextMenuStrip = this.appContextMenuStrip;
            this.appNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("appNotifyIcon.Icon")));
            this.appNotifyIcon.Text = "Backround Cycler";
            this.appNotifyIcon.BalloonTipClicked += new System.EventHandler(this.appNotifyIcon_BalloonTipClicked);
            this.appNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.appNotifyIcon_MouseClick);
            this.appNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.appNotifyIcon_MouseDoubleClick);
            // 
            // appContextMenuStrip
            // 
            this.appContextMenuStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.appContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeNowToolStripMenuItem,
            this.aboutBackroundCyclerToolStripMenuItem,
            this.showSettingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.editSettingsToolStripMenuItem,
            this.toolStripSeparator3,
            this.quitToolStripMenuItem});
            this.appContextMenuStrip.Name = "appContextMenuStrip";
            this.appContextMenuStrip.Size = new System.Drawing.Size(211, 126);
            this.appContextMenuStrip.DoubleClick += new System.EventHandler(this.showSettingsToolStripMenuItem_Click);
            // 
            // changeNowToolStripMenuItem
            // 
            this.changeNowToolStripMenuItem.Image = global::Backround_Cycler.Properties.Resources.view_refresh;
            this.changeNowToolStripMenuItem.Name = "changeNowToolStripMenuItem";
            this.changeNowToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.changeNowToolStripMenuItem.Text = "Change Background Now";
            this.changeNowToolStripMenuItem.Click += new System.EventHandler(this.changeNowToolStripMenuItem_Click);
            // 
            // aboutBackroundCyclerToolStripMenuItem
            // 
            this.aboutBackroundCyclerToolStripMenuItem.Name = "aboutBackroundCyclerToolStripMenuItem";
            this.aboutBackroundCyclerToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.aboutBackroundCyclerToolStripMenuItem.Text = "About Backround cycler";
            this.aboutBackroundCyclerToolStripMenuItem.Click += new System.EventHandler(this.aboutBackroundCyclerToolStripMenuItem_Click);
            // 
            // showSettingsToolStripMenuItem
            // 
            this.showSettingsToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.showSettingsToolStripMenuItem.Name = "showSettingsToolStripMenuItem";
            this.showSettingsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.showSettingsToolStripMenuItem.Text = "Show Settings";
            this.showSettingsToolStripMenuItem.Click += new System.EventHandler(this.showSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // editSettingsToolStripMenuItem
            // 
            this.editSettingsToolStripMenuItem.Name = "editSettingsToolStripMenuItem";
            this.editSettingsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.editSettingsToolStripMenuItem.Text = "Edit Settings";
            this.editSettingsToolStripMenuItem.Click += new System.EventHandler(this.editSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(207, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // changebackroundtimer
            // 
            this.changebackroundtimer.Enabled = true;
            this.changebackroundtimer.Tick += new System.EventHandler(this.changebackroundtimer_Tick);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(728, 391);
            this.ContextMenuStrip = this.appContextMenuStrip;
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.appmenuStrip;
            this.Name = "Setting";
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Setting_FormClosing);
            this.Load += new System.EventHandler(this.Setting_Load);
            this.VisibleChanged += new System.EventHandler(this.Setting_VisibleChanged);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.appmenuStrip.ResumeLayout(false);
            this.appmenuStrip.PerformLayout();
            this.appContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip appContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem changeNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutBackroundCyclerToolStripMenuItem;
        protected System.Windows.Forms.NotifyIcon appNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem cyclebutton;
        private System.Windows.Forms.ToolStripMenuItem aboutbutton;
        private System.Windows.Forms.MenuStrip appmenuStrip;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private Backround_Cycler.Control.About about1;
        private Backround_Cycler.Control.DEBUG debug1;
        internal System.Windows.Forms.Timer changebackroundtimer;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportABugToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        internal Backround_Cycler.Control.ImageList imageList1;
        internal Backround_Cycler.Control.BehaviorSettings behaviorSettings1;
        private System.Windows.Forms.ToolStripMenuItem editSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

