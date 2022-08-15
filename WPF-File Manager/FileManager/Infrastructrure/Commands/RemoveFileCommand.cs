using FileManager.Infrastructrure.Commands.Base;
using FileManager.Models;
using FileManager.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace FileManager.Infrastructrure.Commands
{
    internal class RemoveFileCommand : Command
    {
        public override bool CanExecute(object? parameter)
        {
            if (FileManagerClass.GetInstance().ActivePanel == null) return false;
            if ((FileManagerClass.GetInstance().ActivePanel.FilesSelected == null)
               || (FileManagerClass.GetInstance().ActivePanel.FilesSelected.Count == 0))
                return false;
            if (FileManagerClass.GetInstance().ActivePanel.FilesSelected.Count == 1 &&
                FileManagerClass.GetInstance().ActivePanel.CurDir.Parent != null &&
                FileManagerClass.GetInstance().ActivePanel.CurDir.Parent.FullName
                    == ((FileTableList)FileManagerClass.GetInstance().ActivePanel.FilesSelected[0]).FileSystemInfo.FullName)
                return false;
            return true;
        }

        public override void Execute(object? parameter)
        {
            if (FileManagerClass.GetInstance().ActivePanel == null) return;
            if (FileManagerClass.GetInstance().ActivePanel.FilesSelected == null) return;
            if (FileManagerClass.GetInstance().ActivePanel.FilesSelected.Count == 0) return;

            if (new ConfirmDialog().ShowDialog() == false) return;

            foreach (var item in FileManagerClass.GetInstance().ActivePanel.FilesSelected)
            {
                FileSystemInfo fileSystemInfo = ((FileTableList)item).FileSystemInfo;
                if (FileManagerClass.GetInstance().ActivePanel.CurDir.Parent?.FullName == fileSystemInfo.FullName) continue;
                try
                {
                    if (fileSystemInfo is FileInfo)
                    {
                        File.Delete(fileSystemInfo.FullName);
                        continue;
                    }
                    if (fileSystemInfo is DirectoryInfo)
                    {
                        Directory.Delete(fileSystemInfo.FullName, true);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }


        }
    }
}
