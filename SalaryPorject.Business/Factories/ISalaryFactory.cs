namespace SalaryPorject.Business.Factories
{
    public interface ISalaryFactory
    {
        double Salary { set; get; }
        double GetAnnualSalary();
    }
}
