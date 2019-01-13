/*
Copyright (c) 2007-2008, William Edward McCormick

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Backround_Cycler.Core;

namespace Backround_Cycler.Control
{
    /// <summary>
    /// The About Control
    /// </summary>
    public partial class About : UserControl
    {
        private readonly string labelLastImageText = "Last Image Shown: ";

        /// <summary>
        /// Initializes a new instance of the <see cref="About"/> class.
        /// </summary>
        public About ()
        {
            InitializeComponent ();


            this.Text = String.Format ( "About {0}", ApplicationInfo.AssemblyProduct );
            this.labelProductName.Text = ApplicationInfo.AssemblyProduct;
            this.labelVersion.Text = String.Format ( "Version {0} {1}",
                        ApplicationInfo.AssemblyVersion, ApplicationInfo.BETA );

            this.labelLastImage.Text = labelLastImageText + ApplicationInfo.settings.LastImageShown;

            this.labelCopyright.Text = ApplicationInfo.AssemblyCopyright;
            this.textBoxDescription.Text = ApplicationInfo.AssemblyDescription;
            this.linkLabelwebsite.Text = "Visit website";
            this.linkLabelEmail.Text = "E-mail Me";
        }

        /// <summary>
        /// Handles the LinkClicked event of the linkLabelwebsite control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void linkLabelwebsite_LinkClicked ( object sender, LinkLabelLinkClickedEventArgs e )
        {
            Process.Start ( ApplicationInfo.strWebsite );
        }

        /// <summary>
        /// Handles the LinkClicked event of the linkLabelEmail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void linkLabelEmail_LinkClicked ( object sender, LinkLabelLinkClickedEventArgs e )
        {
            Process.Start ( ApplicationInfo.strEMailAddress );
        }

        /// <summary>
        /// Handles the VisibleChanged event of the About control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void About_VisibleChanged ( object sender, EventArgs e )
        {
            this.labelLastImage.Text = labelLastImageText + ApplicationInfo.settings.LastImageShown;
        }
    }
}
