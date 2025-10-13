// Clint A. Hester
// 10/12/2025
// Assignment: SDC320L Project 1.5
// Purpose: Represents pay details for an employee.

using System;
using System.Globalization;

public class Pay
{
    public double PayRate { get; set; }

    // Constructor
    public Pay(double rate)
    {
        PayRate = rate;
    }

    // Formats pay rate as currency.
    public string GetPayInfo()
    {
        return string.Format("Annual Pay: {0:C}", PayRate);
    }
}