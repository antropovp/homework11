using Homework_11.Enum;
using Homework_11.Repository.Implementation;

namespace Homework_11.Entity.Children
{
    public class Manager : Worker
    {
        public override Position Position => Position.MANAGER;

        public Manager() : base() { }

        public Manager(Department department) : base(department) { }

        public Manager(Department department, string lastName, string firstName, int age, int salary, int projectsCount) : base(department, lastName, firstName, age, salary, projectsCount) { }

        int SalaryFixed;
        int SalaryHour;

        public override string getSalary()
        {
            calculateSalary();
            return $"{SalaryHour}/час + {SalaryFixed} фикс";
        }

        public override string getPosition()
        {
            return "Менеджер";
        }

        private void calculateSalary()
        {
            SalaryFixed = 0;
            SalaryHour = 0;

            foreach (Worker worker in Department.Workers)
            {
                if (worker.GetType() == typeof(Intern))
                {
                    SalaryFixed += worker.Salary;
                }
                else
                {
                    SalaryHour += worker.Salary;
                }
            }

            foreach (Department subDepartment in Department.Departments)
            {
                foreach (Worker worker in subDepartment.Workers)
                {
                    if (worker.GetType() == typeof(Intern))
                    {
                        SalaryFixed += worker.Salary;
                    }
                    else if (worker.GetType() == typeof(Manager))
                    {
                        ((Manager) worker).calculateSalary();
                        SalaryFixed += ((Manager)worker).SalaryFixed;
                        SalaryHour += ((Manager) worker).SalaryHour;
                    }
                    else
                    {
                        SalaryHour += worker.Salary;
                    }
                }
            }

            SalaryFixed = SalaryFixed * 15 / 100;
            SalaryHour = SalaryHour * 15 / 100;

            if (SalaryFixed < 1300)
            {
                SalaryFixed = 1300;
            }
        }
    }
}