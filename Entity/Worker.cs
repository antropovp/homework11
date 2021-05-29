using Homework_11.Repository.Implementation;

namespace Homework_11.Entity
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Worker
    {
        //[JsonConverter(typeof(DepartmentConverterJson<Department>))]
        public Department Department { get; set; }

        public string LastName { get; set; } = "Undefined";

        public string FirstName { get; set; } = "Undefined";

        public int Age { get; set; } = 0;

        public int Salary { get; set; } = 0;

        public int ProjectsCount { get; set; } = 0;

        protected Worker()
        {

        }

        protected Worker(Department department)
        {
            Department = department;
        }

        protected Worker(Department department, string lastName, string firstName, int age, int salary, int projectsCount)
        {
            Department = department;
            LastName = lastName;
            FirstName = firstName;
            Age = age;
            Salary = salary;
            ProjectsCount = projectsCount;
        }

        public string getSalary()
        {
            return Salary + "/hour";
        }

        public override string ToString()
        {
            string result = $"Last name: {LastName}\n";
            result += $"First name: {FirstName}\n";
            result += $"Age: {Age}\n";
            result += $"Salary: {Salary}\n";
            result += $"ProjectsCount: {ProjectsCount}";

            return result;
        }
    }
}