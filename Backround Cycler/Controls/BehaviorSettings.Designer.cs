namespace Backround_Cycler.Control
{
    partial class BehaviorSettings
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
            if (disposing && (components != null))
            {
                components.Dispose ();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BehaviorSettings));
            this.lblWidthorHeight = new System.Windows.Forms.Label();
            this.lblImagesSmaller = new System.Windows.Forms.Label();
            this.lblForImages = new System.Windows.Forms.Label();
            this.lblImagesLarger = new System.Windows.Forms.Label();
            this.chkChangeOnStartup = new System.Windows.Forms.CheckBox();
            this.MinutesText = new System.Windows.Forms.NumericUpDown();
            this.changeTimeIntervelcomboBox = new System.Windows.Forms.ComboBox();
            this.RotateCheckbox = new System.Windows.Forms.CheckBox();
            this.ShowDebugInformation = new System.Windows.Forms.CheckBox();
            this.chkShowOnStartup = new System.Windows.Forms.CheckBox();
            this.largerImagesComboBox = new System.Windows.Forms.ComboBox();
            this.chkAutostartCheckbox = new System.Windows.Forms.CheckBox();
            this.smallestImagesSize = new System.Windows.Forms.NumericUpDown();
            this.smallestImagesComboBox = new System.Windows.Forms.ComboBox();
            this.smallImagesComboBox = new System.Windows.Forms.ComboBox();
            this.chkSubFolders = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MinutesText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallestImagesSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWidthorHeight
            // 
            resources.ApplyResources(this.lblWidthorHeight, "lblWidthorHeight");
            this.lblWidthorHeight.Name = "lblWidthorHeight";
            // 
            // lblImagesSmaller
            // 
            resources.ApplyResources(this.lblImagesSmaller, "lblImagesSmaller");
            this.lblImagesSmaller.Name = "lblImagesSmaller";
            // 
            // lblForImages
            // 
            resources.ApplyResources(this.lblForImages, "lblForImages");
            this.lblForImages.Name = "lblForImages";
            // 
            // lblImagesLarger
            // 
            resources.ApplyResources(this.lblImagesLarger, "lblImagesLarger");
            this.lblImagesLarger.Name = "lblImagesLarger";
            // 
            // chkChangeOnStartup
            // 
            resources.ApplyResources(this.chkChangeOnStartup, "chkChangeOnStartup");
            this.chkChangeOnStartup.Checked = global::Backround_Cycler.Properties.Settings.Default.ChangeOnStartup;
            this.chkChangeOnStartup.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Backround_Cycler.Properties.Settings.Default, "ChangeOnStartup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkChangeOnStartup.Name = "chkChangeOnStartup";
            this.chkChangeOnStartup.UseVisualStyleBackColor = true;
            // 
            // MinutesText
            // 
            this.MinutesText.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Backround_Cycler.Properties.Settings.Default, "change_time", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.MinutesText, "MinutesText");
            this.MinutesText.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.MinutesText.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinutesText.Name = "MinutesText";
            this.MinutesText.Value = global::Backround_Cycler.Properties.Settings.Default.change_time;
            this.MinutesText.ValueChanged += new System.EventHandler(this.minutestext_ValueChanged);
            // 
            // changeTimeIntervelcomboBox
            // 
            this.changeTimeIntervelcomboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Backround_Cycler.Properties.Settings.Default, "TimeIntervelLevel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.changeTimeIntervelcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.changeTimeIntervelcomboBox.FormattingEnabled = true;
            resources.ApplyResources(this.changeTimeIntervelcomboBox, "changeTimeIntervelcomboBox");
            this.changeTimeIntervelcomboBox.Name = "changeTimeIntervelcomboBox";
            this.changeTimeIntervelcomboBox.Text = global::Backround_Cycler.Properties.Settings.Default.TimeIntervelLevel;
            this.changeTimeIntervelcomboBox.SelectedIndexChanged += new System.EventHandler(this.minutestext_ValueChanged);
            // 
            // RotateCheckbox
            // 
            resources.ApplyResources(this.RotateCheckbox, "RotateCheckbox");
            this.RotateCheckbox.Checked = global::Backround_Cycler.Properties.Settings.Default.autochange;
            this.RotateCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RotateCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Backround_Cycler.Properties.Settings.Default, "autochange", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RotateCheckbox.Name = "RotateCheckbox";
            this.RotateCheckbox.UseVisualStyleBackColor = true;
            this.RotateCheckbox.CheckedChanged += new System.EventHandler(this.RotateCheckbox_CheckedChanged);
            // 
            // ShowDebugInformation
            // 
            this.ShowDebugInformation.AllowDrop = true;
            resources.ApplyResources(this.ShowDebugInformation, "ShowDebugInformation");
            this.ShowDebugInformation.Checked = global::Backround_Cycler.Properties.Settings.Default.ShowAdvancedOptions;
            this.ShowDebugInformation.Cursor = System.Windows.Forms.Cursors.Default;
            this.ShowDebugInformation.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Backround_Cycler.Properties.Settings.Default, "ShowAdvancedOptions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ShowDebugInformation.Name = "ShowDebugInformation";
            this.ShowDebugInformation.UseVisualStyleBackColor = true;
            this.ShowDebugInformation.CheckedChanged += new System.EventHandler(this.ShowAdvancedOptions_CheckedChanged);
            // 
            // chkShowOnStartup
            // 
            resources.ApplyResources(this.chkShowOnStartup, "chkShowOnStartup");
            this.chkShowOnStartup.Checked = global::Backround_Cycler.Properties.Settings.Default.ShowDialogOnStartup;
            this.chkShowOnStartup.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Backround_Cycler.Properties.Settings.Default, "ShowDialogOnStartup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkShowOnStartup.Name = "chkShowOnStartup";
            this.chkShowOnStartup.UseVisualStyleBackColor = true;
            // 
            // largerImagesComboBox
            // 
            this.largerImagesComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Backround_Cycler.Properties.Settings.Default, "LargeImageBehavior", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.largerImagesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.largerImagesComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.largerImagesComboBox, "largerImagesComboBox");
            this.largerImagesComboBox.Name = "largerImagesComboBox";
            this.largerImagesComboBox.Text = global::Backround_Cycler.Properties.Settings.Default.LargeImageBehavior;
            // 
            // chkAutostartCheckbox
            // 
            resources.ApplyResources(this.chkAutostartCheckbox, "chkAutostartCheckbox");
            this.chkAutostartCheckbox.Checked = global::Backround_Cycler.Properties.Settings.Default.AutoStart;
            this.chkAutostartCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Backround_Cycler.Properties.Settings.Default, "AutoStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkAutostartCheckbox.Name = "chkAutostartCheckbox";
            this.chkAutostartCheckbox.UseVisualStyleBackColor = true;
            this.chkAutostartCheckbox.CheckedChanged += new System.EventHandler(this.autostartCheckbox_CheckedChanged);
            // 
            // smallestImagesSize
            // 
            this.smallestImagesSize.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Backround_Cycler.Properties.Settings.Default, "SmallestImageSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.smallestImagesSize, "smallestImagesSize");
            this.smallestImagesSize.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.smallestImagesSize.Name = "smallestImagesSize";
            this.smallestImagesSize.Value = global::Backround_Cycler.Properties.Settings.Default.SmallestImageSize;
            // 
            // smallestImagesComboBox
            // 
            this.smallestImagesComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Backround_Cycler.Properties.Settings.Default, "SmallestImageBehavior", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.smallestImagesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.smallestImagesComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.smallestImagesComboBox, "smallestImagesComboBox");
            this.smallestImagesComboBox.Name = "smallestImagesComboBox";
            this.smallestImagesComboBox.Text = global::Backround_Cycler.Properties.Settings.Default.SmallestImageBehavior;
            // 
            // smallImagesComboBox
            // 
            this.smallImagesComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Backround_Cycler.Properties.Settings.Default, "SmallImageBehavior", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.smallImagesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.smallImagesComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.smallImagesComboBox, "smallImagesComboBox");
            this.smallImagesComboBox.Name = "smallImagesComboBox";
            this.smallImagesComboBox.Text = global::Backround_Cycler.Properties.Settings.Default.SmallImageBehavior;
            // 
            // chkSubFolders
            // 
            resources.ApplyResources(this.chkSubFolders, "chkSubFolders");
            this.chkSubFolders.Checked = global::Backround_Cycler.Properties.Settings.Default.SubFolders;
            this.chkSubFolders.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Backround_Cycler.Properties.Settings.Default, "SubFolders", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkSubFolders.Name = "chkSubFolders";
            this.chkSubFolders.UseVisualStyleBackColor = true;
            // 
            // BehaviorSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkSubFolders);
            this.Controls.Add(this.chkChangeOnStartup);
            this.Controls.Add(this.MinutesText);
            this.Controls.Add(this.changeTimeIntervelcomboBox);
            this.Controls.Add(this.RotateCheckbox);
            this.Controls.Add(this.ShowDebugInformation);
            this.Controls.Add(this.chkShowOnStartup);
            this.Controls.Add(this.largerImagesComboBox);
            this.Controls.Add(this.chkAutostartCheckbox);
            this.Controls.Add(this.smallestImagesSize);
            this.Controls.Add(this.lblWidthorHeight);
            this.Controls.Add(this.smallestImagesComboBox);
            this.Controls.Add(this.smallImagesComboBox);
            this.Controls.Add(this.lblImagesSmaller);
            this.Controls.Add(this.lblImagesLarger);
            this.Controls.Add(this.lblForImages);
            this.Name = "BehaviorSettings";
            this.Load += new System.EventHandler(this.BehaviorSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MinutesText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallestImagesSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown MinutesText;
        private System.Windows.Forms.ComboBox largerImagesComboBox;
        private System.Windows.Forms.NumericUpDown smallestImagesSize;
        private System.Windows.Forms.Label lblWidthorHeight;
        private System.Windows.Forms.CheckBox RotateCheckbox;
        private System.Windows.Forms.Label lblImagesSmaller;
        private System.Windows.Forms.Label lblForImages;
        private System.Windows.Forms.Label lblImagesLarger;
        private System.Windows.Forms.ComboBox smallImagesComboBox;
        private System.Windows.Forms.ComboBox smallestImagesComboBox;
        private System.Windows.Forms.CheckBox chkAutostartCheckbox;
        private System.Windows.Forms.CheckBox chkShowOnStartup;
        private System.Windows.Forms.CheckBox ShowDebugInformation;
        private System.Windows.Forms.ComboBox changeTimeIntervelcomboBox;
        private System.Windows.Forms.CheckBox chkChangeOnStartup;
        private System.Windows.Forms.CheckBox chkSubFolders;
    }
}
