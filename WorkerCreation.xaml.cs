using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Homework_11.Entity;
using Homework_11.Enum;
using Homework_11.Service;
using Homework_11.Service.Implementation;

namespace Homework_11
{
    /// <summary>
    /// Логика взаимодействия для WorkerCreation.xaml
    /// </summary>
    public partial class WorkerCreation : Window
    {
        private readonly IWorkerService workerService = new WorkerService();

        public WorkerCreation()
        {
            InitializeComponent();

            //todo
            WorkerPositionBox.ItemsSource = new []{Position.INTERN, Position.WORKER, Position.MANAGER};
        }

        public void CreateWorkerBtnClick(object sender, RoutedEventArgs e)
        {
            //Worker newWorker = new Worker(TreeView.SelectedItemProperty)
        }
    }
}
