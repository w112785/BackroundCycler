/*
Copyright (c) 2007-2008, William Edward McCormick
Portians Copyright (c) 2007-2008, Mariusz Ficek

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Backround_Cycler.EventArguments;
using System.ComponentModel;
//using System.Linq;
//using System.Xml.Linq;

namespace Backround_Cycler.Core
{
    /// <summary>
    /// Stores the Lists of files and Files Not To Display, for the filelist
    /// </summary>
    [DefaultEvent ( "ListCleared" )]
    internal class FileList
    {
        #region Events
        public event EventHandler<FileAddedEventArgs> FileAdded;
        protected virtual void OnFileAdded ( FileAddedEventArgs e )
        {
            if (FileAdded != null)
            {
                FileAdded ( this, e );
            }
        }

        public event EventHandler<FileRemovedEventArgs> FileRemoved;
        protected virtual void OnFileRemoved ( FileRemovedEventArgs e )
        {
            if (FileRemoved != null)
            {
                FileRemoved ( this, e );
            }
        }

        public event EventHandler ListCleared;
        protected virtual void OnClear ()
        {
            if (ListCleared != null)
            {
                ListCleared ( this, EventArgs.Empty );
            }
        }

        public event EventHandler<FileAddedEventArgs> FilesAdded;
        protected virtual void OnFilesAdded ( FileAddedEventArgs e )
        {
            if (FilesAdded != null)
            {
                FilesAdded ( this, e );
            }
        }
        #endregion //Events

        /// <summary>
        /// The Files in the ImageList.
        /// String in the file location and the Bool is true if it is on the web and false if it is not
        /// </summary>
        private Dictionary<string, bool> _Files;

        /// <summary>
        /// The location of the filelist
        /// </summary>
        private string FileName = Path.Combine ( ApplicationInfo.localDataPath, "FileList.dat" );

        /// <summary>
        /// Gets the Files That will be displayed count
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return (_Files.Count);
            }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FileList"/> class.
        /// </summary>
        public FileList ()
        {
            _Files = new Dictionary<string, bool> ();
        }

        #endregion // Constructors

        /// <summary>
        /// Looks to see if the File string is in the File list.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public int FindFile ( string file )
        {
            string[] keys = null;
            _Files.Keys.CopyTo ( keys, 0 );
            for (int x = 0; x <= keys.Length; x++)
            {
                if (string.Equals ( keys[x], file ))
                    return x;
            }
            return -1;
        }

        /// <summary>
        /// Removes the file.
        /// </summary>
        /// <param name="file">The file.</param>
        public void Remove ( string file )
        {
            //if (_Files.Contains ( file ))
            if (_Files.ContainsKey ( file ))
                _Files.Remove ( file );
            else
                return;
            OnFileRemoved ( new FileRemovedEventArgs ( file ) );
        }

        public bool Contains ( string file )
        {
            return _Files.ContainsKey ( file );
        }

        /// <summary>
        /// Removes the file.
        /// </summary>
        /// <param name="item">The ListViewItem.</param>
        [Obsolete]
        public void RemoveFile ( ListViewItem item )
        {
            this.Remove ( item.Text );
        }

        /// <summary>
        /// Adds the file to the ImageList.
        /// </summary>
        /// <param name="file">The file.</param>
        public void Add ( string file )
        {
            if (!_Files.ContainsKey ( file ))
            {
                string ext = file.Substring ( file.LastIndexOf ( "." ) );

                if (".jpg .bmp .gif .png .jpeg".IndexOf ( ext.ToLower () ) > -1 &&
                               !file.Equals ( "backroundcycler.bmp" ))
                {
                    _Files.Add ( file, false );
                    OnFileAdded ( new FileAddedEventArgs ( file ) );
                }
            }
        }

        /// <summary>
        /// Adds the files to the ImageList.
        /// </summary>
        /// <param name="files">The files.</param>
        [Obsolete]
        internal void AddFiles ( string[] files )
        {
            foreach (string file in files)
            {
                Add ( file );
            }
        }

        /// <summary>
        /// Adds the files from folder.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <param name="opt">The Search Option.</param>
        internal void AddFilesFromFolder ( string Path, SearchOption opt )
        {
            FileInfo[] Files = null;
            DirectoryInfo[] subDirs = null;
            DirectoryInfo root = new DirectoryInfo ( Path );
            List<string> FilesAdded = new List<string> ();

            // First, process all the files directly under this folder
            try
            {
                Files = root.GetFiles ( "*.*" );
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }

            if (Files != null)
            {
                foreach (FileInfo fi in Files)
                {
                    int number = fi.FullName.LastIndexOf ( '.' );
                    if (number < 0)
                        continue;
                    string ext = fi.FullName.Substring ( number );
                    if (".jpg .bmp .gif .png .jpeg".IndexOf ( ext.ToLower () ) > -1 &&
                            !fi.FullName.EndsWith ( "backroundcycler.bmp" ) &&
                            !_Files.ContainsKey ( fi.FullName ) &&
                            File.Exists ( fi.FullName ))
                    {
                        _Files.Add ( fi.FullName, false );
                        FilesAdded.Add ( fi.FullName );
                    }
                }

                if (FilesAdded.Count >= 1)
                {
                    OnFilesAdded ( new FileAddedEventArgs ( FilesAdded.ToArray () ) );
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories ();
                if (opt == SearchOption.AllDirectories)
                {
                    foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                    {
                        if (!dirInfo.FullName.StartsWith ( Environment.GetFolderPath (
                            Environment.SpecialFolder.ApplicationData ) ) &&
                            !dirInfo.FullName.StartsWith ( Environment.GetFolderPath (
                            Environment.SpecialFolder.LocalApplicationData ) ))
                        {
                            // Resursive call for each subdirectory.
                            AddFilesFromFolder ( dirInfo.FullName, opt );
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the files in the imagelist and not in the Do not Display list
        /// </summary>
        /// <returns></returns>
        // code by Mariusz Ficek
        // Mild Adaptations William McCormick
        internal string[] GetFiles ()
        {
            //string[] files = _Files.ToArray ();
            if (_Files.Count == 0) { throw new FileNotFoundException ( "No Files In FileList" ); }
            string[] keys = new string[_Files.Count];
            int x = 0;
            foreach (KeyValuePair<string, bool> key in _Files)
            {
                keys[x] = key.Key;
                x++;
            }
            return keys;
        }

        /// <summary>
        /// Saves FileList to file.
        /// </summary>
        // TODOHI: Turn into a XML file and make the .DAT obsolete
        internal void SaveToFile ()
        {
            if (_Files.Count != 0)
            {
                if (File.Exists ( FileName ))
                {
                    File.Delete ( FileName );
                }
                StreamWriter sw = new StreamWriter ( FileName, false, Encoding.UTF8 );
                foreach (KeyValuePair<string,bool> line in _Files)
                {
                    sw.WriteLine ( line.Key );
                }
                sw.Close ();
            }
        }

        /// <summary>
        /// Loads FileList from file.
        /// </summary>
        internal void LoadFromFile ()
        {
            if (!File.Exists ( FileName ))
            {
                return;
            }
            else
            {
                StreamReader sr = new StreamReader ( FileName, Encoding.UTF8 );
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine ();
                    if (line == "Images Not Displayed:")
                    {
                        break;
                    }
					if (File.Exists (line))
					{
						_Files.Add (line, false);
						OnFileAdded (new FileAddedEventArgs (line));
					}
                }
            }
        }

        /// <summary>
        /// Clears the FileLists
        /// </summary>
        public void Clear ()
        {
            _Files.Clear ();
            OnClear ();
        }

        /// <summary>
        /// Checks for empty list.
        /// </summary>
        internal void CheckForEmptyList ()
        {
        //    legacy code from Winforms commented for testing
        //    if (Count.Equals ( 0 ))
        //    {
        //        SearchOption opt;
        //        if (ApplicationInfo.MainForm.behaviorSettings1.IsSubfoldersSelected)
        //        {
        //            opt = SearchOption.AllDirectories;
        //        }
        //        else
        //        {
        //            opt = SearchOption.TopDirectoryOnly;
        //        }
        //        this.AddFilesFromFolder ( ApplicationInfo.settings.PicturesFolder, opt );
        //    }
        }
    }
}