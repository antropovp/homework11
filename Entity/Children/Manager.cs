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
            return resultSalary;
        }
    }
}