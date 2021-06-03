using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Homework_11.Converter;
using Homework_11.Entity;
using Newtonsoft.Json;

namespace Homework_11.Repository.Implementation
{
    /// <summary>
    /// Департамент
    /// </summary>
    public class Department : IDepartment
    {
        /// <summary>
        /// Родительский департамент
        /// </summary>
        //[JsonConverter(typeof(DepartmentConverterJson<Department>))]
        public Department ParentDepartment { get; set; }
        public string Name { get; set; } = "UNDEFINED";
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public List<Worker> Workers { get; set; }
        
        //[JsonConverter(typeof(DepartmentListConverterJson<Department>))]
        public List<Department> Departments { get; set; }

        public Department()
        {
            Name = "HEAD DEPARTMENT";
        }

        public Department(Department parentDepartment)
        {
            ParentDepartment = parentDepartment;
        }

        public Department(Department parentDepartment, string name, List<Worker> workers, List<Department> departments)
        {
            ParentDepartment = parentDepartment;
            Name = name;
            Workers = workers;
            Departments = departments;
        }

        /*
         * Добавление сотрудников/департаментов
         */

        public void add(Worker worker)
        {
            if (Workers.Count >= 1_000_000)
            {
                Console.WriteLine("Error. The department is already full.");
                return;
            }
            Workers.Add(worker);
        }

        public void add(Department department)
        {
            Departments.Add(department);
        }

        public void add(List<Worker> workers)
        {
            foreach (Worker worker in workers)
            {
                Workers.Add(worker);
            }
        }

        public void add(List<Department> departments)
        {
            foreach (Department department in departments)
            {
                Departments.Add(department);
            }
        }

        /*
         * Сортировка сотрудников
         */

        public void sortWorkersByLastName()
        {
            Workers = Workers.OrderBy(o => o.LastName).ToList();
        }

        public void sortWorkersByFirstName()
        {
            Workers = Workers.OrderBy(o => o.FirstName).ToList();
        }

        public void sortWorkersByAge()
        {
            Workers = Workers.OrderBy(o => o.Age).ToList();
        }

        public void sortWorkersBySalary()
        {
            Workers = Workers.OrderBy(o => o.Salary).ToList();
        }

        public void sortWorkersByProjectsCount()
        {
            Workers = Workers.OrderBy(o => o.ProjectsCount).ToList();
        }

        /*
         * Сортировка вложенных департаментов
         */

        public void sortDepartmentsByDateOfCreation()
        {
            Departments = Departments.OrderBy(o => o.DateOfCreation).ToList();
        }

        public void sortDepartmentsByName()
        {
            Departments = Departments.OrderBy(o => o.Name).ToList();
        }

        public void sortDepartmentsByWorkersCount()
        {
            Departments = Departments.OrderBy(o => o.Workers.Count).ToList();
        }

        /*
         * Нахождение сотрудников
         */

        public List<Worker> findWorkersByLastName(string lastName)
        {
            // Массив подошедших под условие сотрудников
            List<Worker> matchWorkers = new List<Worker>();

            // Если фамилия сотрудника совпадает с указанной, добавляем этого сотрудника в массив
            foreach (Worker worker in Workers)
            {
                if (worker.LastName == lastName)
                {
                    matchWorkers.Add(worker);
                }
            }

            return matchWorkers;
        }

        public List<Worker> findWorkersByFirstName(string firstName)
        {
            // Массив подошедших под условие сотрудников
            List<Worker> matchWorkers = new List<Worker>();

            // Если имя сотрудника совпадает с указанным, добавляем этого сотрудника в массив
            foreach (Worker worker in Workers)
            {
                if (worker.FirstName == firstName)
                {
                    matchWorkers.Add(worker);
                }
            }

            return matchWorkers;
        }

        public List<Worker> findWorkersByAge(int age)
        {
            // Массив подошедших под условие сотрудников
            List<Worker> matchWorkers = new List<Worker>();

            // Если возраст сотрудника совпадает с указанным, добавляем этого сотрудника в массив
            foreach (Worker worker in Workers)
            {
                if (worker.Age == age)
                {
                    matchWorkers.Add(worker);
                }
            }

            return matchWorkers;
        }

        public List<Worker> findWorkersBySalary(int salary)
        {
            // Массив подошедших под условие сотрудников
            List<Worker> matchWorkers = new List<Worker>();

            // Если зарплата сотрудника совпадает с указанной, добавляем этого сотрудника в массив
            foreach (Worker worker in Workers)
            {
                if (worker.Salary == salary)
                {
                    matchWorkers.Add(worker);
                }
            }

            return matchWorkers;
        }

        public List<Worker> findWorkersByProjectsCount(int projectsCount)
        {
            // Массив подошедших под условие сотрудников
            List<Worker> matchWorkers = new List<Worker>();

            // Если количество проектов сотрудника совпадает с указанным, добавляем этого сотрудника в массив
            foreach (Worker worker in Workers)
            {
                if (worker.ProjectsCount == projectsCount)
                {
                    matchWorkers.Add(worker);
                }
            }

            return matchWorkers;
        }

        /*
         * Нахождение вложенных департаментов
         */

        public List<Department> findDepartmentsByDateOfCreation(DateTime dateOfCreation)
        {
            // Массив подошедших под условие департаментов
            List<Department> matchDepartments = new List<Department>();

            // Если дата создания департамента совпадает с указанной, добавляем этот департамент в массив
            foreach (Department department in Departments)
            {
                if (department.DateOfCreation == dateOfCreation)
                {
                    matchDepartments.Add(department);
                }
            }

            return matchDepartments;
        }

        public List<Department> findDepartmentsByName(string name)
        {
            // Массив подошедших под условие департаментов
            List<Department> matchDepartments = new List<Department>();

            // Если название департамента совпадает с указанным, добавляем этот департамент в массив
            foreach (Department department in Departments)
            {
                if (department.Name == name)
                {
                    matchDepartments.Add(department);
                }
            }

            return matchDepartments;
        }

        public List<Department> findDepartmentsByWorkersCount(int workersCount)
        {
            // Массив подошедших под условие департаментов
            List<Department> matchDepartments = new List<Department>();

            // Если количество сотрудников департамента совпадает с указанным, добавляем этот департамент в массив
            foreach (Department department in Departments)
            {
                if (department.Workers.Count == workersCount)
                {
                    matchDepartments.Add(department);
                }
            }

            return matchDepartments;
        }

        /*
         * Удаление сотрудников/департаментов
         */

        public void remove(Worker worker)
        {
            Workers.Remove(worker);
        }

        public void remove(Department department)
        {
            Departments.Remove(department);
        }

        public void remove(List<Worker> workers)
        {
            foreach (Worker worker in workers)
            {
                Workers.Remove(worker);
            }
        }

        public void remove(List<Department> departments)
        {
            foreach (Department department in departments)
            {
                Departments.Remove(department);
            }
        }

        public override string ToString()
        {
            string result = $"Name: {Name.ToUpper()}\n";
            result += $"Date of creation: {DateOfCreation}\n";
            result += $"Number of workers: {Workers.Count}\n";
            result += $"Number of nested departments: {Departments.Count}";

            return result;
        }
    }
}