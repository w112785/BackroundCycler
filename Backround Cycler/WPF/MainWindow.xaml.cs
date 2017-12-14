using System;
using System.Windows;
using System.Windows.Controls;
using WinForms = System.Windows.Forms;
using System.Reflection;
using Backround_Cycler.Core;
using System.Diagnostics;

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
        private WinForms.Timer timer = new WinForms.Timer ();

        #endregion // constants and vareables

        public MainWindow ()
        {
            InitializeComponent ();
            

            //this.taskbarIcon.Icon = Properties.Resources.Cycle;

            this.About.IsSelected = true;
            //this.about.Visibility = System.Windows.Visibility.Visible;

            this.Title = "Backround Cycler version: " +
                Assembly.GetExecutingAssembly ().GetName ().Version.Major.ToString () +
                "." +
                Assembly.GetExecutingAssembly ().GetName ().Version.Minor.ToString () +
                " WPF DEVELOPMENT PREVIEW";
            ApplicationInfo.timmer.Interval = new TimeSpan (0, 0, 0, 0, 0);

            if (ApplicationInfo.settings.ShowDialogOnStartup)
            {
                this.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.Visibility = System.Windows.Visibility.Hidden;
            }
            
        }

        #region NotifyIconSystem
        
        private void ChangeBackgroundNow_Click (object sender, RoutedEventArgs e)
        {

        }

        private void AboutBackroundCycler_Click (object sender, RoutedEventArgs e)
        {
            this.About.IsSelected = true;
            //MakeControlsHidden ();
            //this.about.Visibility = System.Windows.Visibility.Visible;
            this.Visibility = System.Windows.Visibility.Visible;
        }

        private void ShowWindow_Click (object sender, RoutedEventArgs e)
        {
            if (this.Visibility == System.Windows.Visibility.Visible)
            {
                this.Visibility = System.Windows.Visibility.Hidden;
            } else if (this.Visibility == System.Windows.Visibility.Hidden || this.Visibility == System.Windows.Visibility.Collapsed)
            {
                this.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void EditSettings_Click (object sender, RoutedEventArgs e)
        {
            if (this.Visibility == System.Windows.Visibility.Hidden || this.Visibility == System.Windows.Visibility.Collapsed)
            {
                this.Visibility = System.Windows.Visibility.Visible;
            }

            this.Settings.IsSelected = true;
        }

        private void Quit_Click (object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown ();
        }

        #endregion

        private void About_Click (object sender, ContextMenuEventArgs e)
        {
           // MakeControlsHidden ();
            this.about.Visibility = System.Windows.Visibility.Visible;
        }

        private void Window_IsVisibleChanged (object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == System.Windows.Visibility.Visible)
            {
                this.ShowWindow.Header = "Hide Backround Cycler";
            }
            else
            {
                this.ShowWindow.Header = "Show Backround Cycler";
                Hide ();
            }
        }

        private void ReportBug_Click (object sender, RoutedEventArgs e)
        {
            Process.Start (ApplicationInfo.strBugReport);
        }

        private void Donate_Click (object sender, RoutedEventArgs e)
        {
            Process.Start (ApplicationInfo.strDonateAddress);
        }

        private void Website_Click (object sender, RoutedEventArgs e)
        {
            Process.Start (ApplicationInfo.strWebsite);
        }
    }
}
