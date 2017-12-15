using System.Windows;

namespace Backround_Cycler.Core
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
    {
        private void Application_Exit (object sender, ExitEventArgs e)
        {
            Backround_Cycler.Properties.Settings.Default.Save ();
        }

		private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
		{

		}
	}
}
