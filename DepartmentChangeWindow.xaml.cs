using System.Windows;
using Homework_11.Repository.Implementation;

namespace Homework_11
{
    /// <summary>
    /// Логика взаимодействия для DepartmentCreationWindow.xaml
    /// </summary>
    public partial class DepartmentChangeWindow : Window
    {
        private readonly MainWindow mainWindow;

        private readonly Department chosenDepartment;

        public DepartmentChangeWindow()
        {
            InitializeComponent();
            mainWindow = (MainWindow)Application.Current.MainWindow;

            chosenDepartment = (Department)mainWindow.OrganizationTreeView.SelectedItem;

            ParentDepartmentBox.ItemsSource = mainWindow.GetAllDepartmentsIncludeSelf(mainWindow.headDepartment);

            ParentDepartmentBox.SelectedItem = chosenDepartment.ParentDepartment;
            DepartmentNameBox.Text = chosenDepartment.Name;
        }
        
        public void ChangeDepartmentBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((Department)ParentDepartmentBox.SelectionBoxItem != chosenDepartment &&
                ParentDepartmentBox.SelectionBoxItem.ToString() != string.Empty)
            {
                chosenDepartment.ParentDepartment.remove(chosenDepartment);
                ((Department)ParentDepartmentBox.SelectionBoxItem).add(chosenDepartment);
            }
            
            chosenDepartment.Name = DepartmentNameBox.Text;
            
            mainWindow.Refresh();
            Close();
        }
    }
}
