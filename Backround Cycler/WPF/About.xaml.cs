using System.Windows;
using System.Windows.Controls;
using Backround_Cycler.Core;
using System.Diagnostics;

namespace Backround_Cycler.WPF
{
	/// <summary>
	/// Interaction logic for About.xaml
	/// </summary>
	public partial class About : UserControl
	{
		private readonly string labelLastImageText = "Last Image Shown: ";

		public About ()
		{
			InitializeComponent ();

			this.labelProductName.Content = ApplicationInfo.AssemblyProduct;
			this.labelVersion.Content = string.Format ("Version {0} {1}", ApplicationInfo.AssemblyVersion, ApplicationInfo.BETA);
			this.labelCopyright.Content = ApplicationInfo.AssemblyCopyright;

			this.TextBoxDescription.Text = ApplicationInfo.AssemblyDescription;

		}

		private void VisibleChanged (object sender, DependencyPropertyChangedEventArgs e)
		{
			//TODO: reload this.
			//this.labelLastImageShown.Content = labelLastImageText + ApplicationInfo.settings.LastImageShown;
		}

		private void LabelWebsite_Click (object sender, RoutedEventArgs e)
		{
			Process.Start (ApplicationInfo.strWebsite);
		}

		private void LabelEmail_Click (object sender, RoutedEventArgs e)
		{
			Process.Start (ApplicationInfo.strEMailAddress);
		}
	}
}
