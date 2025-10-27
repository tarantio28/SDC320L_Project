// Clint A. Hester
// 10/26/2025
// Assignment: SDC320L Project Week 3
// Purpose: Hourly employee; overrides abstract methods.

using System;

public class HourlyEmployee : Employee
{
    // Hours are set on creation or by derived classes/this class only.
    public double HoursWorked { get; protected set; }

    // Constructors
    public HourlyEmployee() : this("Unknown", 0, 0.0, 0.0) { }

    public HourlyEmployee(string name, int id, double hourlyRate, double hours)
        : base(name, id, hourlyRate)
    {
        HoursWorked = hours;
    }

    // ABSTRACTION: specific pay rule for hourly
    public override double CalculateWeeklyPay()
        => (employeePay?.PayRate ?? 0.0) * HoursWorked;

    public override string ToString()
        => $"{GetHeaderInfo()}\nType: Hourly\nHourly Rate: {employeePay.PayRate:C}\nHours Worked: {HoursWorked}\nWeekly Pay: {CalculateWeeklyPay():C}";

    // IActionable
    public override string GetTask()   => "Processing widgets on the production line.";
    public override string GetStatus() => "Active (Hourly)";
}
