using System;
using System.IO;

namespace FileManager.Models
{
    public class FileTableList
    {
        public FileTableList(string Name, string Extention, string Size, DateTime dateTime, FileSystemInfo filesystemInfo)
        {
            _Name = Name;
            _Extention = Extention;
            _Size = Size;   
            _DateTime = dateTime;
            _FileSystemInfo = filesystemInfo;
        }
        private string _Name;
        private string _Extention;
        private string _Size;
        private DateTime _DateTime;
        private FileSystemInfo _FileSystemInfo;


        public string Name { get=>_Name;}
        public string Extention { get=>_Extention;}
        public string Size { get=>_Size;}
        public DateTime DateTime { get=>_DateTime; }
        public FileSystemInfo FileSystemInfo { get=> _FileSystemInfo; } 
    }
}
