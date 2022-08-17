using System.Windows;
using FileManager.Infrastructrure.Commands.Base;

namespace FileManager.Infrastructrure.Commands
{
    /// <summary>
    /// Команда "Завершение работы"
    /// </summary>
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object? parameter) => true;
        public override void Execute(object? parameter) => Application.Current.Shutdown();
    }
}
