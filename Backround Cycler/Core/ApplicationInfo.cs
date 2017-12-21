/*
Copyright (c) 2007-2017, William Edward McCormick

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.IO;
using System.Reflection;
//using Backround_Cycler.Core.UI;
using System.Windows.Threading;

namespace Backround_Cycler.Core
{
    internal static class ApplicationInfo
    {
		#region Gloable NonMetaData Variables

		internal static bool closeWindow = false;

		#endregion

		#region For Assembly Attributes

		public const string programGuid = "6f9f8c3d-81a8-4742-95d9-d10f3e7a2d2b";
        // Version information for an assembly consists of the following four values:
        //
        //      Major Version
        //      Minor Version
        //      Build Number
        //      Revision
        //
        // keep all numbers do not use stars
        public const string programVersion = "5.5.0.55";

        #endregion

        /// <summary>
        /// The Beta Constant
        /// </summary>
#if !DEBUG
        public const string BETA = " ";
#else
        public const string BETA = "WPF DEVELOPMENT PREVIEW";
#endif
        public const string strWebsite = 
            "http://backroundcycler.sourceforge.net/";
        public const string strEMailAddress = 
            "MailTo:williammccormic@users.sourceforge.net";
        public const string strDonateAddress = 
            "http://sourceforge.net/donate/index.php?group_id=163002";
        public const string strBugReport = 
            "http://sourceforge.net/tracker2/?func=browse&group_id=163002&atid=826017";

        public static readonly string localDataPath = Path.Combine (
            Environment.GetFolderPath ( Environment.SpecialFolder.LocalApplicationData ),
            "William_McCormick" );
        public static readonly string debugFileName = Path.Combine ( localDataPath ,"DEBUG.txt" );

        public static Properties.Settings settings;

        /*
        private static Setting _MainForm;

        /// <summary>
        /// The main Form of the whole application.
        /// </summary>
        public static Setting MainForm
        {
            get
            {
                return _MainForm;
            }
        }
         */

        static ApplicationInfo ()
        {
            settings = Properties.Settings.Default;
        }

        #region Assembly Propertys

        public static string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly ().
                    GetCustomAttributes ( typeof ( AssemblyTitleAttribute ), false );
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute =
                        (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (!string.IsNullOrEmpty ( titleAttribute.Title ))
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute
                // was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension (
                    Assembly.GetExecutingAssembly ().CodeBase );
            }
        }

		public static string AssemblyMajorVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.Major.ToString();
			}
		}

		public static string AssemblyMinorVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
			}
		}

        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly ().GetName ().Version.ToString ();
            }
        }

        public static string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly ().
                    GetCustomAttributes ( typeof ( AssemblyDescriptionAttribute ),
                    false );
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly ().
                    GetCustomAttributes ( typeof ( AssemblyProductAttribute ), false );
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly ().
                    GetCustomAttributes ( typeof ( AssemblyCopyrightAttribute ),
                    false );
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public static string AssemblyCompany
        {
            get
            {
                // Get all Company attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly ().
                    GetCustomAttributes ( typeof ( AssemblyCompanyAttribute ), false );
                // If there aren't any Company attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Company attribute, return its value
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion

        #region WPF Controls

        internal static DispatcherTimer timer = new DispatcherTimer ();

        #endregion
    }
}
