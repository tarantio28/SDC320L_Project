// Clint A. Hester
// 10/26/2025
// Assignment: SDC320L Project Week 3
// Purpose: Console app entry point; demonstrates abstraction, constructors, and access specifiers.

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // ----------- Week 3 Header / Indicator -----------
        Console.WriteLine("==============================================");
        Console.WriteLine("SDC320L - Project Week 3: Abstraction / Ctors / Access");
        Console.WriteLine("Author: Clint A. Hester");
        Console.WriteLine("==============================================\n");

        // ----------- Welcome / Instructions -----------
        Console.WriteLine("Welcome! This demo shows:");
        Console.WriteLine("  • Abstraction via an abstract Employee base class");
        Console.WriteLine("  • Constructor overloading in every class");
        Console.WriteLine("  • Proper access specifiers (public/protected/private)");

        // ----------- Instantiate using various constructors -----------
        // Full constructors
        var salaried   = new SalariedEmployee("John Cortes", 101, 80_000.00, 500.00);
        var hourly     = new HourlyEmployee("Justyn Cushing", 102, 25.50, 40.0);
        var commission = new CommissionEmployee("Clint Hester", 103, 45_000.00, 0.15, 50_000.00);

        // Default/overloaded constructors (showing constructor overloading in action)
        var hourlyDefault = new HourlyEmployee(); // uses defaults from base & self
        var salariedBasic = new SalariedEmployee("Terry Lane", 104, 60_000.00, 250.00);

        // ----------- Polymorphism via abstract base -----------
        var employees = new List<Employee> { salaried, hourly, commission, hourlyDefault, salariedBasic };

        Console.WriteLine("----- Employee Details (Abstract Base Polymorphism) -----");
        foreach (var e in employees)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine("-----");
        }

        // ----------- Polymorphism via interface -----------
        Console.WriteLine("\n----- Actions (Interface Polymorphism) -----");
        foreach (var e in employees)
        {
            PrintEmployeeAction(e); // Method takes IActionable (interface), receives Employee instances
        }

        // ----------- Abstraction Q&A prompts (on-screen explanations) -----------
        Console.WriteLine("\n----- How we used Abstraction this week -----");
        Console.WriteLine("• We introduced an abstract Employee base with abstract methods:");
        Console.WriteLine("    - CalculateWeeklyPay(), GetTask(), GetStatus()");
        Console.WriteLine("• Inheriting classes benefit by sharing identity/pay logic while");
        Console.WriteLine("  supplying their own pay calculations and behaviors.");
        Console.WriteLine("• The app benefits by allowing uniform handling (lists of Employee),");
        Console.WriteLine("  easier extension (add new types without changing Program), and safer APIs.\n");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    // Accepts any IActionable object — demonstrates interface-based polymorphism.
    private static void PrintEmployeeAction(IActionable actionable)
        => Console.WriteLine($"Task: {actionable.GetTask()} | Status: {actionable.GetStatus()}");
}

