using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Homework_11.Entity;
using Homework_11.Enum;
using Homework_11.Repository.Implementation;
using Homework_11.Service;
using Homework_11.Service.Implementation;

namespace Homework_11
{
    /// <summary>
    /// Логика взаимодействия для WorkerCreationWindow.xaml
    /// </summary>
    public partial class WorkerCreationWindow : Window
    {
        private static readonly Regex _regex = new ("[^0-9]+");

        public void ValidateInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }

        public WorkerCreationWindow()
        {
            InitializeComponent();

            WorkerPositionBox.ItemsSource = System.Enum.GetValues(typeof(Position)).Cast<Position>();

            WorkerDepartmentBox.ItemsSource = MainWindow.headDepartment.Departments;
        }
        
        public void CreateWorkerBtn_Click(object sender, RoutedEventArgs e)
        {
            Department workerDepartment = (Department) WorkerDepartmentBox.SelectionBoxItem;
            
            try
            {
                Worker newWorker = new Worker(workerDepartment,
                    WorkerLastNameBox.Text, WorkerFirstNameBox.Text, Convert.ToInt32(WorkerAgeBox.Text),
                    Convert.ToInt32(WorkerSalaryBox.Text), Convert.ToInt32(WorkerProjectsCountBox.Text));
                workerDepartment.add(newWorker);
            }
            catch (FormatException)
            {
                
            }

            Close();
        }
    }
}
