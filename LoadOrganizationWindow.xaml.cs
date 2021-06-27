using System.Windows;
using Homework_11.Entity;
using Homework_11.Repository.Implementation;
using Homework_11.Service.Implementation;

namespace Homework_11
{
    /// <summary>
    /// Логика взаимодействия для LoadOrganizationWindow.xaml
    /// </summary>
    public partial class LoadOrganizationWindow : Window
    {
        private readonly FileService fileService = new();

        private readonly MainWindow mainWindow;

        public LoadOrganizationWindow()
        {
            InitializeComponent();

            mainWindow = (MainWindow) Application.Current.MainWindow;
        }

        public void LoadAsXMLBtn_Click(object sender, RoutedEventArgs e)
        {
            Department loadedOrganization = fileService.readOrganizationFromXMLFile(FilePathBox.Text);
            mainWindow.headDepartment = loadedOrganization;
            mainWindow.Refresh();
            Close();
        }

        public void LoadAsJSONBtn_Click(object sender, RoutedEventArgs e)
        {
            Department loadedOrganization = fileService.readOrganizationFromJSONFile(FilePathBox.Text);
            mainWindow.headDepartment = loadedOrganization;
            mainWindow.Refresh();
            Close();
        }

        public void BrowseDirectoryBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaOpenFileDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                FilePathBox.Text = dialog.FileName;
            }
        }
    }
}
