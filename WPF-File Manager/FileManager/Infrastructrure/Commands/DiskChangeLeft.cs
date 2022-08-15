using FileManager.Infrastructrure.Commands.Base;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Infrastructrure.Commands
{
    internal class DiskChangeLeft : Command
    {
        public override bool CanExecute(object? parameter) => true;
        public override void Execute(object? parameter)
        {
            if (FileManagerClass.GetInstance().FilePanelLeft.CurDir.Root.Name == (string)parameter)
                return;
            FileManagerClass.GetInstance().FilePanelLeft.CurDir = new DirectoryInfo((string)parameter);
        }
    }
}
