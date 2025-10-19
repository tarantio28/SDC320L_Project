// Clint A. Hester
// 10/19/2025
// Assignment: SDC320L Project 2.2
// Purpose: Represents an employee paid on commission.

using System;

// Inheritance: CommissionEmployee "is an" Employee.
public class CommissionEmployee : Employee
{
    public double CommissionRate { get; set; }
    public double TotalSales { get; set; }

    // Constructor
    public CommissionEmployee(string name, int id, double baseSalary, double rate, double sales) 
        : base(name, id, baseSalary)
    {
        CommissionRate = rate;
        TotalSales = sales;
    }

    // Override the base method to show commission info.
    public override string GetEmployeeInfo()
    {
        return string.Format("{0}\nCommission Rate: {1:P}\nTotal Sales: {2:C}", 
            base.GetEmployeeInfo(), CommissionRate, TotalSales);
    }
    
    // Override the interface methods.
    public override string GetTask()
    {
        return "Making sales calls.";
    }

    public override string GetStatus()
    {
        return "Active (Commission)";
    }
}