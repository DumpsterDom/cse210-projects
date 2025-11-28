using System;

public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override GetArea for circle: πr²
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}