// Clint A. Hester
// 10/12/2025
// Assignment: SDC320L Project 1.5
// Purpose: Represents an employee paid a salary. Demonstrates inheritance.

using System;

// Inheritance: SalariedEmployee "is an" Employee.
public class SalariedEmployee : Employee
{
    public double WeeklyBonus { get; set; }

    // Constructor
    public SalariedEmployee(string name, int id, double annualRate, double bonus) 
        : base(name, id, annualRate) // Call the parent class constructor.
    {
        WeeklyBonus = bonus;
    }

    // Override the base method to add bonus information.
    public override string GetEmployeeInfo()
    {
        // Call the base class method and append bonus info.
        return string.Format("{0}\nWeekly Bonus: {1:C}", 
            base.GetEmployeeInfo(), WeeklyBonus);
    }
}