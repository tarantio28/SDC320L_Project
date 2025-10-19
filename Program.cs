// Clint A. Hester
// 10/19/2025
// Assignment: SDC320L Project 2.2
// Purpose: Main class to run and test the application.

using System;
using System.Collections.Generic; // Required for using List<>

class Program
{
    static void Main(string[] args)
    {
        // 1. Display Header
        Console.WriteLine("Project Week 2");
        Console.WriteLine("Employee Management Application");
        Console.WriteLine("By: Clint A. Hester");
        Console.WriteLine("----------------------------------\n");

        // 2. Welcome Message
        Console.WriteLine("Welcome! This application demonstrates Polymorphism and Interfaces.");
        Console.WriteLine("We will create 3 different employee types and display their info.\n");

        // 3. Instantiate all classes
        SalariedEmployee salaried = new SalariedEmployee("Jane Doe", 101, 80000.00, 500.00);
        HourlyEmployee hourly = new HourlyEmployee("John Smith", 102, 25.50, 40.0);
        CommissionEmployee commission = new CommissionEmployee("Bob White", 103, 45000.00, 0.15, 50000.00);

        // 4. DEMONSTRATES: Polymorphism using a base class List.
        List<Employee> employeeList = new List<Employee>();
        employeeList.Add(salaried);
        employeeList.Add(hourly);
        employeeList.Add(commission);

        Console.WriteLine("----- Displaying Info via Polymorphism (Inheritance) -----");
        // When we call ToString(), the system polymorphically calls the
        // correct overridden method from the derived class.
        foreach (Employee emp in employeeList)
        {
            Console.WriteLine(emp.ToString());
            Console.WriteLine("-----");
        }

        // 5. DEMONSTRATES: Polymorphism using an interface.
        Console.WriteLine("\n----- Displaying Info via Polymorphism (Interface) -----");
        foreach (Employee emp in employeeList)
        {
            // We pass an 'Employee' object, but the method
            // accepts an 'IActionable' object.
            PrintEmployeeAction(emp);
        }

        // Keep the console window open
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    // This method accepts any object that implements the IActionable interface.
    // This is polymorphism via interface.
    private static void PrintEmployeeAction(IActionable employee)
    {
        Console.WriteLine($"Task: {employee.GetTask()} | Status: {employee.GetStatus()}");
    }
}
