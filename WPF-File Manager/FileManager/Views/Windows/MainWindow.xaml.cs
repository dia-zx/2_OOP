using FileManager.Infrastructrure;
using FileManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {


            FileManagerClass.GetInstance().FilePanelLeft.CurDir = new DirectoryInfo(((Button)sender).Content.ToString());
            //FileManagerClass.GetInstance().FilePanelLeft.CurDir = new DirectoryInfo(Environment.CurrentDirectory); //new DirectoryInfo("C:\\");
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FileManagerClass.GetInstance().FilePanelLeft.CurDir = new DirectoryInfo("C:\\");
            LeftPanel.SelectedIndex = 0;
            if (LeftPanel.SelectedItems == null)
                return;
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

    }
}
