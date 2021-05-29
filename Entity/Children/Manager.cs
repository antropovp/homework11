using Homework_11.Repository.Implementation;

namespace Homework_11.Entity.Children
{
    public class Manager : Worker
    {
        int SalaryHour = 0;
        int SalaryFixed = 0;

        public new string getSalary()
        {
            calculateSalaryHour();
            calculateSalaryFixed();
            return $"{SalaryHour}/hour + {SalaryFixed} fixed";
        }

        private int calculateSalaryHour()
        {
            return 0;
        }

        private int calculateSalaryFixed()
        {
            int resultSalary = 0;

            foreach (Worker worker in Department.Workers)
            {
                if (worker.GetType() == typeof(Intern))
                {
                    resultSalary += worker.Salary;
                }
            }

            foreach (Department subDepartment in Department.Departments)
            {
                foreach (Worker worker in subDepartment.Workers)
                {
                    if (worker.GetType() == typeof(Intern))
                    {
                        resultSalary += worker.Salary;
                    }
                    else if (worker.GetType() == typeof(Manager))
                    {
                        resultSalary += ((Manager)worker).calculateSalaryFixed();
                    }
                }
            }

            resultSalary = resultSalary * 15 / 100;

            if (resultSalary < 1300)
            {
                resultSalary = 1300;
            }

            SalaryFixed = resultSalary;
            return resultSalary;
        }
    }
}