using FileManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace FileManager.Infrastructrure
{
    public class FilePanel
    {
        public FilePanel()
        {
            //_CurDir = new DirectoryInfo(Environment.CurrentDirectory);
            _CurDir = DriveInfo.GetDrives()[0].RootDirectory;
            _DirWatcher = new();
            _DirWatcher.Changed += _DirWatcher_Changed;
            _DirWatcher.Created += _DirWatcher_Changed;
            _DirWatcher.Deleted += _DirWatcher_Changed;
            _DirWatcher.Renamed += _DirWatcher_Changed;
        }
        public bool EnableEvents
        {
            get => _DirWatcher.EnableRaisingEvents;
            set => _DirWatcher.EnableRaisingEvents = value;
        }


        private void _DirWatcher_Changed(object sender, FileSystemEventArgs e) => OnDirChanged();

        private FileSystemWatcher _DirWatcher;
        public IList FilesSelected { get; set; }

        #region Текущая дирректория панели
        private DirectoryInfo _CurDir;
        public DirectoryInfo CurDir
        {
            get => _CurDir;
            set
            {
                #region перебираем различные варианты дирректорий с проверкой на существование
                do
                {
                    if (Directory.Exists(value.FullName)) break;
                    else
                        value = _CurDir;
                    if (Directory.Exists(value.FullName)) break;
                    else
                        value = value.Root;
                    if (Directory.Exists(value.FullName)) break;
                    else
                        value = DriveInfo.GetDrives()[0].RootDirectory;
                } while (false);
                _CurDir = value;
                #endregion

                try
                {
                    _DirWatcher.Path = _CurDir.FullName;
                    EnableEvents = true;
                }
                catch (Exception)
                {
                    return;
                }
                OnDirChanged();
            }
        }
        #endregion

        public event EventHandler<EventArgs> DirChanged;
        private void OnDirChanged() { DirChanged?.Invoke(this, EventArgs.Empty); }

        /// <summary>
        /// Формирует список файлов и каталогов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FileTableList> GetFileList()
        {
            if (_CurDir.Parent != null)
                yield return new FileTableList("\\..", "", "<Папка>",
                    _CurDir.Parent.CreationTime, _CurDir.Parent);
            foreach (var dir in _CurDir.GetDirectories())
            {
                yield return new FileTableList(dir.Name, "", "<Папка>",
                    dir.CreationTime, dir);
            }

            foreach (var file in _CurDir.GetFiles())
            {
                yield return new FileTableList(
                    Path.GetFileNameWithoutExtension(file.Name),
                    GetExtention(Path.GetExtension(file.Name)),
                    file.Length.ToString("### ### ### ###"),
                    file.CreationTime, file);
            }
        }

        /// <summary>
        /// убираем '.' из расширения
        /// </summary>
        /// <param name="ext"></param>
        /// <returns></returns>
        private string GetExtention(string ext)
        {
            if (ext == null || ext.Length < 1) return string.Empty;
            if (ext[0] != '.') return ext;
            return ext.AsSpan().Slice(1).ToString();
        }

    }
}
