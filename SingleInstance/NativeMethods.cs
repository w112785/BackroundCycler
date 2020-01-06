using System;
using System.Runtime.InteropServices;

namespace SingleInstance
{
	internal static class NativeMethods
	{
		/// <summary>
		/// This is for The API code DO NOT MODIFY unless you know what you are DOING 
		/// </summary>
		internal const int SW_RESTORE = 9;

		/// <summary>
		/// The ShowWindow function sets the specified window's show state.
		/// </summary>
		/// 
		/// <param name="hWnd">Handle to the window.</param>
		/// 
		/// <param name="nCmdShow">Specifies how the window is to be shown.
		/// This parameter is ignored the first time an application calls
		/// ShowWindow, if the program that launched the application
		/// provides a STARTUPINFO structure. Otherwise, the first time
		/// ShowWindow is called, the value should be the value obtained by
		/// the WinMain function in its nCmdShow parameter.</param>
		/// 
		/// <returns>If the window was previously visible, the return value
		/// is nonzero.</returns>
		[DllImport ( "user32.dll" )]
		internal static extern int ShowWindow ( IntPtr hWnd, int nCmdShow );

		/// <summary>
		/// The SetForegroundWindow function puts the thread that
		/// created the specified window into the foreground and
		/// activates the window. Keyboard input is directed to the
		/// window, and various visual cues are changed for the user.
		/// The system assigns a slightly higher priority to the thread
		/// that created the foreground window than it does to other threads.
		/// </summary>
		/// 
		/// <param name="hWnd">Handle to the window that should be activated
		/// and brought to the foreground.</param>
		/// 
		/// <returns>If the window was brought to the foreground, the return
		/// value is nonzero.</returns>
		[DllImport ( "user32.dll" )]
		internal static extern int SetForegroundWindow ( IntPtr hWnd );

		/// <summary>
		/// The IsIconic function determines whether the specified
		/// window is minimized (iconic).
		/// </summary>
		/// 
		/// <param name="hWnd">Handle to the window to test.</param>
		/// 
		/// <returns>If the window is iconic, the return value is
		/// nonzero.</returns>
		[DllImport ( "user32.dll" )]
		[return: MarshalAs ( UnmanagedType.Bool )]
		internal static extern bool IsIconic ( IntPtr hWnd );
	}
}
