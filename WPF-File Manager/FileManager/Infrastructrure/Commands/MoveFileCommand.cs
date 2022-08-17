using FileManager.Infrastructrure.Commands.Base;
using FileManager.Models;
using System;
using System.IO;
using System.Windows;

namespace FileManager.Infrastructrure.Commands
{
    /// <summary>
    /// Команда "Перемещение файлов и каталогов"
    /// </summary>
    internal class MoveFileCommand : Command
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
            if (FileManagerClass.GetInstance().ActivePanel.FilesSelected.Count == 0) return;

            DirectoryInfo DestinationDir;
            if (FileManagerClass.GetInstance().ActivePanel == FileManagerClass.GetInstance().FilePanelRight)
                DestinationDir = FileManagerClass.GetInstance().FilePanelLeft.CurDir;
            else
                DestinationDir = FileManagerClass.GetInstance().FilePanelRight.CurDir;

            #region заблокируем события от изменений в текущих каталогов
            FileManagerClass.GetInstance().FilePanelLeft.EnableEvents = false;
            FileManagerClass.GetInstance().FilePanelRight.EnableEvents = false;
            #endregion

            foreach (var item in FileManagerClass.GetInstance().ActivePanel.FilesSelected)
            {
                FileSystemInfo fileSystemInfo = ((FileTableList)item).FileSystemInfo;
                if (FileManagerClass.GetInstance().ActivePanel.CurDir.Parent?.FullName == fileSystemInfo.FullName) continue;
                if (fileSystemInfo is FileInfo)
                {
                    try
                    {
                        File.Move(fileSystemInfo.FullName, Path.Combine(DestinationDir.FullName, fileSystemInfo.Name));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Ошибка при перемещении файла: {fileSystemInfo.FullName}");
                    }
                    continue;
                }
                if (fileSystemInfo is DirectoryInfo)
                {
                    try
                    {
                        MoveDir((DirectoryInfo)fileSystemInfo, DestinationDir);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Ошибка при копировании каталога: {fileSystemInfo.FullName}");
                    }

                }
            }
            FileManagerClass.GetInstance().UpdateCurDirs();
        }


        /// <summary>
        /// Рекурсивный метод переноса каталогов
        /// </summary>
        /// <param name="SourceDir"></param>
        /// <param name="DestinationDir"></param>
        private void MoveDir(DirectoryInfo SourceDir, DirectoryInfo DestinationDir)
        {
            DirectoryInfo new_dir = new(Path.Combine(DestinationDir.FullName, SourceDir.Name));
            try
            {
                Directory.CreateDirectory(new_dir.FullName);

            }
            catch (Exception)
            {
                MessageBox.Show($"Ошибка при создании каталога: {new_dir.FullName}");
            }

            foreach (var file in SourceDir.GetFiles())
            {
                try
                {
                    File.Move(file.FullName, Path.Combine(new_dir.FullName, file.Name));
                }
                catch (Exception)
                {
                    MessageBox.Show($"Ошибка при перемещении файла: {file.FullName}");
                }
            }
            foreach (var dir in SourceDir.GetDirectories())
            {
                MoveDir(dir, new_dir);
            }
            Directory.Delete(SourceDir.FullName, false);
        }
    }
}
