/*
Copyright (c) 2007-2008, Mariusz Ficek
Portions Copyright (c) 2008-2009, William Edward McCormick

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;
using Backround_Cycler.EventArguments;
using Backround_Cycler.Core;

namespace Backround_Cycler.Control
{
	/// <summary>
	/// Control that displayes the list of images in the FileList
	/// </summary>
	public partial class ImageList : UserControl
	{
		public event EventHandler redraw;
		protected virtual void OnRedraw ()
		{

			if (redraw != null)
				redraw.Invoke (this, EventArgs.Empty);
				// redraw (this, EventArgs.Empty);
		}

		internal int FileListCount { get { return ltvFiles.Items.Count; } }
		// Added by William Edward McCormick - Monday, November 19, 2007
		internal ListView Files { get { return ltvFiles; } }

		private FileList fileList;

		public string[] GetFiles { get { return this.fileList.GetFiles (); } }

		private Backround_Cycler.Properties.Settings settings { get { return ApplicationInfo.settings; } }

		#region Class Functions

		/// <summary>
		/// Initializes a new instance of the <see cref="ImageList"/> class.
		/// </summary>
		public ImageList ()
		{
			InitializeComponent ();

			folderBrowserDialog1.SelectedPath = ApplicationInfo.settings.PicturesFolder;
			openFileDialog1.Filter =
				"Compatible Files | *.jpg; *.bmp; *.gif; *.png; *.jpeg | All Files (*.*) | *.*";

			fileList = new FileList ();
			fileList.FileAdded += new EventHandler<FileAddedEventArgs> (fileList_FileAdded);
			fileList.FileRemoved +=
				new EventHandler<FileRemovedEventArgs> (fileList_FileRemoved);
			fileList.ListCleared += new EventHandler (fileList_ListCleared);
			fileList.FilesAdded += new EventHandler<FileAddedEventArgs> (fileList_FilesAdded);
			fileList.LoadFromFile ();
		}

		void fileList_FilesAdded ( object sender, FileAddedEventArgs e )
		{
			if (InvokeRequired)
			{
				this.Invoke (new EventHandler<FileAddedEventArgs> (fileList_FilesAdded), sender, e);
			}
			else
			{
				foreach (string FilePath in e.GetFiles)
				{
					ListViewItem File = new ListViewItem (FilePath);
					ltvFiles.Items.Add (File);
				}
			}
		}

		/// <summary>
		/// Handles the ListCleared event of the fileList control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		void fileList_ListCleared ( object sender, EventArgs e )
		{
			ltvFiles.Items.Clear ();
		}

		/// <summary>
		/// Handles the FileRemoved event of the fileList control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="Backround_Cycler.EventArguments.FileRemovedEventArgs"/> instance containing the event data.</param>
		void fileList_FileRemoved ( object sender, FileRemovedEventArgs e )
		{
			// ListViewItem[] foundItems = ltvFiles.Items.Find ( e.FilePath, true );
			ListViewItem foundItems = ltvFiles.FindItemWithText (e.FilePath, true, 0);
			if (foundItems != null)
			{
				foundItems.Remove ();
			}
			// ltvFiles.Items.RemoveByKey ( e.FilePath );
		}

		/// <summary>
		/// Handles the FileAdded event of the fileList control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="Backround_Cycler.EventArguments.FileAddedEventArgs"/> instance containing the event data.</param>
		void fileList_FileAdded ( object sender, Backround_Cycler.EventArguments.FileAddedEventArgs e )
		{
			if (InvokeRequired)
			{
				this.Invoke (new EventHandler<FileAddedEventArgs> (fileList_FileAdded), sender, e);
			}
			else
			{
				ListViewItem File = new ListViewItem (e.FilePath);
				ltvFiles.Items.Add (File);
			}
		}

		/// <summary>
		/// Get list of image files from folder.
		/// </summary>
		/// <param name="filteredFiles">List of files</param>
		/// <returns>Files count</returns>
		// major edit to work around code changes William Edward McCormick, Sunday, December 02, 2007
		private void GetFileListFromFolder ()
		{
			folderBrowserDialog1.SelectedPath = ApplicationInfo.settings.PicturesFolder;

			if (folderBrowserDialog1.ShowDialog () == DialogResult.Cancel)
			{
				return;
			}
			ApplicationInfo.settings.PicturesFolder = folderBrowserDialog1.SelectedPath;

			HandleThreads.StartOneThread ("load file from folder", new System.Threading.ThreadStart (
			AddFilesFromFolder));
		}

		private void AddFilesFromFolder ()
		{
			SearchOption opt;
			if (ApplicationInfo.MainForm.behaviorSettings1.IsSubfoldersSelected)
				opt = SearchOption.AllDirectories;
			else
				opt = SearchOption.TopDirectoryOnly;

			fileList.AddFilesFromFolder (
				folderBrowserDialog1.SelectedPath, opt);

			fileList.SaveToFile ();
		}

		#endregion //Class Fuction

		/// <summary>
		/// Handles the Click event of the Save button.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnSave_Click ( object sender, EventArgs e )
		{
			fileList.SaveToFile ();
		}

		/// <summary>
		/// Handles the Click event of the LoadFolder button.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnLoadFolder_Click ( object sender, EventArgs e )
		{
			GetFileListFromFolder ();
		}

		/// <summary>
		/// Handles the Click event of the LoadFile button.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnLoadFile_Click ( object sender, EventArgs e )
		{
			openFileDialog1.InitialDirectory = ApplicationInfo.settings.PicturesFolder;
			if (openFileDialog1.ShowDialog (ApplicationInfo.MainForm) != DialogResult.Cancel)
			{
				// fileList.AddFiles ( openFileDialog1.FileNames );

				foreach (string file in openFileDialog1.FileNames)
				{
					fileList.Add (file);
				}

			}
			fileList.SaveToFile ();
		}

		/// <summary>
		/// Handles the Click event of the Clear button.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnClear_Click ( object sender, EventArgs e )
		{
			fileList.Clear ();
		}

		private void deleteSelectedToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			DeleteSelected ();
		}

		internal void ChangeDesktopBackground ()
		{
			lock (this)
			{
				ChangeBackground.ChangingBackground = true;
				using (ChangeBackground = new ChangeBackground (fileList.GetFiles ()))
				{
					ChangeBackground.ChangeDesktopBackground ();
				}
				ChangeBackground.ChangingBackground = false;
			}
			this.OnRedraw ();
		}

		private void ltvFiles_KeyDown ( object sender, KeyEventArgs e )
		{
			if (e.KeyCode == Keys.Delete)
			{
				DeleteSelected ();
			}
		}

		private void DeleteSelected ()
		{
			ListView.SelectedListViewItemCollection selectedItems = ltvFiles.SelectedItems;
			foreach (ListViewItem item in selectedItems)
			{
				fileList.Remove (item.Text);
				//  item.Remove ();
			}

			fileList.SaveToFile ();
		}

		public void LoadList ()
		{
			fileList.LoadFromFile ();
		}

		public void CheckForEmptyList ()
		{
			fileList.CheckForEmptyList ();
		}

		// only here for the class diagram
		internal Backround_Cycler.Core.ChangeBackground ChangeBackground { get; set; }
	}
}
