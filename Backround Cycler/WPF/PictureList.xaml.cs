using System;
using System.Windows;
using System.Windows.Controls;
using frm = System.Windows.Forms;
using Backround_Cycler.Core;
using Backround_Cycler.EventArguments;

namespace Backround_Cycler.WPF
{
    /// <summary>
    /// Interaction logic for PictureList.xaml
    /// </summary>
    public partial class PictureList : UserControl
    {
        private frm.FolderBrowserDialog folderBrowserDialog = new frm.FolderBrowserDialog ();
        private frm.OpenFileDialog openFileDialog = new frm.OpenFileDialog ();
        private FileList fileList = new FileList ();

        public PictureList ()
        {
            InitializeComponent ();

            folderBrowserDialog.Description = "Chose A Folder To Load The Images From";
            folderBrowserDialog.ShowNewFolderButton = false;
            folderBrowserDialog.SelectedPath = ApplicationInfo.settings.PicturesFolder;

            openFileDialog.SupportMultiDottedExtensions = true;
            openFileDialog.Multiselect = true;
            openFileDialog.Filter =
                "Compatible Files | *.jpg; *.bmp; *.gif; *.png; *.jpeg | All Files (*.*) | *.*";

            fileList.FileAdded += new EventHandler<FileAddedEventArgs> (fileList_FileAdded);
            fileList.FileRemoved += new EventHandler<FileRemovedEventArgs> (fileList_FileRemoved);
            fileList.FilesAdded += new EventHandler<FileAddedEventArgs> (fileList_FilesAdded);

        }

        private void LoadFolder_Click (object sender, RoutedEventArgs e)
        {
            /*
             folderBrowserDialog1.SelectedPath = ApplicationInfo.settings.PicturesFolder;

			if (folderBrowserDialog1.ShowDialog () == DialogResult.Cancel)
			{
				return;
			}
			ApplicationInfo.settings.PicturesFolder = folderBrowserDialog1.SelectedPath;

			HandleThreads.StartOneThread ("load file from folder", new System.Threading.ThreadStart (
			AddFilesFromFolder));
             */

            folderBrowserDialog.SelectedPath = ApplicationInfo.settings.PicturesFolder;

            if (folderBrowserDialog.ShowDialog () == frm.DialogResult.Cancel)
            {
                return;
            }
            ApplicationInfo.settings.PicturesFolder = folderBrowserDialog.SelectedPath;

        }

        private void LoadFile_Click (object sender, RoutedEventArgs e)
        {
        }

        #region FileList Events

        void fileList_FilesAdded (object sender, FileAddedEventArgs e)
        {
            throw new NotImplementedException ();
        }

        void fileList_FileRemoved (object sender, FileRemovedEventArgs e)
        {
            throw new NotImplementedException ();
        }

        void fileList_FileAdded (object sender, EventArguments.FileAddedEventArgs e)
        {
            ListViewItem lvi = new ListViewItem ();
            lvi.Content = e.FilePath;
            listView1.Items.Add (lvi);
        }

        #endregion
    }
}
