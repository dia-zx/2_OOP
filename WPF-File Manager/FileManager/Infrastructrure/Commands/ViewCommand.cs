using FileManager.Infrastructrure.Commands.Base;
using FileManager.Models;
using System.Diagnostics;
using System.IO;

namespace FileManager.Infrastructrure.Commands
{
    /// <summary>
    /// Команда "Открытие файла в редакторе 'notepad'"
    /// </summary>
    internal class ViewCommand : Command
    {
        public override bool CanExecute(object? parameter)
        {
            if (FileManagerClass.GetInstance().ActivePanel == null) return false;
            if (FileManagerClass.GetInstance().ActivePanel.FilesSelected?.Count != 1) return false;
            return ((FileTableList)(FileManagerClass.GetInstance().ActivePanel.FilesSelected[0])).FileSystemInfo is FileInfo;
        }

        public override void Execute(object? parameter)
        {

            ProcessStartInfo startInfo = new ProcessStartInfo("notepad.exe",
                ((FileTableList)(FileManagerClass.GetInstance().ActivePanel.FilesSelected[0])).FileSystemInfo.FullName);
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }
    }
}
