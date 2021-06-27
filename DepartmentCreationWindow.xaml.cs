using System.Linq;
using System.Windows;
using Homework_11.Entity;
using Homework_11.Enum;
using Homework_11.Repository.Implementation;
using Homework_11.Service;
using Homework_11.Service.Implementation;

namespace Homework_11
{
    /// <summary>
    /// Логика взаимодействия для DepartmentCreationWindow.xaml
    /// </summary>
    public partial class DepartmentCreationWindow : Window
    {
        public DepartmentCreationWindow()
        {
            InitializeComponent();
        }
        
        public void CreateDepartmentBtn_Click(object sender, RoutedEventArgs e)
        {
            Department parentDepartment = (Department) ParentDepartmentBox.SelectionBoxItem;
            Department newDepartment = new Department(parentDepartment) { Name = DepartmentNameBox.Text };
            parentDepartment.add(newDepartment);

            Close();
        }
    }
}
