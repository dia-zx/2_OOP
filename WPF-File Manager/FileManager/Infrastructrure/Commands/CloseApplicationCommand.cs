using System.Windows;
using FileManager.Infrastructrure.Commands.Base;

namespace FileManager.Infrastructrure.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object? parameter) => true;
        public override void Execute(object? parameter) => Application.Current.Shutdown();
    }
}
