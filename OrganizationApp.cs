using System;
using Homework_11.Entity;
using Homework_11.Repository;
using Homework_11.Repository.Implementation;
using Homework_11.Service;
using Homework_11.Service.Implementation;

namespace Homework_11
{
    /// <summary>
    /// Приложение для работы с организацией
    /// </summary>
    public class OrganizationApp : IOrganizationApp
    {
        /// <summary>
        /// Путь к файлу. Если оставить пустым, программа будет спрашивать путь во время работы
        /// </summary>
        private readonly string FilePath = string.Empty;
        
        /// <summary>
        /// Главный департамент
        /// </summary>
        private Department headDepartment = new Department();

        private readonly IDepartmentService departmentService = new DepartmentService();
        private readonly IWorkerService workerService = new WorkerService();
        private readonly FileService fileService = new FileService();

        private bool isProgramOpened = true;

        public OrganizationApp()
        {
            Console.WriteLine(">>> Antropov corp. <<<\n");

            try
            {
                // Загрузка тестовой организации из файла
                //headDepartment = fileService.readOrganizationFromXMLFile("../../testOrganization.xml");
                headDepartment = fileService.readOrganizationFromJSONFile("../../testOrganization.json");
                Console.WriteLine("Test organization uploaded.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void start()
        {
            // Запускаем меню
            organizationMenu();

            // Если пользователь не выбрал выход из программы, возвращаемся к запуску меню
            if (isProgramOpened)
            {
                start();
            }
        }

        public void organizationMenu()
        {
            // Предлагаем варианты выбора
            Console.WriteLine("Menu:");
            Console.WriteLine("1. New worker");
            Console.WriteLine("2. Show all workers");
            Console.WriteLine("3. New department");
            Console.WriteLine("4. Show all departments");
            Console.WriteLine("5. Save organization");
            Console.WriteLine("6. Load organization");
            Console.WriteLine("7. Exit");

            char choice = '0';

            while (choice != '1' && choice != '2' && choice != '3' && choice != '4' && choice != '5' && choice != '6' && choice != '7')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        printWorker(workerService.createWorker(headDepartment));
                        break;
                    case '2':
                        printWorkers(headDepartment);
                        break;
                    case '3':
                        printDepartment(departmentService.createDepartment(headDepartment));
                        break;
                    case '4':
                        printDepartments(headDepartment);
                        break;
                    case '5':
                        saveOrganization();
                        break;
                    case '6':
                        loadOrganization();
                        break;
                    case '7':
                        exit();
                        break;
                    default:
                        Console.Write("Error. Try again: ");
                        break;
                }
            }
        }

        public void printDepartment(Department department)
        {
            // Выводим департамент в консоль
            Console.WriteLine(department);
            Console.WriteLine();

            // Выводим внутреннее меню
            departmentMenu(department);
        }

        public void printWorker(Worker worker)
        {
            // Выводим сотрудника в консоль
            Console.WriteLine(worker);
            Console.WriteLine();

            // Выводим внутреннее меню
            workerMenu(worker);
        }

        public void printDepartments(Department parentDepartment)
        {
            // Если вложенных департаментов нет, выводим сообщение об этом и возвращаемся назад
            if (parentDepartment.Departments.Count == 0)
            {
                Console.WriteLine("There are no nested departments in this department.");
                return;
            }
            
            // Выводим департаменты поочерёдно, с номерами и разделителем
            for (int i = 0; i < parentDepartment.Departments.Count; i++)
            {
                Console.WriteLine($"#{i + 1}\n");
                Console.WriteLine(parentDepartment.Departments[i]);
                Console.WriteLine("\n-----\n");
            }

            // Выводим внутреннее меню
            Console.WriteLine("1. Go back");
            Console.WriteLine("2. Select the department #...");
            Console.WriteLine("3. Sort departments...");
            Console.WriteLine("4. Delete departments...");

            char choice = '0';

            while (choice != '1' && choice != '2' && choice != '3' && choice != '4')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        return;
                    case '2':
                        Console.Write("Type the department's number: ");
                        try
                        {
                            printDepartment(parentDepartment.Departments[Convert.ToInt32(Console.ReadLine()) - 1]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case '3':
                        sortDepartmentsMenu(parentDepartment);
                        break;
                    case '4':
                        deleteDepartmentsMenu(parentDepartment);
                        break;
                    default:
                        Console.Write("Error. Try again: ");
                        break;
                }
            }

            printDepartments(parentDepartment);
        }

        public void printWorkers(Department department)
        {
            // Если сотрудников нет, выводим сообщение об этом и возвращаемся назад
            if (department.Workers.Count == 0)
            {
                Console.WriteLine("There are no workers in this department.");
                return;
            }

            // Выводим сотрудников поочерёдно, с номерами и разделителем
            for (int i = 0; i < department.Workers.Count; i++)
            {
                Console.WriteLine($"#{i + 1}\n");
                Console.WriteLine(department.Workers[i]);
                Console.WriteLine("\n-----\n");
            }

            // Выводим внутреннее меню
            Console.WriteLine("1. Go back");
            Console.WriteLine("2. Select the worker #...");
            Console.WriteLine("3. Sort workers...");
            Console.WriteLine("4. Delete workers...");

            char choice = '0';

            while (choice != '1' && choice != '2' && choice != '3' && choice != '4')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        return;
                    case '2':
                        Console.Write("Type the worker's number: ");
                        try
                        {
                            printWorker(department.Workers[Convert.ToInt32(Console.ReadLine()) - 1]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case '3':
                        sortWorkersMenu(department);
                        break;
                    case '4':
                        deleteWorkersMenu(department);
                        break;
                    default:
                        Console.Write("Error. Try again: ");
                        break;
                }
            }

            printWorkers(department);
        }

        public void departmentMenu(Department department)
        {
            // Предлагаем варианты выбора
            Console.WriteLine("1. Go back");
            Console.WriteLine("2. Change");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. New worker");
            Console.WriteLine("5. Show all workers");
            Console.WriteLine("6. New nested department");
            Console.WriteLine("7. Show all nested departments");

            char choice = '0';

            while (choice != '1' && choice != '2' && choice != '3' && choice != '4' && choice != '5' && choice != '6' && choice != '7')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        return;
                    case '2':
                        departmentService.changeDepartment(department);
                        break;
                    case '3':
                        departmentService.deleteDepartment(department);
                        break;
                    case '4':
                        printWorker(workerService.createWorker(department));
                        break;
                    case '5':
                        printWorkers(department);
                        break;
                    case '6':
                        printDepartment(departmentService.createDepartment(department));
                        break;
                    case '7':
                        printDepartments(department);
                        break;
                    default:
                        Console.Write("Error. Try again: ");
                        break;
                }
            }

            printDepartment(department);
        }
        
        public void workerMenu(Worker worker)
        {
            // Предлагаем варианты выбора
            Console.WriteLine("1. Go back");
            Console.WriteLine("2. Change");
            Console.WriteLine("3. Delete");

            char choice = '0';

            while (choice != '1' && choice != '2' && choice != '3')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        return;
                    case '2':
                        workerService.changeWorker(worker);
                        break;
                    case '3':
                        workerService.deleteWorker(worker);
                        break;
                    default:
                        Console.Write("Error. Try again: ");
                        break;
                }
            }

            printWorker(worker);
        }

        public void sortDepartmentsMenu(Department parentDepartment)
        {
            // Предлагаем варианты для сортировки
            Console.WriteLine("Sort departments by:");
            Console.WriteLine("1. Date of creation");
            Console.WriteLine("2. Name");
            Console.WriteLine("3. Workers count");

            char choice = '0';

            while (choice != '1' && choice != '2' && choice != '3')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.WriteLine("Sorting the departments...");

                switch (choice)
                {
                    case '1':
                        parentDepartment.sortDepartmentsByDateOfCreation();
                        break;
                    case '2':
                        parentDepartment.sortDepartmentsByName();
                        break;
                    case '3':
                        parentDepartment.sortDepartmentsByWorkersCount();
                        break;
                    default:
                        Console.Write("Error. Try again: ");
                        break;
                }
            }

            Console.WriteLine("Done.");
            Console.WriteLine();
        }

        public void sortWorkersMenu(Department department)
        {
            // Предлагаем варианты для сортировки
            Console.WriteLine("Sort workers by:");
            Console.WriteLine("1. Last name");
            Console.WriteLine("2. First name");
            Console.WriteLine("3. Age");
            Console.WriteLine("4. Salary");
            Console.WriteLine("5. Projects count");

            char choice = '0';

            while (choice != '1' && choice != '2' && choice != '3' && choice != '4' && choice != '5')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.WriteLine("Sorting the workers...");

                switch (choice)
                {
                    case '1':
                        department.sortWorkersByLastName();
                        break;
                    case '2':
                        department.sortWorkersByFirstName();
                        break;
                    case '3':
                        department.sortWorkersByAge();
                        break;
                    case '4':
                        department.sortWorkersBySalary();
                        break;
                    case '5':
                        department.sortWorkersByProjectsCount();
                        break;
                    default:
                        Console.Write("Error. Try again: ");
                        break;
                }
            }

            Console.WriteLine("Done.");
            Console.WriteLine();
        }

        public void deleteDepartmentsMenu(Department parentDepartment)
        {
            // Предлагаем варианты для удаления
            Console.WriteLine("Delete departments by:");
            Console.WriteLine("1. Date of creation");
            Console.WriteLine("2. Name");
            Console.WriteLine("3. Workers count");

            char choice = '0';

            while (choice != '1' && choice != '2' && choice != '3')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        departmentService.deleteDepartmentsByDateOfCreation(parentDepartment);
                        break;
                    case '2':
                        departmentService.deleteDepartmentsByName(parentDepartment);
                        break;
                    case '3':
                        departmentService.deleteDepartmentsByWorkersCount(parentDepartment);
                        break;
                    default:
                        Console.Write("Error. Try again: ");
                        break;
                }
            }
        }

        public void deleteWorkersMenu(Department department)
        {
            // Предлагаем варианты для удаления
            Console.WriteLine("Delete workers by:");
            Console.WriteLine("1. Last name");
            Console.WriteLine("2. First name");
            Console.WriteLine("3. Age");
            Console.WriteLine("4. Salary");
            Console.WriteLine("5. Projects count");

            char choice = '0';

            while (choice != '1' && choice != '2' && choice != '3' && choice != '4' && choice != '5')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        workerService.deleteWorkersByLastName(department);
                        break;
                    case '2':
                        workerService.deleteWorkersByFirstName(department);
                        break;
                    case '3':
                        workerService.deleteWorkersByAge(department);
                        break;
                    case '4':
                        workerService.deleteWorkersBySalary(department);
                        break;
                    case '5':
                        workerService.deleteWorkersByProjectsCount(department);
                        break;
                    default:
                        Console.Write("Error. Try again: ");
                        break;
                }
            }
        }

        public string getFilePath()
        {
            string filePath = FilePath;

            if (filePath == string.Empty)
            {
                Console.Write("Type the file path: ");

                filePath = Console.ReadLine();
            }

            return filePath;
        }

        public void loadOrganization()
        {
            // Предлагаем варианты форматирования исходного файла
            Console.WriteLine("Load organization from:");
            Console.WriteLine("1. XML file");
            Console.WriteLine("2. JSON file");

            char choice = '0';

            while (choice != '1' && choice != '2')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        headDepartment = fileService.readOrganizationFromXMLFile(getFilePath());
                        break;
                    case '2':
                        headDepartment = fileService.readOrganizationFromJSONFile(getFilePath());
                        break;
                    default:
                        Console.Write("Error. Try again: ");
                        break;
                }
            }
        }

        public void saveOrganization()
        {
            // Предлагаем варианты форматирования конечного файла
            Console.WriteLine("Save organization as:");
            Console.WriteLine("1. XML file");
            Console.WriteLine("2. JSON file");

            char choice = '0';

            while (choice != '1' && choice != '2')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        fileService.saveOrganizationToXMLFile(getFilePath(), headDepartment);
                        break;
                    case '2':
                        fileService.saveOrganizationToJSONFile(getFilePath(), headDepartment);
                        break;
                    default:
                        Console.Write("Error. Try again: ");
                        break;
                }
            }
        }

        public void exit()
        {
            // Предлагаем сохранить организацию перед выходом
            Console.Write("Save the organization before exiting? (y/n) ");

            char choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    saveOrganization();
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }

            // Меняем флаг, указывая на закрытие программы
            isProgramOpened = false;

            Console.WriteLine("Application is closed. Press any key to close the window.");
            Console.ReadKey();
        }
    }
}