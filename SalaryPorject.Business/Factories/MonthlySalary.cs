namespace SalaryPorject.Business.Factories
{
    public class MonthlySalary : ISalaryFactory
    {
        public double Salary { set; get; }

        public MonthlySalary(double salary)
        {
            Salary = salary;
        }

        public double GetAnnualSalary() => Salary * 12;
    }
}