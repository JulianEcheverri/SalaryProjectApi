using SalaryPorject.Business.Enumerations;

namespace SalaryPorject.Business.Factories
{
    public class SalaryFactory
    {
        public static ISalaryFactory SalaryFactoryCreator(EContractType eContractType, double hourlySalary, double monthlySalary)
        {
            switch (eContractType)
            {
                case EContractType.HourlySalaryEmployee:
                    return new HourlySalary(hourlySalary);
                case EContractType.MonthlySalaryEmployee:
                    return new MonthlySalary(monthlySalary);
                default:
                    return null;
            }
        }
    }
}
