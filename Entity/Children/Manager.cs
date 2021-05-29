using Homework_11.Repository.Implementation;

namespace Homework_11.Entity.Children
{
    public class Manager : Worker
    {
        int SalaryFixed = 0;
        int SalaryHour = 0;

        public new string getSalary()
        {
            calculateSalary();
            return $"{SalaryHour}/hour + {SalaryFixed} fixed";
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