using FileManager.Infrastructrure;
using FileManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

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
        }
        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FileManagerClass.GetInstance().FilePanelLeft.CurDir = new DirectoryInfo(Environment.CurrentDirectory); //new DirectoryInfo("C:\\");
 
         }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FileManagerClass.GetInstance().FilePanelLeft.CurDir = new DirectoryInfo("C:\\");
            if(LeftPanel.SelectedItems == null) 
                return;
        }

        private void LeftPanel_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            FileManagerClass.GetInstance().FilePanelLeft.FilesSelected = LeftPanel.SelectedItems;
        }
    }
}
