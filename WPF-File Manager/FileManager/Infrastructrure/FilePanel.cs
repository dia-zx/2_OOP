using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Models;
using System.Collections;

namespace FileManager.Infrastructrure
{
    public class FilePanel 
    {
        public FilePanel()
        {
            _CurDir = new DirectoryInfo(Environment.CurrentDirectory);
            _CurDir = new DirectoryInfo("C:\\");
            _DirWatcher = new(_CurDir.FullName);
            _DirWatcher.Changed += _DirWatcher_Changed;
            _DirWatcher.Created += _DirWatcher_Changed;
            _DirWatcher.Deleted += _DirWatcher_Changed;
            _DirWatcher.Renamed += _DirWatcher_Changed;
            _DirWatcher.EnableRaisingEvents = true;

        }

        private void _DirWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            OnDirChanged();
        }

        private FileSystemWatcher _DirWatcher;
        public IList FilesSelected { get; set; }

        private DirectoryInfo _CurDir;
        public DirectoryInfo CurDir {
            get => _CurDir;
            set {                
                _CurDir = value;
                _DirWatcher.Path = _CurDir.FullName;
                OnDirChanged();
            }
        }

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
                    _CurDir?.Parent?.CreationTime.ToString("dd.MM.yyyy HH:mm:ss"), _CurDir.Parent);
            foreach (var dir in _CurDir.GetDirectories())
            {
                yield return new FileTableList(dir.Name, "", "<Папка>",
                    dir.CreationTime.ToString("dd.MM.yyyy HH:mm:ss"), dir);
            }

            foreach (var file in _CurDir.GetFiles())
            {
                yield return new FileTableList(
                    Path.GetFileNameWithoutExtension(file.Name),
                    GetExtention(Path.GetExtension(file.Name)),
                    file.Length.ToString("### ### ### ###"),
                    file.CreationTime.ToString("dd.MM.yyyy HH:mm:ss"), file);
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
