using System.Collections.ObjectModel;
using System.Windows;
using Homework_11.Entity;
using Homework_11.Entity.Children;
using Homework_11.Repository.Implementation;

namespace Homework_11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Главный департамент
        /// </summary>
        public Department headDepartment = new();

        public MainWindow()
        {
            InitializeComponent();

            OrganizationTreeView.ItemsSource = headDepartment.Entities;
        }

        public void Refresh()
        {
            OrganizationTreeView.ItemsSource = headDepartment.Entities;
            OrganizationTreeView.UpdateLayout();
        }

        public ObservableCollection<Department> GetAllDepartmentsIncludeSelf(Department department)
        {
            ObservableCollection<Department> departments = new ObservableCollection<Department> {department};

            foreach (var Department in department.Departments)
            {
                foreach (Department DepartmentInner in GetAllDepartmentsIncludeSelf(Department))
                {
                    departments.Add(DepartmentInner);
                }
            }

            return departments;
        }

        public ObservableCollection<Worker> GetAllWorkers(Department department)
        {
            ObservableCollection<Worker> workers = new ObservableCollection<Worker>();

            foreach (Worker worker in department.Workers)
            {
                workers.Add(worker);
            }

            foreach (var Department in department.Departments)
            {
                foreach (Worker WorkerInner in GetAllWorkers(Department))
                {
                    workers.Add(WorkerInner);
                }
            }

            return workers;
        }

        public void WorkerCreationBtn_Click(object sender, RoutedEventArgs e)
        {
            WorkerCreationWindow workerCreationWindow = new WorkerCreationWindow {Owner = this};
            workerCreationWindow.Show();
        }

        private void DepartmentCreationBtn_Click(object sender, RoutedEventArgs e)
        {
            DepartmentCreationWindow departmentCreationWindow = new DepartmentCreationWindow {Owner = this};
            departmentCreationWindow.Show();
        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            SortWindow sortWindow = new SortWindow {Owner = this};

            if (OrganizationTreeView.SelectedItem != null && OrganizationTreeView.SelectedItem.GetType() == typeof(Department))
            {
                Department chosenDepartment = (Department)OrganizationTreeView.SelectedItem;

                sortWindow.DepartmentToBeSorted = chosenDepartment;
            }
            else
            {
                sortWindow.DepartmentToBeSorted = headDepartment;
            }

            sortWindow.DepartmentToBeSortedBox.Text = sortWindow.DepartmentToBeSorted.Name;
            sortWindow.Show();
        }

        public void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (OrganizationTreeView.SelectedItem == null)
            {
                return;
            }

            if (OrganizationTreeView.SelectedItem.GetType() == typeof(Department))
            {
                DepartmentChangeWindow departmentChangeWindow = new DepartmentChangeWindow { Owner = this };
                departmentChangeWindow.Show();
            }
            else if (OrganizationTreeView.SelectedItem is Worker)
            {
                WorkerChangeWindow workerChangeWindow = new WorkerChangeWindow { Owner = this };
                workerChangeWindow.Show();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (OrganizationTreeView.SelectedItem == null)
            {
                return;
            }

            if (OrganizationTreeView.SelectedItem.GetType() == typeof(Department))
            {
                Department chosenDepartment = (Department) OrganizationTreeView.SelectedItem;

                chosenDepartment.ParentDepartment.remove(chosenDepartment);
            }
            else if (OrganizationTreeView.SelectedItem.GetType() == typeof(Worker))
            {
                Worker chosenWorker = (Worker) OrganizationTreeView.SelectedItem;

                chosenWorker.Department.remove(chosenWorker);
            }
            else if (OrganizationTreeView.SelectedItem.GetType() == typeof(Intern))
            {
                Intern chosenWorker = (Intern)OrganizationTreeView.SelectedItem;

                chosenWorker.Department.remove(chosenWorker);
            }
            else if (OrganizationTreeView.SelectedItem.GetType() == typeof(Manager))
            {
                Manager chosenWorker = (Manager)OrganizationTreeView.SelectedItem;

                chosenWorker.Department.remove(chosenWorker);
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveOrganizationWindow saveOrganizationWindow = new SaveOrganizationWindow { Owner = this };
            saveOrganizationWindow.Show();
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadOrganizationWindow loadOrganizationWindow = new LoadOrganizationWindow { Owner = this };
            loadOrganizationWindow.Show();
        }
    }
}
