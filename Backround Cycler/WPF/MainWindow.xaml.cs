using System;
using System.Windows;
using System.Windows.Controls;
using WinForms = System.Windows.Forms;
using System.Reflection;
using Backround_Cycler.Core;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;

namespace Backround_Cycler.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		#region constants and vareables

		private const int MILLISEC2SEC = 1000;
		private const int MILLISEC2MINS = MILLISEC2SEC * 60;
		private const int MILLISEC2HOURS = MILLISEC2MINS * 60;
		private const int MILLISEC2DAYS = MILLISEC2HOURS * 24;

		#endregion // constants and vareables

		public MainWindow()
		{
			InitializeComponent();
			

			//this.taskbarIcon.Icon = Properties.Resources.Cycle;

			this.About.IsSelected = true;
			//this.about.Visibility = System.Windows.Visibility.Visible;

			this.Title = string.Format("Backround Cycler version: {0}.{1} {2}",
				ApplicationInfo.AssemblyMajorVersion, ApplicationInfo.AssemblyMinorVersion,
				ApplicationInfo.BETA);

			//this.Title = "Backround Cycler version: " +
			//    Assembly.GetExecutingAssembly ().GetName ().Version.Major.ToString () +
			//    "." +
			//    Assembly.GetExecutingAssembly ().GetName ().Version.Minor.ToString () +
			//    " WPF DEVELOPMENT PREVIEW";
			ApplicationInfo.timer.Interval = new TimeSpan(0, 0, 0, 0, 0);

			if (ApplicationInfo.settings.ShowDialogOnStartup)
			{
				this.Visibility = Visibility.Visible;
			}
			else
			{
				this.Visibility = Visibility.Hidden;
			}

		}

		#region NotifyIconSystem

		private void ChangeBackgroundNow_Click(object sender, RoutedEventArgs e)
		{

		}

		private void AboutBackroundCycler_Click(object sender, RoutedEventArgs e)
		{
			this.About.IsSelected = true;
			//MakeControlsHidden ();
			//this.about.Visibility = System.Windows.Visibility.Visible;
			this.Visibility = Visibility.Visible;
		}

		private void ShowWindow_Click(object sender, RoutedEventArgs e)
		{
			if (this.Visibility == Visibility.Visible)
			{
				this.Visibility = Visibility.Hidden;
			}
			else if (this.Visibility == Visibility.Hidden || this.Visibility == Visibility.Collapsed)
			{
				this.Visibility = Visibility.Visible;
			}
		}

		private void EditSettings_Click(object sender, RoutedEventArgs e)
		{
			if (this.Visibility == Visibility.Hidden || this.Visibility == Visibility.Collapsed)
			{
				this.Visibility = Visibility.Visible;
			}

			this.Settings.IsSelected = true;
		}

		private void Quit_Click(object sender, RoutedEventArgs e)
		{
			ApplicationInfo.closeWindow = true;
			Application.Current.Shutdown();
		}

		#endregion

		private void About_Click(object sender, ContextMenuEventArgs e)
		{
			// MakeControlsHidden ();
			this.about.Visibility = Visibility.Visible;
		}

		private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.Visibility == Visibility.Visible)
			{
				this.ShowWindow.Header = "Hide Backround Cycler";
			}
			else
			{
				this.ShowWindow.Header = "Show Backround Cycler";
				Hide();
			}
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			ApplicationInfo.settings.Save();
			if (!ApplicationInfo.closeWindow)
			{
				e.Cancel = true;
				this.Visibility = Visibility.Hidden;
			}
			else
			{
				this.Visibility = Visibility.Hidden;
			}
		}

		private void ReportBug_Click(object sender, RoutedEventArgs e)
		{
			Process.Start(ApplicationInfo.strBugReport);
		}

		private void Donate_Click(object sender, RoutedEventArgs e)
		{
			Process.Start(ApplicationInfo.strDonateAddress);
		}

		private void Website_Click(object sender, RoutedEventArgs e)
		{
			Process.Start(ApplicationInfo.strWebsite);
		}

		private void taskbarIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
		{
			if(this.Visibility == Visibility.Hidden)
			{
				this.Visibility = Visibility.Visible;
			}
			else if (this.Visibility == Visibility.Visible)
			{
				this.Visibility = Visibility.Hidden;
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			pictureList.CheckForEmptyList();
		}
	}
}
