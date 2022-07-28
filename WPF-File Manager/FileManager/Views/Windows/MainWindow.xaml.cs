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

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //foreach (var item in SecondMenu.Items)
            //{
            //    ((System.Windows.Controls.MenuItem)item).Width = SecondMenu.ActualWidth / SecondMenu.Items.Count;
            //    ((System.Windows.Controls.MenuItem)item).HorizontalContentAlignment = HorizontalAlignment.Center;
            //}

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //List<Person> list = new ();
            //list.Add(new Person { Name = "Иван", FirstName = "Давыдов", YearsOld = 43});
            //list.Add(new Person { Name = "Владимир", FirstName = "Емельянов", YearsOld = 40 });
            //LeftPanel.ItemsSource = list;
            DirectoryInfo directoryInfo = new("c:\\");
            LeftPanel.ItemsSource = directoryInfo.EnumerateDirectories();
        }
    }
    public class Person
    {
        public string Name { get; set; }  
        public string FirstName { get; set; }
        public int YearsOld { get; set; }
    }
}
