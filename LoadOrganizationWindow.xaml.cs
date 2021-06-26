using System.Windows;
using Homework_11.Entity;
using Homework_11.Service.Implementation;

namespace Homework_11
{
    /// <summary>
    /// Логика взаимодействия для LoadOrganizationWindow.xaml
    /// </summary>
    public partial class LoadOrganizationWindow : Window
    {
        private readonly FileService fileService = new();

        public LoadOrganizationWindow()
        {
            InitializeComponent();
        }

        //TODO выбор конкретного файла .xml
        public void LoadAsXMLBtn_Click(object sender, RoutedEventArgs e)
        {
            fileService.readOrganizationFromXMLFile(FilePathBox.Text + "\\organization.xml");
            Close();
        }

        //TODO выбор конкретного файла .json
        public void LoadAsJSONBtn_Click(object sender, RoutedEventArgs e)
        {
            fileService.readOrganizationFromJSONFile(FilePathBox.Text + "\\organization.json");
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
