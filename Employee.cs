// Clint A. Hester
// 10/19/2025
// Assignment: SDC320L Project 2.2
// Purpose: Base class for all employees. Demonstrates composition.

using System;

public class Employee : IActionable
{
    public string EmployeeName { get; set; }
    public int EmployeeId { get; set; }
    
    // Composition: Employee "has a" Pay object.
    protected Pay employeePay;

    // Constructor
    public Employee(string name, int id, double payRate)
    {
        EmployeeName = name;
        EmployeeId = id;
        employeePay = new Pay(payRate);
    }

    // Virtual method to allow overriding by child classes.
    public virtual string GetEmployeeInfo()
    {
        return string.Format("Employee Name: {0}\nEmployee ID: {1}\n{2}", 
            EmployeeName, EmployeeId, employeePay.GetPayInfo());
    }

    // Override to provide formatted class data.
    public override string ToString()
    {
        return GetEmployeeInfo();
    }

    public virtual string GetTask()
    {
        return "Handling general employee duties.";
    }

    public virtual string GetStatus()
    {
        return "Active";
    }
}