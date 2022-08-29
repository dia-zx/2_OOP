using FileManager.Infrastructrure.Commands.Base;
using FileManager.Models;
using System.Diagnostics;
using System.IO;

namespace FileManager.Infrastructrure.Commands
{
    /// <summary>
    /// Команда "Запуск файла на исполнение"
    /// </summary>
    internal class ExercuteFileCommand : Command
    {
        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            if (parameter == null) return;
            FilePanel filePanel;
            if (Equals(parameter, "Left"))
                filePanel = FileManagerClass.GetInstance().FilePanelLeft;
            else
                filePanel = FileManagerClass.GetInstance().FilePanelRight;
            if (filePanel.FilesSelected.Count != 1) return;

            if (((FileTableList)filePanel.FilesSelected[0]).FileSystemInfo is DirectoryInfo)
            {
                filePanel.CurDir = (DirectoryInfo)((FileTableList)filePanel.FilesSelected[0]).FileSystemInfo;
                return;
            }
            ProcessStartInfo startInfo = new ProcessStartInfo(((FileTableList)filePanel.FilesSelected[0]).FileSystemInfo.FullName);
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }
    }
}