// Clint A. Hester
// 11/02/2025
// Assignment: SDC320L Project Week 4
// Purpose: Database connector for SQLite (creates/opens DB).

using System;
using System.Data.SQLite;

public class SQLiteDatabase
{
    public static SQLiteConnection Connect(string databaseFile)
    {
        string cs = @"Data Source=" + databaseFile + ";Version=3;";
        var conn = new SQLiteConnection(cs);
        try { conn.Open(); }
        catch (Exception e) { Console.WriteLine("DB Connect Error: " + e.Message); }
        return conn;
    }
}
