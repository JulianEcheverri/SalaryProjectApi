using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryPorject.Business.Enumerations;
using SalaryPorject.Business.Factories;

namespace SalaryProject.Business.Tests
{
    [TestClass]
    public class SalaryFactoryTest
    {
        [TestMethod]
        public void AnnualSalaryHourlyTest()
        {
            double hourlySalary = 10;
            double MonthlySalary = 50;
            double annualSalaryExpected = 14400;

            ISalaryFactory salaryFactoryObject = SalaryFactory.SalaryFactoryCreator(EContractType.HourlySalaryEmployee, hourlySalary, MonthlySalary);
            double annualSalaryActual = salaryFactoryObject.GetAnnualSalary();

            Assert.AreEqual(annualSalaryExpected, annualSalaryActual, 0.001, "Annual salary is incorrect");
        }
    }
}
