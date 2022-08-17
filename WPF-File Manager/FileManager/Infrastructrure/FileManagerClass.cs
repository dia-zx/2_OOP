namespace FileManager.Infrastructrure
{
    public class FileManagerClass
    {
        private static FileManagerClass _instance = null;
        public static FileManagerClass GetInstance()
        {//** SingleTone ***
            if (_instance == null)
                _instance = new FileManagerClass();
            return _instance;
        }
        private FileManagerClass()
        {
            FilePanelLeft = new();
            FilePanelRight = new();
            DrivePanel = new();
            UpdateCurDirs();
        }

        FilePanel _ActivePanel = null;

        public FilePanel ActivePanel
        {
            get => _ActivePanel;
            set
            {
                if ((value == FilePanelLeft) || (value == FilePanelRight))
                    _ActivePanel = value;
                else
                    _ActivePanel = null;
            }
        }

        public FilePanel FilePanelLeft { get; }
        public FilePanel FilePanelRight { get; }
        public DrivePanel DrivePanel { get; }

        /// <summary>
        /// обновляет значения текущих каталогов
        /// </summary>
        public void UpdateCurDirs()
        {
            FilePanelLeft.CurDir = FilePanelLeft.CurDir;
            FilePanelRight.CurDir = FilePanelRight.CurDir;
        }
    }
}
