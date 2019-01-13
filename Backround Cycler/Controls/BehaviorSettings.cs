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
using Backround_Cycler.EventArguments;
using System.Reflection;
using Backround_Cycler.Enums;
using Backround_Cycler.Core;

namespace Backround_Cycler.Control
{
    /// <summary>
    /// 
    /// </summary>
    [DefaultEvent ( "AdvancedOptionsChecked" )]
    public partial class BehaviorSettings : UserControl
    {
        /// <summary>
        /// Gets the Time Value for calculation
        /// </summary>
        /// <value>The Time Value.</value>
        public decimal GetMin { get { return MinutesText.Value; } }

        /// <summary>
        /// Gets a value indicating whether subfolders is selected.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if subfolders is selected; otherwise, <c>false</c>.
        /// </value>
        internal bool IsSubfoldersSelected { get { return chkSubFolders.Checked; } }


        private Backround_Cycler.Properties.Settings Settings
        {
            get
            {
                return ApplicationInfo.settings;
            }
        }

        #region Events

        /// <summary>
        /// Occurs when TimeValue has changed.
        /// </summary>
        public event EventHandler<DecimalChangedEventArgs> MinutesChanged;
        protected virtual void OnMinutesChanged ( DecimalChangedEventArgs e )
        {
            if (MinutesChanged != null)
                MinutesChanged ( this, e );
        }

        /// <summary>
        /// Occurs when rotate checkbox has changed.
        /// </summary>
        public event EventHandler<BoolChangedEventArgs> RotateCheckboxChanged;
        protected virtual void OnRotateCheckboxChanged ( BoolChangedEventArgs e )
        {
            if (RotateCheckboxChanged != null)
                RotateCheckboxChanged ( this, e );
        }

        /// <summary>
        /// Occurs when advanced options check box has changed.
        /// </summary>
        public event EventHandler<BoolChangedEventArgs> AdvancedOptionsChecked;
        protected virtual void OnAdvancedOptionsChecked ( BoolChangedEventArgs e )
        {
            if (AdvancedOptionsChecked != null)
                AdvancedOptionsChecked ( this, e );
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="BehaviorSettings"/> class.
        /// </summary>
        public BehaviorSettings ()
        {
            InitializeComponent ();
            // Databind the ComboBox objects
            largerImagesComboBox.DataSource = Enum.GetNames (
                typeof ( DesktopBackgroundStyle ) );
            smallImagesComboBox.DataSource = Enum.GetNames (
                typeof ( DesktopBackgroundStyle ) );
            smallestImagesComboBox.DataSource = Enum.GetNames (
                typeof ( DesktopBackgroundStyle ) );

            changeTimeIntervelcomboBox.DataSource = Enum.GetNames (
                typeof ( IntervelLevel ) );

        }

        /// <summary>
        /// Handles the ValueChanged event of the minutestext control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void minutestext_ValueChanged ( object sender, EventArgs e )
        {
            this.Settings.Save ();
            OnMinutesChanged ( new DecimalChangedEventArgs ( this.MinutesText.Value ) );
        }

        /// <summary>
        /// Handles the CheckedChanged event of the ShowAdvancedOptions control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ShowAdvancedOptions_CheckedChanged ( object sender, EventArgs e )
        {
            OnAdvancedOptionsChecked ( new BoolChangedEventArgs ( ShowDebugInformation.Checked ) );
        }

        /// <summary>
        /// Handles the CheckedChanged event of the RotateCheckbox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RotateCheckbox_CheckedChanged ( object sender, EventArgs e )
        {
            if (RotateCheckbox.Checked)
            {
                try
                {
                    OnRotateCheckboxChanged ( new BoolChangedEventArgs ( true ) );
                }
                finally
                {
                    this.MinutesText.Enabled = true;
                    this.changeTimeIntervelcomboBox.Enabled = true;
                }
            }
            else // if ( !RotateCheckbox.Checked )
            {
                try
                {
                    OnRotateCheckboxChanged ( new BoolChangedEventArgs ( false ) );
                }
                finally
                {
                    this.MinutesText.Enabled = false;
                    this.changeTimeIntervelcomboBox.Enabled = false;
                }
            }

            Settings.Save ();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the autostartCheckbox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void autostartCheckbox_CheckedChanged ( object sender, EventArgs e )
        {
            string name = "Backround Cycler";
            // Based on checkbox, call API functions to add or remove
            // application path from registry Run section for current user.
            if (chkAutostartCheckbox.Checked)
            {
                WindowsAPI.AddStartupItem ( name,
                    Assembly.GetEntryAssembly ().Location );
            }
            else
            {
                WindowsAPI.RemoveStartupItem ( name );
            }
            Settings.Save ();
        }

        /// <summary>
        /// Handles the Load event of the BehaviorSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BehaviorSettings_Load ( object sender, EventArgs e )
        {
            // lets check to see if user has autochange on or off
            // if off than disable the box for time input 
            if (Settings.autochange)
            {
                this.MinutesText.Enabled = true;
            }
            else
            {
                this.MinutesText.Enabled = false;
            }

        }
    }
}
