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
    /// Логика взаимодействия для WorkerCreation.xaml
    /// </summary>
    public partial class WorkerCreationWindow : Window
    {
        private readonly IWorkerService workerService = new WorkerService();

        public WorkerCreationWindow()
        {
            InitializeComponent();

            WorkerPositionBox.ItemsSource = System.Enum.GetValues(typeof(Position)).Cast<Position>();

            WorkerDepartmentBox.ItemsSource = MainWindow.headDepartment.Departments;
        }
        
        public void CreateWorkerBtnClick(object sender, RoutedEventArgs e)
        {
            Worker newWorker = new Worker((Department)WorkerDepartmentBox.SelectionBoxItem);
        }
    }
}
