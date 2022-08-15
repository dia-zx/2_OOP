using FileManager.Infrastructrure.Commands.Base;
using FileManager.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Infrastructrure.Commands
{
    internal class ExercuteFileCommand : Command
    {
        public override bool CanExecute(object? parameter) =>true;

        public override void Execute(object? parameter)
        {
            if(parameter == null) return;
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