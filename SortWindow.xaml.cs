using System.Windows;
using System.Windows.Controls;
using Homework_11.Repository.Implementation;

namespace Homework_11
{
    /// <summary>
    /// Логика взаимодействия для SortWindow.xaml
    /// </summary>
    public partial class SortWindow : Window
    {
        public Department DepartmentToBeSorted { get; set; }

        private RadioButton checkedRadioButton;

        public SortWindow()
        {
            InitializeComponent();
        }

        public void SortDepartmentsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkedRadioButton != null)
            {
                if (checkedRadioButton.Name == "DateOfCreationButton")
                {
                    DepartmentToBeSorted.sortDepartmentsByDateOfCreation();
                }
                else if (checkedRadioButton.Name == "NameButton")
                {
                    DepartmentToBeSorted.sortDepartmentsByName();
                }
                else if (checkedRadioButton.Name == "WorkersCountButton")
                {
                    DepartmentToBeSorted.sortDepartmentsByWorkersCount();
                }

                MainWindow mainWindow = (MainWindow) Application.Current.MainWindow;
                mainWindow.Refresh();
            }
        }

        public void SortWorkersBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkedRadioButton != null)
            {
                if (checkedRadioButton.Name == "WorkerLastNameButton")
                {
                    DepartmentToBeSorted.sortWorkersByLastName();
                }
                else if (checkedRadioButton.Name == "WorkerFirstNameButton")
                {
                    DepartmentToBeSorted.sortWorkersByFirstName();
                }
                else if (checkedRadioButton.Name == "WorkerAgeButton")
                {
                    DepartmentToBeSorted.sortWorkersByAge();
                }
                else if (checkedRadioButton.Name == "WorkerSalaryButton")
                {
                    DepartmentToBeSorted.sortWorkersBySalary();
                }
                else if (checkedRadioButton.Name == "WorkerProjectsCountButton")
                {
                    DepartmentToBeSorted.sortWorkersByProjectsCount();
                }

                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.Refresh();
            }
        }

        public void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            checkedRadioButton = (RadioButton) sender;
        }
    }
}
