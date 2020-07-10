using System.Collections.Generic;
using System;

namespace FiguresTest
{
    /*!
     * @class Figures
     * @brief Статичный класс, который реализует единственный метод - вычисление
     * площади фигуры.
     */
    public static class Figures
    {
        public static double GetSquare(ISquarable squarable)
        {
            return squarable.CountSquare();
        }
    }
    /*!
     * @interface ISquarable
     * @brief Интерфейс, задающий метод вычисления площади.
     */
    public interface ISquarable
    {
        double CountSquare();
    }
    /*!
     * @class Point
     * @brief Класс точки на плоскости.
     * @details Содержит два поля - координаты точки в декартовой СК.
     */
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double _x, double _y)
        {
            X = _x;
            Y = _y;
        }
        /*!
         * @fn Len
         * @brief Функция для вычисления длины от текущей точки до другой.
         * @param p2 точка, до которой мы будем вычислять длину
         * @returns длину между точками
         */
        public double Len(Point p2)
        {
            return Math.Pow((X - p2.X) * (X - p2.X) + (Y - p2.Y) * (Y - p2.Y),
                0.5);
        }
    }
    /*!
     * @class Pointed
     * @brief Класс n-угольника.
     * @details Содержит в себе список точек многоугольника, а также реализует
     * метод Гаусса для вычисления площади многоугольника и метод вычисления
     * длины между двумя точками.
     */
    public class Pointed : ISquarable
    {
        protected List<Point> PointList { get; set; }
        public Pointed(List<Point> _pointList)
        {
            PointList = _pointList;
        }
        /*!
         * @fn CountSquare
         * @brief Метод вычисления площади n-угольника.
         * @details Используется формула площади Гаусса для n-угольника. При
         * условии, что точки упорядочены в порядке обхода, даёт правильный
         * результат.
         * @example {@code Pointed rect = new Pointed(new List<Point>{new
         * Point(0, 0), new Point(2, 0), new Point(2, 4), new Point(0, 4)}); }
         * Вышеуказанный код создаёт прямоугольник, причём вершины задаются в
         * порядке обхода.
         * @bug Если задать вершины в ином порядке, метод выдаст нулевую площадь
         * по 2-м причинам:
         * 1) он посчитает, что задан не прямоугольник, а два треугольника,
         * соприкасающихся в центре пересечения диагоналей;
         * 2) он вычтет их площади друг из друга, подобно тому как интеграл не
         * считает площадь под графиком, если график находится ниже прямой y=0.
         * @returns площадь многоугольника
         */
        public double CountSquare()
        {
            double A = 0.0;
            for (int i = 0; i < PointList.Count - 1; i++)
            {
                A += PointList[i].X * PointList[i + 1].Y;
            }
            A += PointList[PointList.Count - 1].X * PointList[0].Y;
            for (int i = 0; i < PointList.Count - 1; i++)
            {
                A -= PointList[i + 1].X * PointList[i].Y;
            }
            A -= PointList[0].X * PointList[PointList.Count - 1].Y;
            return Math.Abs(A) / 2;
        }
    }
    /*!
     * @class Triangle
     * @brief Частный класс Pointed - класс треугольников.
     * @details Задаётся тремя точками и имеет метод определения, правильный ли
     * это треугольник или нет.
     */
    public class Triangle : Pointed
    {
        public Triangle(Point p1, Point p2, Point p3) : base(new List<Point>
            { p1, p2, p3 })
        {
        }
        /*!
         * @fn IsRightTriangle
         * @brief Определяет при помощи теоремы Пифагора, является ли
         * треугольник правильным.
         * @returns булево значение, правильный ли треугольник
         * @retval true треугольник правильный
         * @retval false треугольник остроугольный/тупоугольный
         */
        public bool IsRightTriangle()
        {
            List<double> sides = new List<double>{ PointList[0].Len(
                PointList[1]), PointList[0].Len(PointList[2]),
                PointList[1].Len(PointList[2]) };
            sides.Sort();
            /*! С учётом точности вычисления Math.Pow зададим eps = 0.001
             * для сравнения. */
            return Math.Abs(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) -
                Math.Pow(sides[2], 2)) < 0.001;
        }
    }
    /*!
     * @class Circle
     * @brief Класс круга. Содержит поле радиуса и метод вычисления площади.
     */
    public class Circle : ISquarable
    {
        private double R { get; set; }
        public Circle(double _R)
        {
            R = _R;
        }
        public double CountSquare()
        {
            return Math.PI * R * R;
        }
    }
}
