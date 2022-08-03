﻿using FileManager.ViewModels.Base;
using FileManager.Infrastructrure.Commands;
using FileManager.Infrastructrure;
using FileManager.Models;
using System.Collections;
using System.Collections.Generic;
using System;

namespace FileManager.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            FileManagerClass.GetInstance().FilePanelLeft.DirChanged += FilePanelLeft_DirChanged;
            FileManagerClass.GetInstance().FilePanelRight.DirChanged += FilePanelRight_DirChanged;
        }

        private void FilePanelRight_DirChanged(object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(FileTableListRight));
        }

        private void FilePanelLeft_DirChanged(object? sender, System.EventArgs e)
        {
            OnPropertyChanged(nameof(FileTableListLeft));
        }

        public IEnumerable<FileTableList> FileTableListLeft { get => FileManagerClass.GetInstance().FilePanelLeft.GetFileList(); }
        public IEnumerable<FileTableList> FileTableListRight { get => FileManagerClass.GetInstance().FilePanelRight.GetFileList(); }

   //     public IEnumerable<object> FileTableSelectedItemsLeft
   //     {
   //         get => FileManagerClass.GetInstance().FilePanelLeft.FilesSelected;
   ////         set => Set<IEnumerable<object>>(ref _FileTableListLeft, value);
   //     }



        public CloseApplicationCommand CloseApplicationCommand { get => new CloseApplicationCommand(); }
        public ExercuteFileCommand ExercuteFileCommand { get => new ExercuteFileCommand(); }

 //       private IEnumerable<object> _FileTableListLeft;
 //       private IEnumerable<object> _FileTableListRight;
    }
}