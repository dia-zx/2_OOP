using FileManager.Infrastructrure.Commands.Base;
using FileManager.Views.Windows;
using System;
using System.IO;
using System.Windows;

namespace FileManager.Infrastructrure.Commands
{
    /// <summary>
    /// Команда "Создание файла"
    /// </summary>
    internal class CreateFileCommand : Command
    {
        public override bool CanExecute(object? parameter)
        {
            if (FileManagerClass.GetInstance().ActivePanel == null) return false;
            if (FileManagerClass.GetInstance().ActivePanel.CurDir == null) return false;
            return true;
        }

        public override void Execute(object? parameter)
        {
            if (FileManagerClass.GetInstance().ActivePanel == null) return;
            if (FileManagerClass.GetInstance().ActivePanel.CurDir == null) return;
            var dialog = new InputDialog();
            dialog.DialogText.Text = "Введите название файла.";
            if (dialog.ShowDialog() == false) return;
            if (dialog.UserTextBox.Text == String.Empty) return;

            #region заблокируем события от изменений в текущих каталогов
            FileManagerClass.GetInstance().FilePanelLeft.EnableEvents = false;
            FileManagerClass.GetInstance().FilePanelRight.EnableEvents = false;
            #endregion

            try
            {
                File.Create(
                    Path.Combine(FileManagerClass.GetInstance().ActivePanel.CurDir.FullName, dialog.UserTextBox.Text));
            }
            catch
            {
                MessageBox.Show($"Ошибка при создании файла {dialog.UserTextBox.Text}");
            }
            FileManagerClass.GetInstance().UpdateCurDirs();
        }
    }
}
