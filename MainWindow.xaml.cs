using System;
using System.ComponentModel;
using System.Windows;
using Homework_11.Entity;
using Homework_11.Entity.Children;
using Homework_11.Repository.Implementation;
using Homework_11.Service;
using Homework_11.Service.Implementation;

namespace Homework_11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Путь к файлу. Если оставить пустым, программа будет спрашивать путь во время работы
        /// </summary>
        public static readonly string FilePath = string.Empty;

        /// <summary>
        /// Главный департамент
        /// </summary>
        public static Department headDepartment = new();

        private readonly FileService fileService = new();

        public MainWindow()
        {
            InitializeComponent();
            
            try
            {
                // Загрузка тестовой организации из файла
                headDepartment = fileService.readOrganizationFromXMLFile("../../resources/data/testOrganization.xml");
                // headDepartment = fileService.readOrganizationFromJSONFile("../../resources/data/testOrganization.json");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            OrganizationTreeView.ItemsSource = headDepartment.Entities;
        }

        public void Refresh()
        {
            OrganizationTreeView.ItemsSource = headDepartment.Entities;
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

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
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
