using Homework_11.Repository.Implementation;

namespace Homework_11.Entity.Children
{
    public class Intern : Worker
    {
        public Intern() : base() {}

        public Intern(Department department) : base(department) {}

        public Intern(Department department, string lastName, string firstName, int age, int salary, int projectsCount) : base(department, lastName, firstName, age, salary, projectsCount) {}

        public new string getSalary()
        {
            return Salary + " fixed";
        }
    }
}