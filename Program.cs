// Clint A. Hester
// 11/02/2025
// Assignment: SDC320L Project Week 4
// Purpose: Console app entry point; demonstrates abstraction, constructors,
//          access specifiers, and database CRUD with SQLite.

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

        // ----------- WEEK 4 ADDITIONS: SQLite Database CRUD Demo -----------
        Console.WriteLine("\n==============================================");
        Console.WriteLine("SDC320L - Project Week 4: SQLite CRUD Demo");
        Console.WriteLine("Author: Clint A. Hester");
        Console.WriteLine("==============================================");
        Console.WriteLine("Welcome! This section demonstrates database storage with full CRUD.");
        Console.WriteLine("Instructions: the app will create/connect a DB, create the table if missing,");
        Console.WriteLine("then perform Add, Read, Update, Delete with console output.\n");

        // --- Connect & Ensure Table ---
        const string DbFile = "ClintHester_Employees.db";
        using var conn = SQLiteDatabase.Connect(DbFile);
        if (conn == null)
        {
            Console.WriteLine("Could not open database.");
            return;
        }
        EmployeeDb.CreateTable(conn);

        // --- Create sample rows (from your existing objects) ---
        var salariedRec   = new EmployeeRecord(101, "Chris Redfield",      "Salaried",   80000.00, 500.00, 0,     0,    0);
        var hourlyRec     = new EmployeeRecord(102, "Jill Valentine",    "Hourly",        25.50,   0.00, 40.0,  0,    0);
        var commissionRec = new EmployeeRecord(103, "Albert Whesker",     "Commission", 45000.00,   0.00, 0,     0.15, 50000.00);

        // CREATE
        EmployeeDb.AddEmployee(conn, salariedRec);
        EmployeeDb.AddEmployee(conn, hourlyRec);
        EmployeeDb.AddEmployee(conn, commissionRec);
        Console.WriteLine("CREATE: Added 3 employees.");

        // READ (all)
        Console.WriteLine("\nREAD: All Employees");
        foreach (var r in EmployeeDb.GetAll(conn))
        {
            Console.WriteLine($"#{r.EmployeeId} | {r.Name} | {r.Type} | PayRate: {r.PayRate} | Bonus:{r.WeeklyBonus} | Hours:{r.HoursWorked} | Rate:{r.CommissionRate} | Sales:{r.TotalSales}");
        }

        // UPDATE (example: rename + tweak fields)
        var updated = EmployeeDb.GetById(conn, 101);
        if (updated != null)
        {
            updated.Name = "Crystal Dunn (Updated)";
            updated.WeeklyBonus = 650.00;
            EmployeeDb.Update(conn, updated);
            Console.WriteLine("\nUPDATE: Modified #101 (name/bonus).");
        }

        // READ (single)
        var readBack = EmployeeDb.GetById(conn, 101);
        Console.WriteLine("READ (single): " + (readBack != null
            ? $"#{readBack.EmployeeId} {readBack.Name} Bonus:{readBack.WeeklyBonus}"
            : "Not found"));

        // DELETE
        EmployeeDb.Delete(conn, 102);
        Console.WriteLine("\nDELETE: Removed employee #102 (Hourly).");

        // READ (all) after delete
        Console.WriteLine("\nREAD: All Employees (Post-Delete)");
        foreach (var r in EmployeeDb.GetAll(conn))
        {
            Console.WriteLine($"#{r.EmployeeId} | {r.Name} | {r.Type}");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    // Accepts any IActionable object — demonstrates interface-based polymorphism.
    private static void PrintEmployeeAction(IActionable actionable)
        => Console.WriteLine($"Task: {actionable.GetTask()} | Status: {actionable.GetStatus()}");
}


