// Clint A. Hester
// 11/02/2025
// Assignment: SDC320L Project Week 4
// Purpose: Represents a single row in Employees table (storage DTO).

public class EmployeeRecord
{
    public int    EmployeeId      { get; set; }
    public string Name            { get; set; }
    public string Type            { get; set; }  // "Salaried" | "Hourly" | "Commission"
    public double PayRate         { get; set; }  // Annual for Salaried/Commission base; Hourly for Hourly
    public double WeeklyBonus     { get; set; }  // Salaried only
    public double HoursWorked     { get; set; }  // Hourly only (last recorded)
    public double CommissionRate  { get; set; }  // Commission only
    public double TotalSales      { get; set; }  // Commission only

    public EmployeeRecord(int employeeId, string name, string type,
                          double payRate, double weeklyBonus, double hoursWorked,
                          double commissionRate, double totalSales)
    {
        EmployeeId     = employeeId;
        Name           = name;
        Type           = type;
        PayRate        = payRate;
        WeeklyBonus    = weeklyBonus;
        HoursWorked    = hoursWorked;
        CommissionRate = commissionRate;
        TotalSales     = totalSales;
    }

    public EmployeeRecord(string name, string type, double payRate)
    {
        Name = name; Type = type; PayRate = payRate;
    }
}
