// Clint A. Hester
// 10/19/2025
// Assignment: SDC320L Project 2.2
// Purpose: Represents an employee paid by the hour.

using System;

// Inheritance: HourlyEmployee "is an" Employee.
public class HourlyEmployee : Employee
{
    public double HoursWorked { get; set; }

    // Constructor
    public HourlyEmployee(string name, int id, double hourlyRate, double hours) 
        : base(name, id, hourlyRate)
    {
        HoursWorked = hours;
    }

    // Override the base method to show hourly info.
    public override string GetEmployeeInfo()
    {
        // Get base info (Name, ID)
        string baseInfo = string.Format("Employee Name: {0}\nEmployee ID: {1}", EmployeeName, EmployeeId);
        
        return string.Format("{0}\nHourly Rate: {1:C}\nHours Worked: {2}", 
            baseInfo, employeePay.PayRate, HoursWorked);
    }
    
    // Override the interface methods.
    public override string GetTask()
    {
        return "Processing widgets on the line.";
    }

    public override string GetStatus()
    {
        return "Active (Hourly)";
    }
}