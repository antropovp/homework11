using System;
using System.Windows;
using Homework_11.Entity;
using Homework_11.Service.Implementation;

namespace Homework_11
{
    /// <summary>
    /// Логика взаимодействия для SaveOrganizationWindow.xaml
    /// </summary>
    public partial class SaveOrganizationWindow : Window
    {
        private readonly FileService fileService = new();
        private readonly MainWindow mainWindow;

        public SaveOrganizationWindow()
        {
            InitializeComponent();

            mainWindow = (MainWindow) Application.Current.MainWindow;
        }

        public void SaveAsXMLBtn_Click(object sender, RoutedEventArgs e)
        {
            fileService.saveOrganizationToXMLFile(FilePathBox.Text, mainWindow.headDepartment);
            Close();
        }

        public void SaveAsJSONBtn_Click(object sender, RoutedEventArgs e)
        {
            fileService.saveOrganizationToJSONFile(FilePathBox.Text, mainWindow.headDepartment);
            Close();
        }

        public void BrowseDirectoryBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaSaveFileDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                FilePathBox.Text = dialog.FileName;
            }
        }
    }
}
