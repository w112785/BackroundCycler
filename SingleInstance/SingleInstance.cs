/*
Copyright (c) 2006-2017, William Edward McCormick

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace SingleInstance
{
	/// <summary>
	/// class to handle making a application a single instance Application
	/// </summary>
	public static class SingleApplication
    {
        private static Mutex mutex;

        /// <summary>
        /// Gets the Current Instance Process ID (Window Handle)
        /// </summary>
        /// 
        /// <returns> int* process ID for the already running process</returns>
        private static IntPtr GetCurrentInstanceWindowHandle ()
        {
            IntPtr hWnd = IntPtr.Zero;
            Process process = Process.GetCurrentProcess ();
            Process[] processes = Process.GetProcessesByName ( process.ProcessName );

            foreach (Process _process in processes)
            {
                // Get the first instance that is not this instance, has the
                // same process name and was started from the same file name
                // and location. Also check that the process has a valid
                // window handle in this session to filter out other user's
                // processes.
                if (_process.Id != process.Id &&
                    _process.MainModule.FileName == process.MainModule.FileName
                    && _process.MainWindowHandle != IntPtr.Zero)
                {
                    hWnd = _process.MainWindowHandle;
                    break;
                }
            }
            return hWnd;
        }

        /// <summary>
        /// SwitchToCurrentInstance
        /// </summary>
        private static void SwitchToCurrentInstance ()
        {
            IntPtr hWnd = GetCurrentInstanceWindowHandle ();
            if (hWnd != IntPtr.Zero)
            {
                // Restore window if minimised. Do not restore if already in
                // normal or maximised window state, since we don't want to
                // change the current state of the window.
                if (NativeMethods.IsIconic ( hWnd ))
                {
                    NativeMethods.ShowWindow ( hWnd, NativeMethods.SW_RESTORE );
                }

                // Set foreground window.
                NativeMethods.SetForegroundWindow ( hWnd );
            }
        }

        /// <summary>
        /// check if Already running
        /// </summary>
        /// 
        /// <param name="exeName">the name of the exe calling this DLL
        /// </param>
        /// 
        /// <returns>returns true if already running</returns>
        private static bool IsAlreadyRunning ( string exeName )
        {
            bool CreatedNew;

            mutex = new Mutex ( true, "Local\\" + exeName, out CreatedNew );
            if (CreatedNew)
            {
                mutex.ReleaseMutex ();
            }

            return !CreatedNew;
        }

        /// <summary>
        /// run the application, if not already running
        /// </summary>
        /// 
        /// <returns>true if the program was ran for the first time.
        /// false if it is already running</returns>
        public static bool Run ()
        {
            return Run ( Assembly.GetCallingAssembly ().Location );
        }

        /// <summary>
        /// run the application, if not already running
        /// </summary>
        /// 
        /// <param name="exeName">the name of the exe calling this DLL this is for 
        /// manual mutex naming ADVANCED</param>
        /// 
        /// <returns>true if the program was ran for the first time.
        /// false if it is already running</returns>
        public static bool Run ( string exeName )
        {
            if (IsAlreadyRunning ( exeName ))
            {
                return false;
            }
            else
            {
                Application.Run ();
                return true;
            }
        }

        /// <summary>
        /// run the application, if not already running
        /// </summary>
        /// 
        /// <param name="frmMain">The name if the main form. Must be a object</param>
        /// 
        /// <returns>true if the program was ran for the first time.
        /// false if it is already running</returns>
        public static bool Run ( Form frmMain )
        {
            return Run ( Assembly.GetCallingAssembly ().Location, frmMain );
        }

        /// <summary>
        /// run the application, if not already running
        /// </summary>
        /// <param name="exeName">the name of the exe calling this DLL this is for 
        /// manual mutex naming ADVANCED</param>
        /// 
        /// <param name="frmMain">The name if the main form. Must be a object
        /// </param>
        /// 
        /// <returns>
        /// true if the program was ran for the first time.
        /// false if it is already running
        /// </returns>
        public static bool Run ( string exeName, Form frmMain )
        {
            if (IsAlreadyRunning ( exeName ))
            {
                // set focus on previously running app
                SwitchToCurrentInstance ();
                return false;
            }
            else
            {
                Application.Run ( frmMain );
                return true;
            }
        }

        /// <summary>
        /// check if the application is not already running
        /// </summary>
        /// 
        /// <returns>true if the program was ran for the first time.
        /// false if it is already running</returns>
        public static bool CheckIfNotRunning ()
        {
            return CheckIfNotRunning ( Assembly.GetCallingAssembly ().Location );
        }

        /// <summary>
        /// check if the application is not already running
        /// </summary>
        /// 
        /// <param name="exeName">the name of the exe calling this DLL this is for 
        /// manual mutex naming ADVANCED</param>
        /// 
        /// <returns>
        /// true if the program was ran for the first time.
        /// false if it is already running
        /// </returns>
        public static bool CheckIfNotRunning ( string exeName )
        {
            if (IsAlreadyRunning ( exeName ))
            {
                return false;
            }
            return true;
        }
    }
}
