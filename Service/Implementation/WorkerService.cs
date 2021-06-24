using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Homework_11.Entity;
using Homework_11.Entity.Children;
using Homework_11.Repository.Implementation;

namespace Homework_11.Service.Implementation
{
    /// <summary>
    /// Сервис для работы с сотрудниками
    /// </summary>
    public class WorkerService : IWorkerService
    {
        public Worker createWorker(Department department)
        {
            // Переменная для получения выбора действия пользователя при работе с программой
            char choice = '0';

            // Создание экземпляра сотрудника
            Worker newWorker = new Worker(department); ;

            #region Уточнение должности сотрудника
            Console.Write("Do you want to specify the worker's position? (y/n) ");

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    char choicePosition = '0';

                    Console.WriteLine("1. Worker");
                    Console.WriteLine("2. Intern");
                    Console.WriteLine("3. Manager");

                    while (choicePosition != '1' && choicePosition != '2' && choicePosition != '3')
                    {
                        choicePosition = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        switch (choicePosition)
                        {
                            case '1':
                                newWorker = new Worker(department);
                                break;
                            case '2':
                                newWorker = new Intern(department);
                                break;
                            case '3':
                                newWorker = new Manager(department);
                                break;
                            default:
                                Console.Write("Error. Try again: ");
                                break;
                        }
                    }
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }
            #endregion

            #region Уточнение фамилии сотрудника
            Console.Write("Do you want to specify the worker's last name? (y/n) ");

            choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    Console.Write("Type the last name: ");
                    newWorker.LastName = Console.ReadLine();
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }
            #endregion

            #region Уточнение имени сотрудника
            Console.Write("Do you want to specify the worker's first name? (y/n) ");

            choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    Console.Write("Type the first name: ");
                    newWorker.FirstName = Console.ReadLine();
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }
            #endregion

            #region Уточнение возраста сотрудника
            Console.Write("Do you want to specify the worker's age? (y/n) ");

            choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    Console.Write("Type the age: ");
                    newWorker.Age = Convert.ToInt32(Console.ReadLine());
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }
            #endregion

            #region Уточнение зарплаты сотрудника (если не менеджер)

            if (newWorker.GetType() != typeof(Manager))
            {
                Console.Write("Do you want to specify the worker's salary? (y/n) ");

                choice = '0';

                while (choice != 'y' && choice != 'n')
                {
                    choice = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    if (choice == 'y')
                    {
                        Console.Write("Type the salary: ");
                        newWorker.Salary = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (choice != 'n')
                    {
                        Console.Write("Error. Try again: ");
                    }
                }
            }

            #endregion

            #region Уточнение количества проектов сотрудника
            Console.Write("Do you want to specify the worker's projects count? (y/n) ");

            choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    Console.Write("Type the projects count: ");
                    newWorker.ProjectsCount = Convert.ToInt32(Console.ReadLine());
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }
            #endregion

            Console.WriteLine();
            Console.WriteLine("Creating the worker...");

            department.add(newWorker);

            Console.WriteLine("Done.");
            Console.WriteLine();

            return newWorker;
        }

        public Worker changeWorker(Worker worker)
        {
            // Переменная для получения выбора действия пользователя при работе с программой
            char choice = '0';

            #region Предложение изменить фамилию сотрудника
            Console.Write("Do you want to change the worker's last name? (y/n) ");

            choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    Console.Write("Type the new last name: ");
                    worker.LastName = Console.ReadLine();
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }
            #endregion

            #region Предложение изменить имя сотрудника
            Console.Write("Do you want to change the worker's first name? (y/n) ");

            choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    Console.Write("Type the new first name: ");
                    worker.FirstName = Console.ReadLine();
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }
            #endregion

            #region Предложение изменить возраст сотрудника
            Console.Write("Do you want to change the worker's age? (y/n) ");

            choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    Console.Write("Type the new age: ");
                    worker.Age = Convert.ToInt32(Console.ReadLine());
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }
            #endregion

            #region Предложение изменить зарплату сотрудника
            Console.Write("Do you want to change the worker's salary? (y/n) ");

            choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    Console.Write("Type the new salary: ");
                    worker.Salary = Convert.ToInt32(Console.ReadLine());
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }
            #endregion

            #region Предложение изменить количество проектов сотрудника
            Console.Write("Do you want to change the worker's projects count? (y/n) ");

            choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    Console.Write("Type the new projects count: ");
                    worker.ProjectsCount = Convert.ToInt32(Console.ReadLine());
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }
            #endregion

            Console.WriteLine();
            Console.WriteLine("Changing the worker...");
            Console.WriteLine("Done.");
            Console.WriteLine();

            return worker;
        }

        public void deleteWorker(Worker worker)
        {
            Console.Write("Are you sure? (y/n) ");

            char choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    worker.Department.remove(worker);
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }

            Console.WriteLine("Done.");
            Console.WriteLine();
        }

        public void deleteWorkers(Department department, ObservableCollection<Worker> workers)
        {
            Console.Write("Are you sure? (y/n) ");

            char choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    department.remove(workers);
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }

            Console.WriteLine("Done.");
            Console.WriteLine();
        }

        public void deleteWorkersByLastName(Department department)
        {
            // Просим указать фамилию
            Console.Write("Type the last name: ");
            
            try
            {
                string lastName = Console.ReadLine();

                // Удаляем соответствующих сотрудников из департамента
                deleteWorkers(department, department.findWorkersByLastName(lastName));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void deleteWorkersByFirstName(Department department)
        {
            // Просим указать имя
            Console.Write("Type the first name: ");
            
            try
            {
                string firstName = Console.ReadLine();

                // Удаляем соответствующих сотрудников из департамента
                deleteWorkers(department, department.findWorkersByFirstName(firstName));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void deleteWorkersByAge(Department department)
        {
            // Просим указать возраст
            Console.Write("Type the age: ");
            
            try
            {
                int age = Convert.ToInt32(Console.ReadLine());

                // Удаляем соответствующих сотрудников из департамента
                deleteWorkers(department, department.findWorkersByAge(age));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void deleteWorkersBySalary(Department department)
        {
            // Просим указать зарплату
            Console.Write("Type the salary: ");

            try
            {
                int salary = Convert.ToInt32(Console.ReadLine());

                // Удаляем соответствующих сотрудников из департамента
                deleteWorkers(department, department.findWorkersBySalary(salary));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void deleteWorkersByProjectsCount(Department department)
        {
            // Просим указать количество проектов
            Console.Write("Type the projects count: ");

            try
            {
                int projectsCount = Convert.ToInt32(Console.ReadLine());

                // Удаляем соответствующих сотрудников из департамента
                deleteWorkers(department, department.findWorkersByProjectsCount(projectsCount));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}