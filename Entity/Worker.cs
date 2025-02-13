﻿using System.Xml.Serialization;
using Homework_11.Entity.Children;
using Homework_11.Enum;
using Homework_11.Repository.Implementation;

namespace Homework_11.Entity
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    [XmlInclude(typeof(Manager))]
    [XmlInclude(typeof(Intern))]
    public class Worker
    {
        public Department Department { get; set; }
        
        public virtual Position Position => Position.WORKER;

        public string LastName { get; set; } = "UNDEFINED";

        public string FirstName { get; set; } = "UNDEFINED";

        public int Age { get; set; } = 0;

        public int Salary { get; set; } = 0;

        public int ProjectsCount { get; set; } = 0;

        [XmlIgnore]
        public string SalaryText => getSalary();

        [XmlIgnore]
        public string PositionText => getPosition();

        public Worker()
        {

        }

        public Worker(Department department)
        {
            Department = department;
        }

        public Worker(Department department, string lastName, string firstName, int age, int salary, int projectsCount)
        {
            Department = department;
            LastName = lastName;
            FirstName = firstName;
            Age = age;
            Salary = salary;
            ProjectsCount = projectsCount;
        }

        public virtual string getSalary()
        {
            return Salary + "/час";
        }

        public virtual string getPosition()
        {
            return "Рабочий";
        }

        public override string ToString()
        {
            string result = $"Position: {Position}\n";
            result += $"Last name: {LastName.ToUpper()}\n";
            result += $"First name: {FirstName.ToUpper()}\n";
            result += $"Age: {Age}\n";
            result += $"Salary: {getSalary()}\n";
            result += $"ProjectsCount: {ProjectsCount}";

            return result;
        }
    }
}