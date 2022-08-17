using FileManager.Infrastructrure.Commands.Base;
using FileManager.Views.Windows;

namespace FileManager.Infrastructrure.Commands
{
    internal class AboutCommand : Command
    {
        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter) => new About().Show();
    }
}
