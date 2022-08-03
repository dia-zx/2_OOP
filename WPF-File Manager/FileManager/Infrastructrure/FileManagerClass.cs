using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Infrastructrure
{
    public class FileManagerClass
    {
        private static FileManagerClass _instance = null;
        public static FileManagerClass GetInstance()
        {
            if( _instance == null ) 
                _instance = new FileManagerClass();
            return _instance;
        }
        private FileManagerClass()
        {
            FilePanelLeft = new();
            FilePanelRight = new();
        }
        public FilePanel FilePanelLeft { get; }
        public FilePanel FilePanelRight { get; }
    }
}
