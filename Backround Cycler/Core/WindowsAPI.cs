/*
Copyright (c) 2006-2017, William Edward McCormick

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Drawing;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using Backround_Cycler.Enums;


namespace Backround_Cycler.Core
{
	/// <summary>
	/// Internal class for code that uses win32 calls
	/// </summary>
	internal static class WindowsAPI
	{
		#region Windows API Imports

		// NEEDED FOR WINDOWS API MODIFY AT OWN RISK
		internal const int SPI_SETDESKWALLPAPER = 20;
		internal const int SPIF_UPDATEINIFILE = 0x01;
		internal const int SPIF_SENDWININICHANGE = 0x02;
		/// <summary>
		/// FOR ANIMATION, MODIFY AT OWN RISK
		/// </summary>
		internal const int IDANI_CAPTION = 3;

		/// <summary>
		/// Retrieves or sets the value of one of the system-wide
		/// parameters. This function can also update the user profile
		/// while setting a parameter.
		/// </summary>
		/// 
		/// <param name="uAction">The system-wide parameter to be
		/// retrieved or set. This parameter can be one of the
		/// following values. They are organized in tables of related
		/// parameters. here
		/// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/sysinfo/base/systemparametersinfo.asp
		/// </param>
		/// 
		/// <param name="uParam">A parameter whose usage and format
		/// depends on the system parameter being queried or set. For
		/// more information about system-wide parameters, see the
		/// uiAction parameter. If not otherwise indicated, you must
		/// specify zero for this parameter.</param>
		/// 
		/// <param name="lpvParam">[in, out] A parameter whose usage
		/// and format depends on the system parameter being queried
		/// or set. For more information about system-wide parameters,
		/// see the uiAction parameter. If not otherwise indicated,
		/// you must specify NULL for this parameter.</param>
		/// 
		/// <param name="fuWinIni">If a system parameter is being set,
		/// specifies whether the user profile is to be updated, and
		/// if so, whether the WM_SETTINGCHANGE message is to be
		/// broadcast to all top-level windows to notify them of the
		/// change.</param>
		/// 
		/// <returns>If the function succeeds, the return value is a
		/// nonzero value.</returns>
		[DllImport ( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
		[return: MarshalAs ( UnmanagedType.Bool )]
		internal static extern bool SystemParametersInfo (
			int uAction, int uParam, string lpvParam, int fuWinIni );

		/// <summary>
		/// The RECT structure defines the coordinates of the upper-left
		/// and lower-right corners of a rectangle.
		/// MEMBERS:
		/// left-
		/// Specifies the x-coordinate of the upper-left
		/// corner of the rectangle.
		/// 
		/// top-
		/// Specifies the y-coordinate of the upper-left
		/// corner of therectangle.
		/// 
		/// right-
		/// Specifies the x-coordinate of the lower-right
		/// corner of the rectangle.
		/// 
		/// bottom-
		/// Specifies the x-coordinate of the lower-right
		/// corner of the rectangle.
		/// </summary>
		[StructLayout ( LayoutKind.Sequential )]
		internal struct RECT
		{
			/// <summary>
			/// Specifies the x-coordinate of the upper-left
			/// corner of the rectangle.
			/// </summary>
			public int left;
			/// <summary>
			/// Specifies the y-coordinate of the upper-left
			/// corner of therectangle.
			/// </summary>
			public int top;
			/// <summary>
			/// Specifies the x-coordinate of the lower-right
			/// corner of the rectangle.
			/// </summary>
			public int right;
			/// <summary>
			/// Specifies the x-coordinate of the lower-right
			/// corner of the rectangle.
			/// </summary>
			public int bottom;
			public override string ToString ()
			{
				return ("Left :" + left.ToString () + ", Top :" +
						top.ToString () + ", Right :" + right.ToString () +
						", Bottom :" + bottom.ToString ());
			}
		}

		/// <summary>
		/// The DrawAnimatedRects function draws a wire-frame rectangle
		/// and animates it to indicate the opening of an icon or the
		/// minimizing or maximizing of a window.
		/// </summary>
		/// 
		/// <param name="hwnd">Handle to the window to which the rectangle
		/// is clipped. If this parameter is NULL, the working area of the
		/// screen is used.</param>
		/// 
		/// <param name="idAni">Specifies the type of animation. If you 
		/// specify IDANI_CAPTION, the window caption will animate from the
		/// position specified by lprcFrom to the position specified by 
		/// lprcTo. The effect is similar to minimizing or maximizing a window.
		/// </param>
		/// 
		/// <param name="lprcFrom">Pointer to a RECT structure specifying 
		/// the location and size of the icon or minimized window. 
		/// Coordinates are relative to the clipping window hwnd.</param>
		/// 
		/// <param name="lprcTo">Pointer to a RECT structure specifying
		/// the location and size of the restored window. Coordinates are
		/// relative to the clipping window hwnd.</param>
		/// 
		/// <returns>If the function succeeds, the return value is nonzero.
		/// If the function fails, the return value is zero.</returns>
		[DllImport ( "user32.dll", EntryPoint = "DrawAnimatedRects",
					CharSet = CharSet.Auto )]
		[return: MarshalAs ( UnmanagedType.Bool )]
        [Obsolete]
		internal static extern bool DrawAnimatedRects ( IntPtr hwnd, int idAni,
													 ref RECT lprcFrom,
													 ref RECT lprcTo );


		/// <summary>
		/// The GetWindowRect function retrieves the dimensions of the
		/// bounding rectangle of the specified window. The dimensions
		/// are given in screen coordinates that are relative to the
		/// upper-left corner of the screen.
		/// </summary>
		/// 
		/// <param name="hwnd">Handle to the window.</param>
		/// 
		/// <param name="lpRect">[out] Pointer to a structure that receives
		/// the screen coordinates of the upper-left and lower-right corners
		/// of the window.</param>
		/// 
		/// <returns>f the function succeeds, the return value is nonzero.
		/// If the function fails, the return value is zero.</returns>
		[DllImport ( "user32.dll", EntryPoint = "GetWindowRect",
					CharSet = CharSet.Auto )]
		[return: MarshalAs ( UnmanagedType.Bool )]
        [Obsolete]
		internal extern static bool GetWindowRect ( IntPtr hwnd, ref RECT lpRect );

		/// <summary>
		/// The FindWindowEx function retrieves a handle to a window
		/// whose class name and window name match the specified strings.
		/// The function searches child windows, beginning with the one
		/// following the specified child window.
		/// This function does not perform a case-sensitive search.
		/// </summary>
		/// 
		/// <param name="hwndParent">Handle to the parent window whose child
		/// windows are to be searched</param>
		/// 
		/// <param name="hwndChildAfter">Handle to a child window. The search
		/// begins with the next child window in the Z order. The child window
		/// must be a direct child window of hwndParent, not just a descendant
		/// window.</param>
		/// 
		/// <param name="lpszClass">Pointer to a null-terminated string that 
		/// specifies the class name or a class atom created by a previous call
		/// to the RegisterClass or RegisterClassEx function. The atom must
		/// be placed in the low-order word of lpszClass; the high-order word
		/// must be zero.</param>
		/// 
		/// <param name="lpszWindow">Pointer to a null-terminated string that 
		/// specifies the window name (the window's title). If this parameter
		/// is NULL, all window names match.</param>
		/// 
		/// <returns>If the function succeeds, the return value is a handle
		/// to the window that has the specified class and window names.
		/// If the function fails, the return value is NULL</returns>
		[DllImport ( "user32.dll", EntryPoint = "FindWindowEx",
					CharSet = CharSet.Auto )]
        [Obsolete]
		internal extern static IntPtr FindWindowEx (
			IntPtr hwndParent,
			IntPtr hwndChildAfter,
			[MarshalAs ( UnmanagedType.LPTStr )]
			string lpszClass,
			[MarshalAs ( UnmanagedType.LPTStr )]
			string lpszWindow );

		#endregion //Windows API Imports

		#region startup section

		/// <summary>
		/// Adds the named item and its path to the Current User
		/// startup in registry.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="path"></param>
		internal static void AddStartupItem ( string name, string path )
		{
			RegistryKey Setkey = Registry.CurrentUser.OpenSubKey (
				@"Software\Microsoft\Windows\CurrentVersion\Run", true );

			Setkey.SetValue ( name, path );
		}

		/// <summary>
		/// Removes the named item from Current User startup in registry.
		/// </summary>
		/// <param name="name"></param>
		internal static void RemoveStartupItem ( string name )
		{
			RegistryKey Delkey = Registry.CurrentUser.OpenSubKey (
				@"Software\Microsoft\Windows\CurrentVersion\Run", true );

			Delkey.DeleteValue ( name, false );
		}

		#endregion //startup section

		/// <summary>
		/// Set the Desktop background to the supplied image.  Image must be
		/// saved as BMP (saves to My Pictures), and uses the specified
		/// style (Tiled, Centered, Stretched).
		/// </summary>
		/// 
		/// <param name="img">The Image file that will be used to set
		/// the background</param>
		/// 
		/// <param name="style">The style that was deturmend in another
		/// function</param>
		internal static void SetDesktopBackground ( Bitmap img,
												DesktopBackgroundStyle style )
		{
			string picturesPath = Path.Combine ( ApplicationInfo.localDataPath, "backroundcycler.bmp" );

			// Clear the current background (releases lock on current bitmap)
			SystemParametersInfo ( SPI_SETDESKWALLPAPER, 0,
				string.Empty, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE );

			try
			{
				// Convert to BMP and save
				img.Save ( picturesPath, System.Drawing.Imaging.ImageFormat.Bmp );
			}
			catch (ExternalException)
			{
				return;
			}

			RegistryKey key = Registry.CurrentUser.OpenSubKey (
				@"Control Panel\Desktop", true );

			switch (style)
			{
				case DesktopBackgroundStyle.Stretched:
					key.SetValue ( @"WallpaperStyle", "2" );
					key.SetValue ( @"TileWallpaper", "0" );
					break;

				case DesktopBackgroundStyle.Centered:
					key.SetValue ( @"WallpaperStyle", "0" );
					key.SetValue ( @"TileWallpaper", "0" );
					break;

				case DesktopBackgroundStyle.Tiled:
					key.SetValue ( @"WallpaperStyle", "1" );
					key.SetValue ( @"TileWallpaper", "1" );
					break;

				case DesktopBackgroundStyle.Nothing:
					throw new ArgumentException ( 
						"nothing cannot be used in SetDesktopBackground() Style", "Style" );
				   
				case DesktopBackgroundStyle.Scaled:
					throw new ArgumentException ( 
						"Scaled cannot be used in SetDesktopBackground() Style", "Style" );
				   
			}

			SystemParametersInfo ( SPI_SETDESKWALLPAPER, 0,
								 picturesPath,
								 SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE );
		}
	}
}
