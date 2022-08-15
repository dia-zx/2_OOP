using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Infrastructrure
{
    public class DrivePanel
    {
        public DrivePanel()
        {
            
        }



        public DriveInfo[] DrivesList { get { return DriveInfo.GetDrives(); } }

    }
}
