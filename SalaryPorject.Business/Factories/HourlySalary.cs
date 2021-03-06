﻿namespace SalaryPorject.Business.Factories
{
    public class HourlySalary : ISalaryFactory
    {
        public double Salary { set; get; }

        public HourlySalary(double salary)
        {
            Salary = salary;
        }

        public double GetAnnualSalary() => 120 * Salary * 12;
    }
}