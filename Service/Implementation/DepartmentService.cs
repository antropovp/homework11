using System;
using System.Collections.Generic;
using Homework_11.Repository;
using Homework_11.Repository.Implementation;

namespace Homework_11.Service.Implementation
{
    /// <summary>
    /// Сервис для работы с департаментами
    /// </summary>
    public class DepartmentService : IDepartmentService
    {
        public Department createDepartment(Department parentDepartment)
        {
            // Создаём экземпляр департамента
            Department newDepartment = new Department(parentDepartment);

            // Переменная для получения выбора действия пользователя при работе с программой
            char choice = '0';

            #region Уточнение названия департамента
            Console.Write("Do you want to specify the department's name? (y/n) ");

            choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    Console.Write("Type the name: ");
                    newDepartment.Name = Console.ReadLine();
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }
            #endregion

            Console.WriteLine();
            Console.WriteLine("Creating the department...");

            parentDepartment.add(newDepartment);

            Console.WriteLine("Done.");
            Console.WriteLine();

            return newDepartment;
        }

        public Department changeDepartment(Department department)
        {
            // Переменная для получения выбора действия пользователя при работе с программой
            char choice = '0';

            #region Предложение изменить название департамента
            Console.Write("Do you want to change the department's name? (y/n) ");

            choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    Console.Write("Type the new name: ");
                    department.Name = Console.ReadLine();
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }
            #endregion

            Console.WriteLine();
            Console.WriteLine("Changing the department...");
            Console.WriteLine("Done.");
            Console.WriteLine();

            return department;
        }

        public void clearWorkers(Department department)
        {
            Console.Write("Are you sure? (y/n) ");

            char choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    department.Workers.Clear();
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }

            Console.WriteLine("Done.");
            Console.WriteLine();
        }

        public void clearDepartments(Department department)
        {
            Console.Write("Are you sure? (y/n) ");

            char choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    department.Departments.Clear();
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }

            Console.WriteLine("Done.");
            Console.WriteLine();
        }

        public void deleteDepartment(Department department)
        {
            Console.Write("Are you sure? (y/n) ");

            char choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    department.ParentDepartment.remove(department);
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }

            Console.WriteLine("Done.");
            Console.WriteLine();
        }

        public void deleteDepartments(Department parentDepartment, List<Department> departments)
        {
            Console.Write("Are you sure? (y/n) ");

            char choice = '0';

            while (choice != 'y' && choice != 'n')
            {
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    parentDepartment.remove(departments);
                }
                else if (choice != 'n')
                {
                    Console.Write("Error. Try again: ");
                }
            }

            Console.WriteLine("Done.");
            Console.WriteLine();
        }

        public void deleteDepartmentsByDateOfCreation(Department parentDepartment)
        {
            // Просим указать дату создания
            Console.Write("Type the date of creation: ");

            try
            {
                DateTime dateOfCreation = Convert.ToDateTime(Console.ReadLine());

                // Удаляем соответствующие департаменты
                deleteDepartments(parentDepartment, parentDepartment.findDepartmentsByDateOfCreation(dateOfCreation));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void deleteDepartmentsByName(Department parentDepartment)
        {
            // Просим указать название
            Console.Write("Type the name: ");

            try
            {
                string name = Console.ReadLine();

                // Удаляем соответствующие департаменты
                deleteDepartments(parentDepartment, parentDepartment.findDepartmentsByName(name));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void deleteDepartmentsByWorkersCount(Department parentDepartment)
        {
            // Просим указать количество сотрудников
            Console.Write("Type the workers count: ");

            try
            {
                int workersCount = Convert.ToInt32(Console.ReadLine());

                // Удаляем соответствующие департаменты
                deleteDepartments(parentDepartment, parentDepartment.findDepartmentsByWorkersCount(workersCount));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}