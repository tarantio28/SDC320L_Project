// Clint A. Hester
// 10/26/2025
// Assignment: SDC320L Project Week 3
// Purpose: Encapsulates pay details; demonstrates access specifiers.

using System;

public class Pay
{
    // Public getter, but only this class and derived employees (via a method) can change it.
    public double PayRate { get; private set; }

    // Overloaded constructors (constructor overloading demo)
    public Pay() : this(0.0) { }                    // Default
    public Pay(double rate) { SetRate(rate); }      // Primary

    // Encapsulated mutation with input validation (kept non-public in API surface).
    public void SetRate(double rate)
    {
        if (rate < 0) throw new ArgumentOutOfRangeException(nameof(rate), "Pay rate cannot be negative.");
        PayRate = rate;
    }

    public string GetPayInfo() => $"Annual/Base Rate: {PayRate:C}";
}
