using System.Windows;
using Homework_11.Repository.Implementation;

namespace Homework_11
{
    /// <summary>
    /// Логика взаимодействия для DepartmentCreationWindow.xaml
    /// </summary>
    public partial class DepartmentCreationWindow : Window
    {
        private readonly MainWindow mainWindow;

        public DepartmentCreationWindow()
        {
            InitializeComponent();

            mainWindow = (MainWindow) Application.Current.MainWindow;


            if (mainWindow.OrganizationTreeView.SelectedItem != null && mainWindow.OrganizationTreeView.SelectedItem.GetType() == typeof(Department))
            {
                Department chosenDepartment = (Department)mainWindow.OrganizationTreeView.SelectedItem;

                ParentDepartmentBox.ItemsSource = chosenDepartment.ParentDepartment.Departments;
            }
            else
            {
                ParentDepartmentBox.ItemsSource = mainWindow.GetAllDepartmentsIncludeSelf(mainWindow.headDepartment);
            }


        }

        public void CreateDepartmentBtn_Click(object sender, RoutedEventArgs e)
        {
            Department parentDepartment;

            if (ParentDepartmentBox.SelectionBoxItem.ToString() != string.Empty)
            {
                parentDepartment = (Department)ParentDepartmentBox.SelectionBoxItem;
            }
            else
            {
                parentDepartment = mainWindow.headDepartment;
            }
            
            Department newDepartment = new Department(parentDepartment) { Name = DepartmentNameBox.Text };
            parentDepartment.add(newDepartment);

            Close();
        }
    }
}
