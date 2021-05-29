namespace Homework_11.Entity.Children
{
    public class Intern : Worker
    {
        public new string getSalary()
        {
            return Salary + " fixed";
        }
    }
}