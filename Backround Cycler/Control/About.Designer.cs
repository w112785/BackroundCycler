namespace Backround_Cycler.Control
{
    partial class About
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
            this.labelProductName = new System.Windows.Forms.Label ();
            this.labelVersion = new System.Windows.Forms.Label ();
            this.labelCopyright = new System.Windows.Forms.Label ();
            this.linkLabelwebsite = new System.Windows.Forms.LinkLabel ();
            this.textBoxDescription = new System.Windows.Forms.TextBox ();
            this.linkLabelEmail = new System.Windows.Forms.LinkLabel ();
            this.labelLastImage = new System.Windows.Forms.Label ();
            this.SuspendLayout ();
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point ( 6, 10 );
            this.labelProductName.Margin = new System.Windows.Forms.Padding ( 6, 0, 3, 0 );
            this.labelProductName.MaximumSize = new System.Drawing.Size ( 0, 17 );
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size ( 75, 13 );
            this.labelProductName.TabIndex = 20;
            this.labelProductName.Text = "Product Name";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point ( 6, 52 );
            this.labelVersion.Margin = new System.Windows.Forms.Padding ( 6, 0, 3, 0 );
            this.labelVersion.MaximumSize = new System.Drawing.Size ( 0, 17 );
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size ( 42, 13 );
            this.labelVersion.TabIndex = 21;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point ( 6, 73 );
            this.labelCopyright.Margin = new System.Windows.Forms.Padding ( 6, 0, 3, 0 );
            this.labelCopyright.MaximumSize = new System.Drawing.Size ( 0, 17 );
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size ( 51, 13 );
            this.labelCopyright.TabIndex = 22;
            this.labelCopyright.Text = "Copyright";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabelwebsite
            // 
            this.linkLabelwebsite.AutoSize = true;
            this.linkLabelwebsite.Location = new System.Drawing.Point ( 6, 94 );
            this.linkLabelwebsite.Name = "linkLabelwebsite";
            this.linkLabelwebsite.Size = new System.Drawing.Size ( 48, 13 );
            this.linkLabelwebsite.TabIndex = 26;
            this.linkLabelwebsite.TabStop = true;
            this.linkLabelwebsite.Text = "WebSite";
            this.linkLabelwebsite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabelwebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler ( this.linkLabelwebsite_LinkClicked );
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.Location = new System.Drawing.Point ( 6, 112 );
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding ( 6, 3, 3, 3 );
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size ( 538, 251 );
            this.textBoxDescription.TabIndex = 27;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "Description";
            // 
            // linkLabelEmail
            // 
            this.linkLabelEmail.AutoSize = true;
            this.linkLabelEmail.Location = new System.Drawing.Point ( 478, 94 );
            this.linkLabelEmail.Name = "linkLabelEmail";
            this.linkLabelEmail.Size = new System.Drawing.Size ( 36, 13 );
            this.linkLabelEmail.TabIndex = 28;
            this.linkLabelEmail.TabStop = true;
            this.linkLabelEmail.Text = "E-Mail";
            this.linkLabelEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler ( this.linkLabelEmail_LinkClicked );
            // 
            // labelLastImage
            // 
            this.labelLastImage.AutoSize = true;
            this.labelLastImage.Location = new System.Drawing.Point ( 5, 31 );
            this.labelLastImage.Margin = new System.Windows.Forms.Padding ( 6, 0, 3, 0 );
            this.labelLastImage.MaximumSize = new System.Drawing.Size ( 0, 17 );
            this.labelLastImage.Name = "labelLastImage";
            this.labelLastImage.Size = new System.Drawing.Size ( 101, 13 );
            this.labelLastImage.TabIndex = 29;
            this.labelLastImage.Text = "Last Image Shown: ";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add ( this.labelLastImage );
            this.Controls.Add ( this.linkLabelEmail );
            this.Controls.Add ( this.textBoxDescription );
            this.Controls.Add ( this.linkLabelwebsite );
            this.Controls.Add ( this.labelCopyright );
            this.Controls.Add ( this.labelVersion );
            this.Controls.Add ( this.labelProductName );
            this.Name = "About";
            this.Size = new System.Drawing.Size ( 547, 366 );
            this.VisibleChanged += new System.EventHandler ( this.About_VisibleChanged );
            this.ResumeLayout ( false );
            this.PerformLayout ();

        }

        #endregion

        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.LinkLabel linkLabelwebsite;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.LinkLabel linkLabelEmail;
        private System.Windows.Forms.Label labelLastImage;
    }
}
