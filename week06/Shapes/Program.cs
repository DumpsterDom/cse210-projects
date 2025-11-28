using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // list of Shapes
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 4));
        shapes.Add(new Rectangle("Blue", 5, 6));
        shapes.Add(new Circle("Green", 3));
        shapes.Add(new Square("Yellow", 2.5));
        shapes.Add(new Rectangle("Purple", 3, 8));

        // Iterate the list
        Console.WriteLine("=== All Shapes ===\n");
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"{color} shape -> Area: {area:F2}");
        }
    }
}