using FileManager.Infrastructrure.Commands.Base;
using FileManager.Models;
using FileManager.Views.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileManager.Infrastructrure.Commands
{
    internal class CopyFileCommand : Command
    {
        public override bool CanExecute(object? parameter)
        {
            if (FileManagerClass.GetInstance().ActivePanel == null) return false;
            if ((FileManagerClass.GetInstance().ActivePanel.FilesSelected == null)
               || (FileManagerClass.GetInstance().ActivePanel.FilesSelected.Count == 0))
                return false;
            #region проверка на родительский каталог (..)
            if (FileManagerClass.GetInstance().ActivePanel.FilesSelected.Count == 1 &&
        FileManagerClass.GetInstance().ActivePanel.CurDir.Parent != null &&
        FileManagerClass.GetInstance().ActivePanel.CurDir.Parent.FullName
            == ((FileTableList)FileManagerClass.GetInstance().ActivePanel.FilesSelected[0]).FileSystemInfo.FullName)
                return false; 
            #endregion
            return true;
        }

        public override void Execute(object? parameter)
        {
            if (FileManagerClass.GetInstance().ActivePanel == null) return;
            if (FileManagerClass.GetInstance().ActivePanel.FilesSelected == null) return;

            DirectoryInfo DestinationDir;
            if (FileManagerClass.GetInstance().ActivePanel == FileManagerClass.GetInstance().FilePanelRight)
                DestinationDir = FileManagerClass.GetInstance().FilePanelLeft.CurDir;
            else
                DestinationDir = FileManagerClass.GetInstance().FilePanelRight.CurDir;

            foreach (var item in FileManagerClass.GetInstance().ActivePanel.FilesSelected)
            {
                FileSystemInfo fileSystemInfo = ((FileTableList)item).FileSystemInfo;
                if (FileManagerClass.GetInstance().ActivePanel.CurDir.Parent?.FullName == fileSystemInfo.FullName) continue;
                try
                {
                    if (fileSystemInfo is FileInfo)
                    {
                        File.Copy(fileSystemInfo.FullName, Path.Combine(DestinationDir.FullName, fileSystemInfo.Name));
                        continue;
                    }
                    if (fileSystemInfo is DirectoryInfo)
                    {
                        CopyDir((DirectoryInfo)fileSystemInfo, DestinationDir);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        private void CopyDir(DirectoryInfo SourceDir, DirectoryInfo DestinationDir)
        {
            DirectoryInfo new_dir = new(Path.Combine(DestinationDir.FullName, SourceDir.Name));
            Directory.CreateDirectory(new_dir.FullName);
            foreach (var file in SourceDir.GetFiles())
            {
                File.Copy(file.FullName, Path.Combine(new_dir.FullName, file.Name));
            }
            foreach (var dir in SourceDir.GetDirectories() )
            {
                CopyDir(dir, new_dir);
            }
        }
    }
}
