/*
Copyright (c) 2006-2009, William Edward McCormick

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#define TESTING_WPF

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;
using Backround_Cycler.Core;

namespace Backround_Cycler
{
	/// <summary>
	/// The entry Class for the application
	/// </summary>
	static class Program
	{
        /*
		internal static Core.UI.Setting MainForm
		{
			get
			{
				return ApplicationInfo.MainForm;
			}
		}
         */

		internal static Properties.Settings Settings
		{
			get
			{
				return ApplicationInfo.settings;
			}
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// <param name="args">The args.</param>
		[STAThread]
		static void Main ( string[] args )
        {
#if !TESTING_WPF
			Application.EnableVisualStyles ();
			Application.SetCompatibleTextRenderingDefault ( false );
			try
			{
				if (ApplicationInfo.settings.FirstRun)
				{
					CheckForOldRegistryKey ();
					Properties.Settings.Default.Upgrade ();
					ApplicationInfo.settings.FirstRun = false;
				}
				ApplicationInfo.SetupMainForm ();
			}
			catch (Exception CEex)
			{
				LogError ( CEex );
				Error ();
				return;
			}

			ApplicationInfo.MainForm.imageList1.CheckForEmptyList ();

			// Change background on startup if user Wishes
			if (ApplicationInfo.settings.ChangeOnStartup)
			{
				ApplicationInfo.MainForm.StartThread ();
			}

			try
			{
				if (ApplicationInfo.settings.ShowDialogOnStartup)
				{
					if (!SingleApplication.Run ( ApplicationInfo.programGuid, ApplicationInfo.MainForm ))
					{
						ApplicationInfo.MainForm.appNotifyIconVisible = false;
						Application.Exit ();
					}
				}
				else
				{
					if (!SingleApplication.Run ( ApplicationInfo.programGuid ))
					{
						ApplicationInfo.MainForm.appNotifyIconVisible = false;
						Application.Exit ();
					}
				}
			}
			catch (Exception ex) // log the error and display a normal message
			{
				LogError ( ex );
				Error ();
				return;
			}
			if ((ApplicationInfo.MainForm != null))
			{
				if (ApplicationInfo.MainForm.appNotifyIconVisible)
				{
					ApplicationInfo.MainForm.appNotifyIconVisible = false;
				}
			}

			HandleThreads.StopAllThreads ();
#else

            App app = new App ();

            try
            {
                if (Settings.FirstRun)
                {
                    CheckForOldRegistryKey ();
                    Properties.Settings.Default.Upgrade ();
                    ApplicationInfo.settings.FirstRun = false;
                }
            }
            catch (Exception ex)
            {
                LogError (ex);
                Error ();
                throw;
            }

            

            app.InitializeComponent ();
            app.Run ();
            //System.Windows.Application app = new System.Windows.Application ();

            //app.Run (new WPF.MainWindow ());
#endif
		}

		/// <summary>
		/// Errors this instance.
		/// </summary>
		static void Error ()
		{
			MessageBox.Show ( "An error has accered go to \"" + ApplicationInfo.debugFileName +
					"\" for the Debug information that can be used to file a bug report\r\n" +
					"bug reports can be submitted here " +
					"http://sourceforge.net/tracker/?func=add&group_id=163002&atid=826017" +
					" A link can be found in the startmenu folder",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
		}

		
		/// <summary>
		/// Logs the error.
		/// </summary>
		/// <param name="ex">The Exception that was thrown</param>
		private static void LogError ( Exception ex )
		{
			if (!File.Exists ( ApplicationInfo.debugFileName ))
			{
				File.Create ( ApplicationInfo.debugFileName ).Close ();
			}
			File.AppendAllText ( ApplicationInfo.debugFileName, "\r\n" + ex.ToString () + "\r\n",
				System.Text.Encoding.ASCII );
		}

		/// <summary>  
		/// Checks for old registry key.
		/// </summary>
		internal static void CheckForOldRegistryKey ()
		{
			string keyValue = (Registry.GetValue (
				@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run",
				"BackgroundCycler", "null" )).ToString ();

			if (keyValue != "null")
			{
				using (RegistryKey delKey = Registry.CurrentUser.OpenSubKey (
					@"Software\Microsoft\Windows\CurrentVersion\Run" ))
				{
					delKey.DeleteSubKey ( "BackgroundCycler", false );
				}
			}


			string Value = (Registry.GetValue (
				@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run",
				"Backround Cycler", "null" )).ToString ();

			if (Value != "null" &&
				Value == Assembly.GetExecutingAssembly ().Location)
			{
				ApplicationInfo.settings.AutoStart = true;
			}

			ApplicationInfo.settings.Save ();
		}
	}
}