using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Homework_11.Entity;
using Homework_11.Entity.Children;
using Homework_11.Enum;
using Homework_11.Repository.Implementation;

namespace Homework_11
{
    /// <summary>
    /// Логика взаимодействия для WorkerCreationWindow.xaml
    /// </summary>
    public partial class WorkerChangeWindow : Window
    {
        private static readonly Regex _regex = new ("[^0-9]+");
        private readonly MainWindow mainWindow;

        private readonly Worker chosenWorker;

        public WorkerChangeWindow()
        {
            InitializeComponent();
            mainWindow = (MainWindow)Application.Current.MainWindow;

            if (mainWindow.OrganizationTreeView.SelectedItem.GetType() == typeof(Worker))
            {
                chosenWorker = (Worker)mainWindow.OrganizationTreeView.SelectedItem;
            }
            else if (mainWindow.OrganizationTreeView.SelectedItem.GetType() == typeof(Intern))
            {
                chosenWorker = (Intern) mainWindow.OrganizationTreeView.SelectedItem;
            }
            else if (mainWindow.OrganizationTreeView.SelectedItem.GetType() == typeof(Manager))
            {
                chosenWorker = (Manager) mainWindow.OrganizationTreeView.SelectedItem;
            }

            WorkerDepartmentBox.ItemsSource = mainWindow.GetAllDepartmentsIncludeSelf(mainWindow.headDepartment);
            WorkerPositionBox.ItemsSource = System.Enum.GetValues(typeof(Position)).Cast<Position>();

            WorkerDepartmentBox.SelectedItem = chosenWorker.Department;
            WorkerPositionBox.SelectedItem = chosenWorker.Position;
            WorkerLastNameBox.Text = chosenWorker.LastName;
            WorkerFirstNameBox.Text = chosenWorker.FirstName;
            WorkerAgeBox.Text = chosenWorker.Age.ToString();
            WorkerSalaryBox.Text = chosenWorker.Salary.ToString();
            WorkerProjectsCountBox.Text = chosenWorker.ProjectsCount.ToString();
        }

        public void ValidateInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }

        public void ChangeWorkerBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                chosenWorker.Department.remove(chosenWorker);
                ((Department)WorkerDepartmentBox.SelectionBoxItem).add(chosenWorker);

                chosenWorker.LastName = WorkerLastNameBox.Text;
                chosenWorker.FirstName = WorkerFirstNameBox.Text;
                chosenWorker.Age = Convert.ToInt32(WorkerAgeBox.Text);
                chosenWorker.Salary = Convert.ToInt32(WorkerSalaryBox.Text);
                chosenWorker.ProjectsCount = Convert.ToInt32(WorkerProjectsCountBox.Text);
            }
            catch (FormatException)
            {
                
            }

            mainWindow.Refresh();
            Close();
        }
    }
}
