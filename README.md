# FiguresTest

C# test library for calculating the area of a circle by radius and a triangle on three sides.

Despite the task, the library implements additional functionality.

## Implemented classes and interfaces

- `Figures` class: a static class that implements the method for calculating the area of `ISquarable` figures
- `ISquarable` interface: an interface for shapes that can be used to calculate the area
- `Point` class: a class for storing points in two-dimensional space
- `Pointed` class: a class defining an n-gon in two-dimensional space, implements `ISquarable`
- `Triangle` class, implements `Pointed`
- `Circle` class, implements `ISquarable`.

## Library quick test

Code:

```
using System;
using System.Collections.Generic;
using FiguresTest;

namespace FiguresGetter
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Circle circle = new Circle(5.0);
            Console.Write("Circle' square: ");
            Console.WriteLine(Figures.GetSquare(circle));
            Pointed rect = new Pointed(new List<Point>{new Point(0, 0),
                new Point(2, 0), new Point(2, 4), new Point(0, 4)});
            Console.Write("Rect' square: ");
            Console.WriteLine(Figures.GetSquare(rect));
            Triangle triangle = new Triangle(new Point(0, 0), new Point(0, 3),
                new Point(4, 3));
            Console.Write("Triangle' square: ");
            Console.WriteLine(Figures.GetSquare(triangle));
            Console.Write("Lenght of hypotenuse: ");
            Console.WriteLine(new Point(0, 0).Len(new Point(3, 4)));
            Console.Write("Is the triangle right? Answer: ");
            Console.WriteLine(triangle.IsRightTriangle());
        }
    }
}

```

Result:

```
Hello World!
Circle' square: 78,5398163397448
Rect' square: 8
Triangle' square: 6
Lenght of hypotenuse: 5
Is the triangle right? Answer: True
```
