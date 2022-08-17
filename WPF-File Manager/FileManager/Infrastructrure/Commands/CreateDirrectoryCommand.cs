using FileManager.Infrastructrure.Commands.Base;
using FileManager.Views.Windows;
using System;
using System.IO;
using System.Windows;

namespace FileManager.Infrastructrure.Commands
{
    /// <summary>
    /// Команда "Создание дирректории"
    /// </summary>
    internal class CreateDirrectoryCommand : Command
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
            dialog.DialogText.Text = "Введите название дирректории.";
            if (dialog.ShowDialog() == false) return;
            if (dialog.UserTextBox.Text == String.Empty) return;

            #region заблокируем события от изменений в текущих каталогов
            FileManagerClass.GetInstance().FilePanelLeft.EnableEvents = false;
            FileManagerClass.GetInstance().FilePanelRight.EnableEvents = false;
            #endregion

            try
            {
                Directory.CreateDirectory(
                    Path.Combine(FileManagerClass.GetInstance().ActivePanel.CurDir.FullName, dialog.UserTextBox.Text));
            }
            catch
            {
                MessageBox.Show($"Ошибка при создании каталога {dialog.UserTextBox.Text}");
            }
            FileManagerClass.GetInstance().UpdateCurDirs();
        }
    }
}
