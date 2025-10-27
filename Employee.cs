// Clint A. Hester
// 10/26/2025
// Assignment: SDC320L Project Week 3
// Purpose: Abstract base for all employees; demonstrates abstraction, constructors, access specifiers.

using System;

// ABSTRACTION: An abstract base class captures common identity & pay,
// and requires derived classes to supply calculation/description details.
public abstract class Employee : IActionable
{
    // Public identity; setters restricted so only constructors (or protected helpers) can assign.
    public string EmployeeName { get; private set; }
    public int EmployeeId      { get; private set; }

    // Composition: Employee "has a" Pay. Protected so children can read it.
    protected Pay employeePay;

    // ------- Constructors (demonstrates constructor overloading) -------
    protected Employee()
    {
        EmployeeName = "Unknown";
        EmployeeId   = 0;
        employeePay  = new Pay();          // Default rate = 0
    }

    protected Employee(string name, int id)
    {
        EmployeeName = name;
        EmployeeId   = id;
        employeePay  = new Pay();          // Can be set later by child
    }

    protected Employee(string name, int id, double payRate)
    {
        EmployeeName = name;
        EmployeeId   = id;
        employeePay  = new Pay(payRate);
    }

    // Copy constructor (useful for cloning/derivations if needed)
    protected Employee(Employee other)
        : this(other.EmployeeName, other.EmployeeId, other.employeePay?.PayRate ?? 0.0) { }

    // ------- ABSTRACTION: force derived classes to implement these -------
    // What the employee does (used for interface polymorphism too)
    public abstract string GetTask();
    public abstract string GetStatus();

    // Pay logic is abstract so each employee can define it appropriately.
    public abstract double CalculateWeeklyPay();

    // Standardized info header; derived classes append role-specific details.
    public virtual string GetHeaderInfo()
        => $"Employee Name: {EmployeeName}\nEmployee ID: {EmployeeId}\n{employeePay.GetPayInfo()}";

    // Polymorphic string representation
    public override string ToString() => GetHeaderInfo();
}
