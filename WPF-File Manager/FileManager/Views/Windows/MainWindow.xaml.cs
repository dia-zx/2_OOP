using FileManager.Infrastructrure;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
/***
1.Реализовать простейший файловый менеджер с использованием ООП (классы, наследование и прочее).
### Файловый менеджер должен иметь возможность:
*показывать содержимое дисков;
*создавать папки / файлы;
*удалять папки / файлы;
*переименовывать папки / файлы;
*копировать / переносить папки / файлы;
*вычислять размер папки/файла;
*производить поиск по маске (с поиском по подпапкам);
*для текстовых файлов готовить статические данные (кол-во слов, кол-во строк, кол-во абзацев, кол-во символов с пробелами, кол-во слов без пробелов).

Предусмотреть возможность изменения атрибутов файлов.
***/

namespace FileManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _window = this;
        }
        static MainWindow _window;


        private void LeftPanelDrivesButton_Click(object sender, RoutedEventArgs e)
        {
            FileManagerClass.GetInstance().FilePanelLeft.CurDir = new DirectoryInfo(((Button)sender).Content.ToString());
        }

        private void RightPanelDrivesButton_Click(object sender, RoutedEventArgs e)
        {
            FileManagerClass.GetInstance().FilePanelRight.CurDir = new DirectoryInfo(((Button)sender).Content.ToString());
        }


        private void LeftPanel_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Equals(sender, LeftPanel))
                FileManagerClass.GetInstance().FilePanelLeft.FilesSelected = ((DataGrid)sender).SelectedItems;
            if (Equals(sender, RightPanel))
                FileManagerClass.GetInstance().FilePanelRight.FilesSelected = ((DataGrid)sender).SelectedItems;
        }

        #region фокусы панелей левой и правой. Фиксируем.
        /// <summary>
        /// Левая панель в фокусе!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftPanel_GotFocus(object sender, RoutedEventArgs e)
        {
            FileManagerClass.GetInstance().ActivePanel = FileManagerClass.GetInstance().FilePanelLeft;
        }
        /// <summary>
        /// Правая панель в фокусе!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightPanel_GotFocus(object sender, RoutedEventArgs e)
        {
            FileManagerClass.GetInstance().ActivePanel = FileManagerClass.GetInstance().FilePanelRight;
        }
        #endregion

        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                ((Control)sender).MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
        }
    }
}
