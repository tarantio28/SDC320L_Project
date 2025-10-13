// Clint A. Hester
// 10/12/2025
// Assignment: SDC320L Project 1.5
// Purpose: Main class to run and test the application.

using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Display Header
        Console.WriteLine("Project Week 1");
        Console.WriteLine("Employee Management Application");
        Console.WriteLine("By: Clint A. Hester");
        Console.WriteLine("----------------------------------\n");

        // 2. Welcome Message
        Console.WriteLine("Welcome! This application demonstrates the class structure for our employee system.");
        Console.WriteLine("Objects will be created and their details displayed below.\n");

        // 3. Create a SalariedEmployee object
        SalariedEmployee salariedEmployee = new SalariedEmployee("Clint Hester", 7837, 75000.00, 250.00);

        // 4. Display its contents
        Console.WriteLine("***** SalariedEmployee class using ToString *****");
        Console.WriteLine(salariedEmployee); // Uses ToString() implicitly
        
        Console.WriteLine("\n*** SalariedEmployee class using GetEmployeeInfo ***");
        Console.WriteLine(salariedEmployee.GetEmployeeInfo()); // Calls the method explicitly

        // Keep the console window open
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
