using FileManager.Infrastructrure;
using FileManager.Infrastructrure.Commands;
using FileManager.Models;
using FileManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileManager.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            #region Подписываемся на события (изменеие состояния текущих каталогов)
            FileManagerClass.GetInstance().FilePanelLeft.DirChanged += FilePanelLeft_DirChanged;
            FileManagerClass.GetInstance().FilePanelRight.DirChanged += FilePanelRight_DirChanged;
            #endregion
        }

        private void FilePanelRight_DirChanged(object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(FileTableListRight));
            OnPropertyChanged(nameof(RightPanelCurrentDir));
        }

        private void FilePanelLeft_DirChanged(object? sender, System.EventArgs e)
        {
            OnPropertyChanged(nameof(FileTableListLeft));
            OnPropertyChanged(nameof(LeftPanelCurrentDir));
        }

        public IEnumerable<FileTableList> FileTableListLeft { get => FileManagerClass.GetInstance().FilePanelLeft.GetFileList(); }
        public IEnumerable<FileTableList> FileTableListRight { get => FileManagerClass.GetInstance().FilePanelRight.GetFileList(); }
        public IEnumerable<DriveInfo> Drives { get => FileManagerClass.GetInstance().DrivePanel.DrivesList; }
        public string LeftPanelCurrentDir
        {
            get => FileManagerClass.GetInstance().FilePanelLeft.CurDir.FullName;
            set
            {
                if (LeftPanelCurrentDir == value) return;
                if (Directory.Exists(value))
                    FileManagerClass.GetInstance().FilePanelLeft.CurDir = new DirectoryInfo(value);
                OnPropertyChanged(nameof(LeftPanelCurrentDir));
            }
        }
        public string RightPanelCurrentDir
        {
            get => FileManagerClass.GetInstance().FilePanelRight.CurDir.FullName;
            set
            {
                if (RightPanelCurrentDir == value) return;
                if (Directory.Exists(value))
                    FileManagerClass.GetInstance().FilePanelRight.CurDir = new DirectoryInfo(value);
                OnPropertyChanged(nameof(RightPanelCurrentDir));
            }
        }

        #region Объявление команд файлового менеджера
        public CloseApplicationCommand CloseApplicationCommand { get => new CloseApplicationCommand(); }
        public ExercuteFileCommand ExercuteFileCommand { get => new ExercuteFileCommand(); }
        public RemoveFileCommand RemoveFileCommand { get => new RemoveFileCommand(); }
        public ViewCommand ViewCommand { get => new ViewCommand(); }
        public CopyFileCommand CopyFileCommand { get => new CopyFileCommand(); }
        public MoveFileCommand MoveFileCommand { get => new MoveFileCommand(); }
        public CreateDirrectoryCommand CreateDirrectoryCommand { get => new CreateDirrectoryCommand(); }
        public CreateFileCommand CreateFileCommand { get => new CreateFileCommand(); }
        public AboutCommand AboutCommand { get => new AboutCommand(); }
        #endregion

    }
}
