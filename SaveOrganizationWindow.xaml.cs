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

        public SaveOrganizationWindow()
        {
            InitializeComponent();
        }

        public void SaveAsXMLBtn_Click(object sender, RoutedEventArgs e)
        {
            fileService.saveOrganizationToXMLFile(FilePathBox.Text + "\\organization.xml", MainWindow.headDepartment);
            Close();
        }

        public void SaveAsJSONBtn_Click(object sender, RoutedEventArgs e)
        {
            fileService.saveOrganizationToJSONFile(FilePathBox.Text + "\\organization.json", MainWindow.headDepartment);
            Close();
        }

        public void BrowseDirectoryBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                FilePathBox.Text = dialog.SelectedPath;
            }
        }
    }
}
