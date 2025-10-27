// Clint A. Hester
// 10/26/2025
// Assignment: SDC320L Project Week 3
// Purpose: Salaried employee; overrides abstract methods.

using System;

public class SalariedEmployee : Employee
{
    // Weekly bonus should not be freely writable from outside; keep setter protected.
    public double WeeklyBonus { get; protected set; }

    // Constructors
    public SalariedEmployee() : this("Unknown", 0, 0.0, 0.0) { }

    public SalariedEmployee(string name, int id, double annualRate, double weeklyBonus)
        : base(name, id, annualRate)
    {
        WeeklyBonus = weeklyBonus;
    }

    // ABSTRACTION: specific pay rule for salaried
    public override double CalculateWeeklyPay()
        => (employeePay?.PayRate ?? 0.0) / 52.0 + WeeklyBonus;

    // Detailed info for UI/report
    public override string ToString()
        => $"{GetHeaderInfo()}\nType: Salaried\nWeekly Bonus: {WeeklyBonus:C}\nWeekly Pay: {CalculateWeeklyPay():C}";

    // IActionable
    public override string GetTask()   => "Leading initiatives and completing salaried assignments.";
    public override string GetStatus() => "Active (Salaried)";
}
