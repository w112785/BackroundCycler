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
using System.IO;
using Backround_Cycler.Core;

namespace Backround_Cycler.Control
{
    public partial class DEBUG : UserControl
    {
        /// <summary>
        /// Bool value true if the Debug text exists otherwise false
        /// </summary>
        private bool DebugExist;
        /// <summary>
        /// Initializes a new instance of the <see cref="DEBUG"/> class.
        /// </summary>
        public DEBUG ()
        {
            InitializeComponent ();

            if (File.Exists ( ApplicationInfo.debugFileName ))
            {
                TextReader debug = new StreamReader ( ApplicationInfo.debugFileName );
                DebugText.Text = debug.ReadToEnd ();
                DebugText.Visible = true;
                debug.Close ();
                DebugExist = true;
            }
            else
            {
                DebugText.Visible = false;
                DebugExist = false;
            }
        }

        /// <summary>
        /// Changes the time lable.
        /// </summary>
        /// <param name="visible">if set to <c>true</c> makes the lable visible.</param>
        public void ChangeTimeLable ( bool visible )
        {
            this.TimeSet.Text = string.Format ( "TIME SET TO: {0}",
                   ApplicationInfo.MainForm.changebackroundtimer.Interval );
            this.TimeSet.Enabled = visible;
        }

        /// <summary>
        /// Tells the debug control that the time value has changed
        /// </summary>
        public void ValueChangedTimeLable ()
        {
            this.TimeSet.Text = string.Format ( "TIME SET TO: {0}",
                ApplicationInfo.MainForm.changebackroundtimer.Interval );
        }

        /// <summary>
        /// Handles the VisibleChanged event of the DEBUG control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DEBUG_VisibleChanged ( object sender, EventArgs e )
        {
            if (!this.DesignMode)
            {
                if ((!DebugExist) && File.Exists ( ApplicationInfo.debugFileName ))
                {
                    TextReader debug = new StreamReader ( ApplicationInfo.debugFileName );
                    DebugText.Text = debug.ReadToEnd ();
                    DebugText.Visible = true;
                    debug.Close ();
                    DebugExist = true;
                }
                else if (DebugExist)
                {
                    TextReader debug = new StreamReader ( ApplicationInfo.debugFileName );
                    DebugText.Clear ();
                    DebugText.Text = debug.ReadToEnd ();
                    debug.Close ();
                }
                lblListCount.Text = "Image List has " +
                    ApplicationInfo.MainForm.imageList1.FileListCount.ToString () + " items in it";
            }
        }

        /// <summary>
        /// Handles the LinkClicked event of the clearDebugText control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void clearDebugText_LinkClicked ( object sender, LinkLabelLinkClickedEventArgs e )
        {
            if (DebugText.Visible && File.Exists ( ApplicationInfo.debugFileName ))
            {
                File.Delete ( ApplicationInfo.debugFileName );
                DebugExist = false;
                DebugText.Visible = false;
            }
        }
    }
}
