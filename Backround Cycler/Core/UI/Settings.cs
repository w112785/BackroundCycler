/*
Copyright (c) 2006-2009, William Edward McCormick

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using Backround_Cycler.EventArguments;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading;
using System.ComponentModel;
using Microsoft.Win32;

namespace Backround_Cycler.Core.UI
{

	/// <summary>
	/// 
	/// </summary>
	public partial class Setting : Form
	{
		#region constants and vareables

		private const int MILLISEC2SEC = 1000;
		private const int MILLISEC2MINS = MILLISEC2SEC * 60;
		private const int MILLISEC2HOURS = MILLISEC2MINS * 60;
		private const int MILLISEC2DAYS = MILLISEC2HOURS * 24;
		private TreeNode debug;

		#endregion // constants and vareables

		#region class methods

		/// <summary>
		/// Constructor for this class it will set-up the window and icons and
		/// all timers
		/// </summary>
		public Setting ()
		{
			InitializeComponent ();

			debug = new TreeNode ( "Debug" );
			debug.Name = "Debug";

			if (settings.ShowAdvancedOptions)
			{
				DebugOptions ( true );
			}
			else
			{
				DebugOptions ( false );
			}

			// If no picture folder has been selected, default to My Pictures.
			// This is probably first-time run.
			if (string.IsNullOrEmpty ( settings.PicturesFolder ) ||
				settings.PicturesFolder.Length == 0)
			{
				settings.PicturesFolder =
					System.Environment.GetFolderPath (
						Environment.SpecialFolder.MyPictures );

				settings.Save ();
			}

			about1.Visible = true;

			SetContentVisibilty ( false );
			if (settings.autochange)
			{
				CalculateTime ();
			}

			this.appNotifyIconVisible = true;
		}

		/// <summary>
		/// Handles the Load event of the settings control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void Setting_Load ( object sender, EventArgs e )
		{
			this.Text = "Backround Cycler version: " +
				Assembly.GetExecutingAssembly ().GetName ().Version.Major.ToString () +
				"." +
				Assembly.GetExecutingAssembly ().GetName ().Version.Minor.ToString () +
				" " + ApplicationInfo.BETA;
			debug1.ChangeTimeLable ( settings.autochange );
		}

		/// <summary>
		/// Change the Visibilty to all the custum controlls
		/// </summary>
		/// <param name="value">what to set the visibilty to,
		/// on the off chance that i what them all to be true</param>
		private void SetContentVisibilty ( bool value )
		{
			about1.Visible = value;
			behaviorSettings1.Visible = value;
			imageList1.Visible = value;
			debug1.Visible = value;
		}

		/// <summary>
		/// Handles the FormClosing event of the Setting control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
		private void Setting_FormClosing ( object sender, FormClosingEventArgs e )
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				settings.Save ();
				this.Visible = false;
				e.Cancel = true;
			}
			if (e.CloseReason == CloseReason.WindowsShutDown ||
				e.CloseReason == CloseReason.TaskManagerClosing)
			{
				settings.Save ();
				Application.Exit ();

			}
			if (e.CloseReason == CloseReason.ApplicationExitCall)
			{
				this.appNotifyIconVisible = false;
				settings.Save ();
			}
		}

		/// <summary>
		/// Shows the info bolloon.
		/// </summary>
		private void ShowInfoBolloon ()
		{

			if (!string.IsNullOrEmpty ( settings.LastImageShown ))
			{
				appNotifyIcon.BalloonTipText = "\n\n Current Wallpaper: " + settings.LastImageShown;
				appNotifyIcon.ShowBalloonTip ( 5 * MILLISEC2SEC );
			}

		}

		/// <summary>
		/// Starts the thread to change the background.
		/// </summary>
		internal void StartThread ()
		{
			if (!ChangeBackground.ChangingBackground)
			{
				HandleThreads.StartOneThread ("Change Background Thread", imageList1.ChangeDesktopBackground);
				// NOTE: Commented out to experement with new HandleThreads class WARNING EXPEREMENTAL
				//Thread change = new Thread ( new ThreadStart ( ChangeDeskTop ) );
				//change.Name = "Change Background Thread";
				//change.Start ();
			}

			this.CalculateTime ();
		}

		/// <summary>
		/// Gets the required creation parameters when the control
		/// handle is created.
		/// </summary>
		protected override CreateParams CreateParams
		{
			get
			{
				const int CS_DROPSHADOW = 0x20000;
				CreateParams cp = base.CreateParams;
				cp.ClassStyle = cp.ClassStyle | CS_DROPSHADOW;
				return cp;
			}
		}

		internal Backround_Cycler.Properties.Settings settings
		{
			get
			{
				return ApplicationInfo.settings;
			}
		}
		#endregion // class methods

		#region sys tray icon

		/// <summary>
		/// Sets the value for system tray icon visibleilty
		/// </summary>
		public bool appNotifyIconVisible
		{
			get
			{
				return appNotifyIcon.Visible;
			}
			set
			{
				appNotifyIcon.Visible = value;
			}
		}

		/// <summary>
		/// Handles the BalloonTipClicked event of the appNotifyIcon control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance
		/// containing the event data.</param>
		private void appNotifyIcon_BalloonTipClicked ( object sender, EventArgs e )
		{
			showSettingsToolStripMenuItem_Click ( sender, e );
		}

		/// <summary>
		/// Handles the MouseDoubleClick event of the appNotifyIcon control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> 
		/// instance containing the event data.</param>
		private void appNotifyIcon_MouseDoubleClick ( object sender,
													MouseEventArgs e )
		{
			showSettingsToolStripMenuItem_Click ( sender, (EventArgs)e );
		}

		/// <summary>
		/// Handles the MouseClick event of the appNotifyIcon control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/>
		/// instance containing the event data.</param>
		private void appNotifyIcon_MouseClick ( object sender, MouseEventArgs e )
		{
			if (e.Button == MouseButtons.Left)
			{
				ShowInfoBolloon ();
			}
		}

		#endregion // sys tray icon properties

		#region BehaviorSettings Methods

		/// <summary>
		/// Handles the RotateCheckboxChanged event of the behaviorSettings1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="Backround_Cycler.EventArguments.BoolChangedEventArgs"/> instance containing the event data.</param>
		private void behaviorSettings1_RotateCheckboxChanged ( object sender, BoolChangedEventArgs e )
		{
			if (e.Enabled)
			{
				this.changebackroundtimer.Enabled = true;
				this.CalculateTime ();

				debug1.ChangeTimeLable ( true );
			}
			else
			{
				this.changebackroundtimer.Enabled = false;

				debug1.ChangeTimeLable ( false );
			}
		}

		/// <summary>
		/// Handles the MinutesChanged event of the behaviorSettings1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="Backround_Cycler.EventArguments.DecimalChangedEventArgs"/> instance containing the event data.</param>
		private void behaviorSettings1_MinutesChanged ( object sender, DecimalChangedEventArgs e )
		{
			this.CalculateTime ();

			debug1.ValueChangedTimeLable ();
		}

		/// <summary>
		/// Handles the AdvancedOptionsChecked event of the behaviorSettings1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="Backround_Cycler.EventArguments.BoolChangedEventArgs"/>
		/// instance containing the event data.</param>
		private void behaviorSettings1_AdvancedOptionsChecked ( object sender,
			BoolChangedEventArgs e )
		{
			DebugOptions ( e.Enabled );
		}

		/// <summary>
		/// Handles the VisibleChanged event of the Setting control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void Setting_VisibleChanged ( object sender, EventArgs e )
		{
			if (this.Visible)
			{
				this.showSettingsToolStripMenuItem.Text = "Hide settings";
			}
			else
			{
				settings.Save ();
				this.showSettingsToolStripMenuItem.Text = "Show settings";
			}
		}

		#endregion // BehaviorSettings Methods

		#region Context menu

		/// <summary>
		/// Handles the Click event of the showSettingsToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void showSettingsToolStripMenuItem_Click ( object sender,
														 EventArgs e )
		{
			if (this.Visible == false)
			{
				this.Visible = true;
			}
			else
			{
				this.Visible = false;
			}
		}

		/// <summary>
		/// Handles the Click event of the quitToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void quitToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			Application.Exit ();
		}

		/// <summary>
		/// Handles the Click event of the aboutBackroundCyclerToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void aboutBackroundCyclerToolStripMenuItem_Click ( object sender,
																 EventArgs e )
		{
			this.Visible = true;
			treeView1.SelectedNode = treeView1.Nodes["About"];
			this.Activate ();
		}

		private void editSettingsToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			this.Visible = true;
			treeView1.SelectedNode = treeView1.Nodes["Behavior"];
			this.Activate ();
		}

		/// <summary>
		/// Handles the Click event of the changeNowToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void changeNowToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			StartThread ();
		}

		/// <summary>
		/// Handles the Click event of the reportABugToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void reportABugToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			Process.Start ( ApplicationInfo.strBugReport );
		}

		/// <summary>
		/// Handles the Click event of the donateToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void donateToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			Process.Start ( ApplicationInfo.strDonateAddress );
		}

		#endregion // Context menu

		#region timer methods

		/// <summary>
		/// Handles the Tick event of the changebackroundtimer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void changebackroundtimer_Tick ( object sender, EventArgs e )
		{
			StartThread ();
		}

		/// <summary>
		/// calculatetime is used to convert the minites from the 
		/// minutestext section on the window form amd cconverts it 
		/// to millisecends that the changebackroundtimer needs
		/// </summary>
		public void CalculateTime ()
		{
			decimal time;
			bool oldvalue = this.changebackroundtimer.Enabled;
			this.changebackroundtimer.Enabled = false;

			string typelevel = settings.TimeIntervelLevel;

			Enums.IntervelLevel intervelLevel = (Enums.IntervelLevel)Enum.Parse (
				typeof ( Enums.IntervelLevel ), typelevel, true );

			switch (intervelLevel)
			{
				case Enums.IntervelLevel.Seconds:
					time = (behaviorSettings1.GetMin * MILLISEC2SEC);
					break;
				case Enums.IntervelLevel.Minutes:
					time = (behaviorSettings1.GetMin * MILLISEC2MINS);
					break;
				case Enums.IntervelLevel.Hours:
					time = (behaviorSettings1.GetMin * MILLISEC2HOURS);
					break;
				case Enums.IntervelLevel.Days:
					time = (behaviorSettings1.GetMin * MILLISEC2DAYS);
					break;
				default:
					time = (behaviorSettings1.GetMin * MILLISEC2MINS);
					break;
			}

			if (time > Int32.MaxValue)
			{
				time = (decimal)Int32.MaxValue;
			}

			this.changebackroundtimer.Interval = (int)time;
			this.changebackroundtimer.Enabled = oldvalue;
		}

		#endregion // timer methods

		#region Tree View methods
		/// <summary>
		/// Handles the AfterSelect event of the treeView1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/>
		/// instance containing the event data.</param>
		private void treeView1_AfterSelect ( object sender, TreeViewEventArgs e )
		{
			switch (e.Node.Name.ToLower ())
			{
				case "about":
					SetContentVisibilty ( false );
					about1.Visible = true;
					break;
				case "behavior":
					SetContentVisibilty ( false );
					behaviorSettings1.Visible = true;
					break;
				case "pictures":
					SetContentVisibilty ( false );
					imageList1.Visible = true;
					break;
				case "debug":
					SetContentVisibilty ( false );
					debug1.Visible = true;
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Debugs the options.
		/// </summary>
		/// <param name="Enabled">if set to <c>true</c> to enable Debug.</param>
		protected virtual void DebugOptions ( bool Enabled )
		{
			if (!Enabled)
				debug.Remove ();
			else
				this.treeView1.Nodes.Add ( debug );
		}
		#endregion

		//private void imageList1_redraw ( object sender, EventArgs e )
		//{
		//    this.Invalidate ();
		//    //this.Invoke (about1.Refresh);
		//    about1.Refresh ();
		//}
	}
}
