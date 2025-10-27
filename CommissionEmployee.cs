// Clint A. Hester
// 10/26/2025
// Assignment: SDC320L Project Week 3
// Purpose: Commission-based employee; overrides abstract methods.

using System;

public class CommissionEmployee : Employee
{
    public double CommissionRate { get; protected set; }
    public double TotalSales     { get; protected set; }

    // Constructors
    public CommissionEmployee() : this("Unknown", 0, 0.0, 0.0, 0.0) { }

    // Note: PayRate here is *annual base* salary to demonstrate composition like Salaried
    public CommissionEmployee(string name, int id, double baseAnnualSalary, double rate, double sales)
        : base(name, id, baseAnnualSalary)
    {
        CommissionRate = rate;
        TotalSales     = sales;
    }

    // ABSTRACTION: weekly base + weekly commission
    public override double CalculateWeeklyPay()
    {
        double weeklyBase       = (employeePay?.PayRate ?? 0.0) / 52.0;
        double commissionEarned = CommissionRate * TotalSales; // assume weekly period for demo
        return weeklyBase + commissionEarned;
    }

    public override string ToString()
        => $"{GetHeaderInfo()}\nType: Commission\nCommission Rate: {CommissionRate:P}\nTotal Sales: {TotalSales:C}\nWeekly Pay: {CalculateWeeklyPay():C}";

    // IActionable
    public override string GetTask()   => "Making sales calls and closing deals.";
    public override string GetStatus() => "Active (Commission)";
}
