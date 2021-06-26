using Homework_11.Enum;
using Homework_11.Repository.Implementation;

namespace Homework_11.Entity.Children
{
    public class Intern : Worker
    {
        public override Position Position => Position.INTERN;

        public Intern() : base() {}

        public Intern(Department department) : base(department) {}

        public Intern(Department department, string lastName, string firstName, int age, int salary, int projectsCount) : base(department, lastName, firstName, age, salary, projectsCount) {}

        public override string getSalary()
        {
            return Salary + " фикс";
        }

        public override string getPosition()
        {
            return "Интерн";
        }
    }
}