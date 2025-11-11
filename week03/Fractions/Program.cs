using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(3, 4);
        Fraction f4 = new Fraction(1, 3);

        DisplayFraction(f1);
        DisplayFraction(f2);
        DisplayFraction(f3);
        DisplayFraction(f4);

        Console.WriteLine("\n Testing ");
        Fraction f5 = new Fraction();
        f5.SetTop(2);
        f5.SetBottom(7);
        Console.WriteLine($"{f5.GetFraction()}");
        Console.WriteLine($"{f5.GetDecimal()}");
        Console.WriteLine($"{f5.GetTop()}, Bottom: {f5.GetBottom()}");
    }

    static void DisplayFraction(Fraction f)
    {
        Console.WriteLine(f.GetFraction());
        Console.WriteLine(f.GetDecimal());
    }
}