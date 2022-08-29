using FileManager.Infrastructrure.Commands.Base;
using FileManager.Models;
using FileManager.Views.Windows;
using System;
using System.IO;
using System.Windows;

namespace FileManager.Infrastructrure.Commands
{
    /// <summary>
    /// Команда "Удаление файлов и каталогов"
    /// </summary>
    internal class RemoveFileCommand : Command
    {
        public override bool CanExecute(object? parameter)
        {
            #region проверим, что есть оттмеченные файлы
            if (FileManagerClass.GetInstance().ActivePanel == null) return false;
            if ((FileManagerClass.GetInstance().ActivePanel.FilesSelected == null)
               || (FileManagerClass.GetInstance().ActivePanel.FilesSelected.Count == 0))
                return false;
            #endregion

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

            if (new ConfirmDialog().ShowDialog() == false) return;

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
                        File.Delete(fileSystemInfo.FullName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Ошибка при удалении файла: {fileSystemInfo.FullName}");
                    }
                    continue;
                }
                if (fileSystemInfo is DirectoryInfo)
                {
                    try
                    {
                        Directory.Delete(fileSystemInfo.FullName, true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Ошибка при удалении каталога: {fileSystemInfo.FullName}");
                    }
                }
            }
            FileManagerClass.GetInstance().UpdateCurDirs();
        }
    }
}
