using System;
using System.IO;

namespace FileManager.Models
{
    public class FileTableList
    {
        public FileTableList(string Name, string Extention, string Size, string dateTime, FileSystemInfo fileSystemInfo)
        {
            _Name = Name;
            _Extention = Extention;
            _Size = Size;   
            _DateTime = dateTime;
            _fileSystemInfo = fileSystemInfo;
        }
        private string _Name;
        private string _Extention;
        private string _Size;
        private string _DateTime;
        private FileSystemInfo _fileSystemInfo;


        public string Name { get=>_Name;}
        public string Extention { get=>_Extention;}
        public string Size { get=>_Size;}
        public string DateTime { get=>_DateTime; }
        public FileSystemInfo FileInfo { get=> _fileSystemInfo; } 
    }
}
