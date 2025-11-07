Employee Manager (Console + SQLite)
Author: Clint A. Hester
Phase: Final Project (Consolidated)
Tech: C# (.NET), Console UI, OOP (abstraction, inheritance, interfaces, composition), SQLite (CRUD)

————————————————————————————————————

OVERVIEW
Employee Manager is a console application that demonstrates solid object-oriented design with persistent storage. Users can view polymorphic employee details (Salaried, Hourly, Commission), and the app performs full CRUD against a local SQLite database.

This project evolved across four weeks:
• Week 1: User interaction plan
• Week 2: System design + class responsibilities
• Week 3: OOP techniques (abstraction, constructors, access specifiers, polymorphism)
• Week 4: SQLite database (create table + CRUD)

————————————————————————————————————

FEATURES
• OOP: Abstract base class Employee with CalculateWeeklyPay(), GetTask(), GetStatus(); derived types SalariedEmployee, HourlyEmployee, CommissionEmployee; interface IActionable; composition via Pay.
• Data: SQLite storage with full Create / Read / Update / Delete.
• Console UI: Clear headers, instructions, and readable output blocks.

————————————————————————————————————

ARCHITECTURE (FILE LAYOUT)
/src
Program.cs
IActionable.cs
Pay.cs
Employee.cs
SalariedEmployee.cs
HourlyEmployee.cs
CommissionEmployee.cs
SQLiteDatabase.cs
EmployeeRecord.cs
EmployeeDb.cs
ClintHester_Employees.db (generated at runtime)
README.md
/docs
User_Interaction_Week1.pdf
Design_Document_Week2.pdf
Screenshots_Final.docx
video_link.txt

CLASS RESPONSIBILITIES (BRIEF)
• Employee (abstract): Identity + pay composition; enforces CalculateWeeklyPay(), GetTask(), GetStatus().
• SalariedEmployee / HourlyEmployee / CommissionEmployee: Implement pay rules and role-specific details.
• Pay: Encapsulates base/annual or hourly rate with validation.
• IActionable: Shared behavior contract for task/status.
• SQLiteDatabase: Opens/creates DB file, returns SQLiteConnection.
• EmployeeRecord: Simple data transfer object (table row model).
• EmployeeDb: Table creation + CRUD with parameterized SQL.

————————————————————————————————————

DATABASE SCHEMA
Table: Employees
• EmployeeId INTEGER PRIMARY KEY
• Name TEXT NOT NULL
• Type TEXT NOT NULL (Salaried | Hourly | Commission)
• PayRate REAL
• WeeklyBonus REAL
• HoursWorked REAL
• CommissionRate REAL
• TotalSales REAL

————————————————————————————————————

RUN LOCALLY

Install dependencies
dotnet restore
dotnet add package System.Data.SQLite --version 1.0.116

Build & run
dotnet build
dotnet run

What you’ll see
• Week 3 abstraction/polymorphism demo
• Week 4 SQLite CRUD demo (Create → Read → Update → Delete)

————————————————————————————————————

PROJECT SUMMARY
Problem: Demonstrate full software development lifecycle using C#, OOP principles, and persistent data storage.
Approach: Designed user flow and architecture first; implemented object-oriented structure with abstraction, constructors, interfaces, and proper access specifiers; then integrated a SQLite database with full CRUD.
Outcome: A fully functional console-based Employee Manager showing clean class hierarchy, encapsulated design, and persistent storage.

