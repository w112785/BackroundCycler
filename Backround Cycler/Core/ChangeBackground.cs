/*
Copyright (c) 2007-2009, William Edward McCormick

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Backround_Cycler.Enums;

namespace Backround_Cycler.Core
{
	class ChangeBackground : IDisposable
	{
		private static bool afterFirstError = false;
		private Random rnd = new Random ();
		private DesktopBackgroundStyle style;

		private string[] listOfImages;

		private Backround_Cycler.Properties.Settings settings
		{
			get
			{
				return ApplicationInfo.settings;
			}
		}


		private static bool _ChangingBackground;
		public static bool ChangingBackground
		{
			get { return _ChangingBackground; }
			set { _ChangingBackground = value; }
		}

		static ChangeBackground ()
		{
			_ChangingBackground = false;
		}

		public ChangeBackground ( string[] images )
		{
			listOfImages = images;
		}

		/// <summary>
		/// changes the desktop backround using the windows API
		/// </summary>
		internal void ChangeDesktopBackground ()
		{

			Bitmap img;
			try
			{
				// Find an image file
				 img = DetermineImageFile ();

			}
			catch (FileNotFoundException)
			{
				if (afterFirstError)
				{
					MessageBox.Show (
						"Sorry, either no images in specified folder, or I gave up due " +
						"to so many non-image files.\r\n", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Information,
						MessageBoxDefaultButton.Button1,
						MessageBoxOptions.DefaultDesktopOnly, false );
				}
				else // HACK: nasty workaround for a ocasonal error in fast setups
				{
					afterFirstError = true;
				}

				return;
			}

			if (img == null)
			{
				MessageBox.Show ( "Sorry, no avalible images are in your pictures list\r\n" +
						" Did you remane a folder your pictures are in.\r\n", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Information,
						MessageBoxDefaultButton.Button1,
						MessageBoxOptions.DefaultDesktopOnly, false );
				return;
			}
			// Set the image
			WindowsAPI.SetDesktopBackground ( img, style );

			if (afterFirstError)
			{
				afterFirstError = false;
			}
			// Save the settings
			settings.Save ();
		}


		/// <summary>
		/// Grab list of files, filter out bad choices,
		/// return one randomly good file
		/// </summary>
		/// <returns>Bitmap file</returns>
		private Bitmap DetermineImageFile ()
		{
			Bitmap img;
			string filename;
			bool foundimage = false;

			string[] files = this.listOfImages;

			// Filter list to remove non-images, last image shown,
			// and the app-generated BMP file from a previous run.
			// realy a sanity check because now everything gets filtered beforhand
			List<String> filteredFiles = new List<String> ();

			try
			{
				foreach (string file in files)
				{
					string ext = file.Substring ( file.LastIndexOf ( "." ) );

					if (".jpg .bmp .gif .png .jpeg".IndexOf ( ext.ToLower () ) > -1 &&
						!file.EndsWith ( "backroundcycler.bmp" ) &&
						file != settings.LastImageShown &&
						File.Exists(file))
					{
						filteredFiles.Add ( file );
					}
				}
			}
			catch
			{
				return null;
			}

			// Make sure there are files left
			if (filteredFiles.Count == 0) { return null; }
			do
			{
				// Randomly grab a file
				filename = filteredFiles[rnd.Next ( filteredFiles.Count - 1 )];

				img = new Bitmap ( filename );
				style = DetermineImageStyle ( img );
				if (style == DesktopBackgroundStyle.Nothing)
				{
					filteredFiles.Remove ( filename );
					if (filteredFiles.Count == 0)
					{
						return null;
					}
					continue;
				}
				else if (style == DesktopBackgroundStyle.Scaled)
				{
					Size imgSize = ScaledImageDimensions ( img.Size, Screen.PrimaryScreen.Bounds.Size );
					img = new Bitmap ( img, imgSize );
					style = DesktopBackgroundStyle.Centered;
				}
				foundimage = true;
			} while (!foundimage);

			// Remember last image shown
			settings.LastImageShown = filename;

			// Return the bitmap object from this filename
			return img;
		}

		/// <summary>
		/// Return a DesktopBackgroundStyle enum based on image size and
		/// behavior settings.
		/// </summary>
		/// 
		/// <param name="img">the image that we need to get the 
		/// size from</param>
		/// 
		/// <returns>One of the values in DesktopBackgroundStyle enum</returns>
		private DesktopBackgroundStyle DetermineImageStyle ( Bitmap img )
		{
			int smallestSize =
				int.Parse ( settings.SmallestImageSize.ToString () );
			int imgW = img.Width, imgH = img.Height;
			int desktopW = Screen.PrimaryScreen.Bounds.Width;
			int desktopH = Screen.PrimaryScreen.Bounds.Height;

			string style;

			if (imgW > desktopW || imgH > desktopH)
			{
				style = settings.LargeImageBehavior;
			}
			else if (imgW <= smallestSize || imgH <= smallestSize)
			{
				style = settings.SmallestImageBehavior;
			}
			else
			{
				style = settings.SmallImageBehavior;
			}

			try
			{
				return (DesktopBackgroundStyle)Enum.Parse (
													typeof ( DesktopBackgroundStyle ),
													style, true );
			}
			catch
			{
				// ok the user typed in something in one of the DesktopBackgroundStyle 
				// comboboxes so now we have a long dialog box call and return center
				MessageBox.Show ( "ERROR with setting background style\r\n" +
								"Could be because you typed something other than" +
								" Tiled, Centered, Stretched, Scaled, Nothing\r\n" +
								"Defaulting to Centered",
								"Background Style Error",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
								MessageBoxOptions.ServiceNotification, false );
				return DesktopBackgroundStyle.Centered;
			}
		}

		private Size ScaledImageDimensions ( Size current, Size destination )
		{
			float nPercent = 0;
			float nPercentW = 0;
			float nPercentH = 0;

			nPercentW = ((float)destination.Width / (float)current.Width);
			nPercentH = ((float)destination.Height / (float)current.Height);

			if (nPercentH < nPercentW)
			{
				nPercent = nPercentH;
			}
			else
			{
				nPercent = nPercentW;
			}

			int destWidth = (int)(current.Width * nPercent);
			int destHeight = (int)(current.Height * nPercent);

			if (destWidth.Equals ( 0 ))
			{
				destWidth = 1;
			}
			if (destHeight.Equals ( 0 ))
			{
				destHeight = 1;
			}

			Size newSize = new Size ( destWidth, destHeight );

			return newSize;

		}

		#region IDisposable Members

		public void Dispose ()
		{
		}

		#endregion
	}
}
