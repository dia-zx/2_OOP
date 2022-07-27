using FileManager.ViewModels.Base;
using FileManager.Infrastructrure.Commands;


namespace FileManager.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public CloseApplicationCommand CloseApplicationCommand { get => new CloseApplicationCommand(); }

    }
}
