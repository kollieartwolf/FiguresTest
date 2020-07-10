using System.Collections.Generic;
using System;

namespace FiguresTest
{
    public static class Figures
    {
        public static double GetSquare(ISquarable squarable)
        {
            return squarable.CountSquare();
        }
    }
    public interface ISquarable
    {
        double CountSquare();
    }

    public class Point
    {
        public double _x { get; set; }
        public double _y { get; set; }
        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }
    }

    public class Pointed : ISquarable
    {
        protected List<Point> _pointList { get; set; }
        public Pointed(List<Point> pointList)
        {
            _pointList = pointList;
        }
        public void AddPoint(Point point)
        {
            _pointList.Add(point);
        }
        public double CountSquare()
        {
            /*! Формула площади Гаусса для n-угольника. */
            double A = 0.0;
            for (int i = 0; i < _pointList.Count - 1; i++)
            {
                A += _pointList[i]._x * _pointList[i + 1]._y;
            }
            A += _pointList[_pointList.Count - 1]._x * _pointList[0]._y;
            for (int i = 0; i < _pointList.Count - 1; i++)
            {
                A -= _pointList[i + 1]._x * _pointList[i]._y;
            }
            A -= _pointList[0]._x * _pointList[_pointList.Count - 1]._y;
            return Math.Abs(A) / 2;
        }
        public double Len(Point p1, Point p2)
        {
            return Math.Pow((p1._x - p2._x) * (p1._x - p2._x) + (p1._y - p2._y)
                * (p1._y - p2._y), 0.5);
        }
    }

    public class Triangle : Pointed
    {
        public Triangle(Point p1, Point p2, Point p3) : base(new List<Point>
            { p1, p2, p3 })
        {
        }
        public bool IsRightTriangle()
        {
            List<double> sides = new List<double>{ Len(_pointList[0],
                _pointList[1]),
                Len(_pointList[0], _pointList[2]),
                Len(_pointList[1], _pointList[2]) };
            sides.Sort();
            /*! С учётом точности вычисления Math.Pow зададим eps = 0.001 
             * для сравнения. */
            return Math.Abs(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) -
                Math.Pow(sides[2], 2)) < 0.001;
        }
    }

    public class Circle : ISquarable
    {
        private double _R { get; set; }
        public Circle(double R)
        {
            _R = R;
        }
        public double CountSquare()
        {
            return Math.PI * _R * _R;
        }
    }
}
