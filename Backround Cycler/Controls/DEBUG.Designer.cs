namespace Backround_Cycler.Control
{
    partial class DEBUG
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
            this.TimeSet = new System.Windows.Forms.Label ();
            this.DebugText = new System.Windows.Forms.TextBox ();
            this.clearDebugText = new System.Windows.Forms.LinkLabel ();
            this.lblListCount = new System.Windows.Forms.Label ();
            this.SuspendLayout ();
            // 
            // TimeSet
            // 
            this.TimeSet.AutoSize = true;
            this.TimeSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TimeSet.Location = new System.Drawing.Point ( 3, 0 );
            this.TimeSet.Name = "TimeSet";
            this.TimeSet.Size = new System.Drawing.Size ( 37, 15 );
            this.TimeSet.TabIndex = 0;
            this.TimeSet.Text = "label1";
            // 
            // DebugText
            // 
            this.DebugText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DebugText.Location = new System.Drawing.Point ( 0, 18 );
            this.DebugText.Multiline = true;
            this.DebugText.Name = "DebugText";
            this.DebugText.ReadOnly = true;
            this.DebugText.Size = new System.Drawing.Size ( 554, 348 );
            this.DebugText.TabIndex = 1;
            // 
            // clearDebugText
            // 
            this.clearDebugText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearDebugText.AutoSize = true;
            this.clearDebugText.Location = new System.Drawing.Point ( 454, 2 );
            this.clearDebugText.Name = "clearDebugText";
            this.clearDebugText.Size = new System.Drawing.Size ( 90, 13 );
            this.clearDebugText.TabIndex = 2;
            this.clearDebugText.TabStop = true;
            this.clearDebugText.Text = "Clear Debug Text";
            this.clearDebugText.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler ( this.clearDebugText_LinkClicked );
            // 
            // lblListCount
            // 
            this.lblListCount.AutoSize = true;
            this.lblListCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblListCount.Location = new System.Drawing.Point ( 224, 0 );
            this.lblListCount.Name = "lblListCount";
            this.lblListCount.Size = new System.Drawing.Size ( 37, 15 );
            this.lblListCount.TabIndex = 3;
            this.lblListCount.Text = "label1";
            // 
            // DEBUG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add ( this.lblListCount );
            this.Controls.Add ( this.clearDebugText );
            this.Controls.Add ( this.DebugText );
            this.Controls.Add ( this.TimeSet );
            this.Name = "DEBUG";
            this.Size = new System.Drawing.Size ( 547, 366 );
            this.VisibleChanged += new System.EventHandler ( this.DEBUG_VisibleChanged );
            this.ResumeLayout ( false );
            this.PerformLayout ();

        }

        #endregion

        private System.Windows.Forms.Label TimeSet;
        private System.Windows.Forms.TextBox DebugText;
        private System.Windows.Forms.LinkLabel clearDebugText;
        private System.Windows.Forms.Label lblListCount;
    }
}
