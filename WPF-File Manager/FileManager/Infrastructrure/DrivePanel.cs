using System.IO;

namespace FileManager.Infrastructrure
{
    /// <summary>
    /// для отображения дисков
    /// </summary>
    public class DrivePanel
    {
        public DriveInfo[] DrivesList { get { return DriveInfo.GetDrives(); } }
    }
}
