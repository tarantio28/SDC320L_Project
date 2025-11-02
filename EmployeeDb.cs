// Clint A. Hester
// 11/02/2025
// Assignment: SDC320L Project Week 4
// Purpose: Table-level operations for Employees (create table + CRUD).

using System;
using System.Collections.Generic;
using System.Data.SQLite;

public class EmployeeDb
{
    public static void CreateTable(SQLiteConnection conn)
    {
        string sql = @"
CREATE TABLE IF NOT EXISTS Employees(
    EmployeeId     INTEGER PRIMARY KEY,
    Name           TEXT    NOT NULL,
    Type           TEXT    NOT NULL,
    PayRate        REAL,
    WeeklyBonus    REAL,
    HoursWorked    REAL,
    CommissionRate REAL,
    TotalSales     REAL
);";
        using var cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    // CREATE
    public static void AddEmployee(SQLiteConnection conn, EmployeeRecord e)
    {
        const string sql = @"
INSERT INTO Employees(EmployeeId, Name, Type, PayRate, WeeklyBonus, HoursWorked, CommissionRate, TotalSales)
VALUES(@id, @name, @type, @pay, @bonus, @hours, @rate, @sales);";
        using var cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@id",    e.EmployeeId);
        cmd.Parameters.AddWithValue("@name",  e.Name);
        cmd.Parameters.AddWithValue("@type",  e.Type);
        cmd.Parameters.AddWithValue("@pay",   e.PayRate);
        cmd.Parameters.AddWithValue("@bonus", e.WeeklyBonus);
        cmd.Parameters.AddWithValue("@hours", e.HoursWorked);
        cmd.Parameters.AddWithValue("@rate",  e.CommissionRate);
        cmd.Parameters.AddWithValue("@sales", e.TotalSales);
        cmd.ExecuteNonQuery();
    }

    // READ
    public static List<EmployeeRecord> GetAll(SQLiteConnection conn)
    {
        var list = new List<EmployeeRecord>();
        const string sql = "SELECT EmployeeId, Name, Type, PayRate, WeeklyBonus, HoursWorked, CommissionRate, TotalSales FROM Employees;";
        using var cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            list.Add(new EmployeeRecord(
                rdr.GetInt32(0),         // EmployeeId
                rdr.GetString(1),        // Name
                rdr.GetString(2),        // Type
                rdr.IsDBNull(3) ? 0 : rdr.GetDouble(3),
                rdr.IsDBNull(4) ? 0 : rdr.GetDouble(4),
                rdr.IsDBNull(5) ? 0 : rdr.GetDouble(5),
                rdr.IsDBNull(6) ? 0 : rdr.GetDouble(6),
                rdr.IsDBNull(7) ? 0 : rdr.GetDouble(7)
            ));
        }
        return list;
    }

    // READ
    public static EmployeeRecord? GetById(SQLiteConnection conn, int id)
    {
        const string sql = @"SELECT EmployeeId, Name, Type, PayRate, WeeklyBonus, HoursWorked, CommissionRate, TotalSales
                             FROM Employees WHERE EmployeeId=@id;";
        using var cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@id", id);
        using var rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            return new EmployeeRecord(
                rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2),
                rdr.IsDBNull(3) ? 0 : rdr.GetDouble(3),
                rdr.IsDBNull(4) ? 0 : rdr.GetDouble(4),
                rdr.IsDBNull(5) ? 0 : rdr.GetDouble(5),
                rdr.IsDBNull(6) ? 0 : rdr.GetDouble(6),
                rdr.IsDBNull(7) ? 0 : rdr.GetDouble(7)
            );
        }
        return null;
    }

    // UPDATE
    public static void Update(SQLiteConnection conn, EmployeeRecord e)
    {
        const string sql = @"
UPDATE Employees
SET Name=@name, Type=@type, PayRate=@pay, WeeklyBonus=@bonus, HoursWorked=@hours, CommissionRate=@rate, TotalSales=@sales
WHERE EmployeeId=@id;";
        using var cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@id",    e.EmployeeId);
        cmd.Parameters.AddWithValue("@name",  e.Name);
        cmd.Parameters.AddWithValue("@type",  e.Type);
        cmd.Parameters.AddWithValue("@pay",   e.PayRate);
        cmd.Parameters.AddWithValue("@bonus", e.WeeklyBonus);
        cmd.Parameters.AddWithValue("@hours", e.HoursWorked);
        cmd.Parameters.AddWithValue("@rate",  e.CommissionRate);
        cmd.Parameters.AddWithValue("@sales", e.TotalSales);
        cmd.ExecuteNonQuery();
    }

    // DELETE
    public static void Delete(SQLiteConnection conn, int id)
    {
        const string sql = "DELETE FROM Employees WHERE EmployeeId=@id;";
        using var cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}
