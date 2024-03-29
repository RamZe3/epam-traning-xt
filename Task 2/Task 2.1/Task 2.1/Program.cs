﻿using System;
using System.Text;

namespace Task_2._1
{
    // Task 2.1.1
    class CustomString
    {
        private char[] custom_string { get; set; }
        public int Length { get => this.custom_string.Length; }

        public CustomString()
        {
            custom_string = null;
        }

        public CustomString(char[] arr)
        {
            custom_string = arr;
        }

        public CustomString(String stringValue)
        {
            custom_string = new char[stringValue.Length];
            for (int i = 0; i < stringValue.Length; i++)
            {
                custom_string[i] = stringValue[i];
            }
        }

        public CustomString(CustomString customString)
        {
            custom_string = customString.custom_string;
        }

        public int FindByValue(char value)
        {
            for (int i = 0; i < custom_string.Length; i++)
            {
                if (custom_string[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < custom_string.Length; i++)
            {
                sb.Append(custom_string[i]);
            }
            return sb.ToString();
        }

        public char[] ConvertToArray()
        {
            return custom_string;
        }

        public void Append(string addStr)
        {
            char[] answer = new char[custom_string.Length + addStr.Length + 1];
            char[] addStrArr = new char[addStr.Length];
            for (int i = 0; i < addStr.Length; i++)
            {
                addStrArr[i] = addStr[i];
            }
            custom_string.CopyTo(answer, 0);
            addStrArr.CopyTo(answer, custom_string.Length);
            custom_string = answer;
        }

        public void Append(CustomString cs)
        {
            char[] answer = new char[custom_string.Length + cs.Length + 1];
            custom_string.CopyTo(answer, 0);
            cs.custom_string.CopyTo(answer, custom_string.Length);
            custom_string = answer;
        }

        public int Compare(CustomString cs)
        {
            if (custom_string.Length > cs.custom_string.Length)
            {
                return 1;
            }
            else if (custom_string.Length < cs.custom_string.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

    }

    // Task 2.1.2
    public class CreateFigure
    {
        public Figure Create(FigureType type)
        {
            switch (type)
            {
                case FigureType.Point:
                    Console.WriteLine("X Y");
                    return new Point();                   
                case FigureType.Circle:
                    Console.WriteLine("X Y R");
                    return new Circle();
                case FigureType.Ring:
                    Console.WriteLine("X Y R outR");
                    return new Ring();
                case FigureType.Line:
                    Console.WriteLine("X1 Y1 X2 Y2");
                    return new Line();
                case FigureType.Rectangle:
                    Console.WriteLine("X1 Y1 X2 Y2 X3 Y3 X4 Y4");
                    return new Rectangle();
                case FigureType.Triangle:
                    Console.WriteLine("X1 Y1 X2 Y2 X3 Y3");
                    return new Triangle();
                default:
                    return new Point();
            }

        }
    }

    public abstract class Figure
    {
        public override abstract string ToString();
    }

    public enum FigureType : byte
    {
        Point = 0,
        Circle = 1,
        Ring = 2,
        Line = 3,
        Rectangle = 4,
        Triangle = 5,
    }

    public class Point : Figure
    {
        public int x { get; set; }
        public int y { get; set; }

        public Point()
        {
            this.x = int.Parse(Console.ReadLine());
            this.y = int.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            string str = String.Format("X:{0} Y:{1}", this.x, this.y);
            return this.GetType().Name + " " + str;
        }
    }

    public class Circle : Point
    {
        public int r { get; set; }

        public Circle() : base()
        {
            this.r = int.Parse(Console.ReadLine());
        }

        public double CalculateLength() => 2 * Math.PI * this.r;
        public double CalculateArea() => Math.PI * this.r * this.r;

        public override string ToString()
        {
            string str = String.Format(" R:{0}", this.r) +
                " Area: " + (int)this.CalculateArea() +
                " Length: " + (int)this.CalculateLength();
            return base.ToString() + str;
        }
    }

    public class Ring : Circle
    {
        public int outerRadius { get; set; }
        public Ring() : base()
        {
            this.outerRadius = int.Parse(Console.ReadLine());
        }

        public new double CalculateArea() => Math.PI * (this.outerRadius * this.outerRadius - this.r * this.r);
        public new double CalculateLength() => CalculateLength() + 2 * Math.PI * this.outerRadius;

        public override string ToString()
        {
            string str = String.Format(" OuterRadius:{0}", this.outerRadius);
            return base.ToString() + str;
        }
    }

    public class Line : Figure
    {
        public Point point1;
        public Point point2;

        public Line()
        {
            this.point1 = new Point();
            this.point2 = new Point();
        }

        public int Lenth(Point point1, Point point2)
        {
            return (int)Math.Sqrt((point1.x - point2.x) * (point1.x - point2.x) + (point1.y - point2.y) * (point1.y - point2.y));
        }

        public override string ToString()
        {
            string Lenth_ = "Lenth: " + Lenth(this.point1, this.point2).ToString();
            string str = String.Format("X1: {0} Y1: {1} X2: {2} Y2: {3}", this.point1.x, this.point1.y, this.point2.x, this.point2.y);
            return this.GetType().Name + " " + str + " " + Lenth_;
        }
    }

    public class Rectangle : Line
    {
        Point point3;
        Point point4;

        public Rectangle() : base()
        {
            this.point3 = new Point();
            this.point4 = new Point();
        }

        public override string ToString()
        {
            int LenthR = Lenth(this.point1, this.point2) + Lenth(this.point2, this.point3) +
                Lenth(this.point3, this.point4) + Lenth(this.point4, this.point1);

            string str = String.Format("X1: {0} Y1: {1} X2: {2} Y2: {3}\n" +
                "X3: {4} Y3: {5} X4: {6} Y4: {7} Lenth: {8}", this.point1.x, this.point1.y, this.point2.x, this.point2.y, 
                this.point3.x, this.point3.y, this.point4.x, this.point4.y, LenthR);
            return this.GetType().Name + " " + str;
        }
    }

    public class Triangle : Line
    {
        Point point3;

        public Triangle() : base()
        {
            this.point3 = new Point();
        }

        public override string ToString()
        {
            int LenthT = Lenth(this.point1, this.point2) + Lenth(this.point2, this.point3) +
                Lenth(this.point3, this.point1);
            string str = String.Format("X1: {0} Y1: {1} X2: {2} Y2: {3} X3: {4} Y3: {5} Lenth: {6}", this.point1.x, this.point1.y, this.point2.x, this.point2.y,
                this.point3.x, this.point3.y, LenthT);
            return this.GetType().Name + " " + str;
        }
    }


    // Main
    class Program
    {
        public static FigureType ReadFigureType()
        {
            do
            {
                string value = Console.ReadLine();
                if (Enum.TryParse<FigureType>(value, out FigureType result))
                    return result;

            } while (true);
        }

        static void Main(string[] args)
        {
            // Task 2.1.1
            /*char[] arr = { 'd', 'e', 'f' };
            CustomString cs1 = new CustomString("abc");
            CustomString cs2 = new CustomString(arr);
            cs1.Append(cs2);
            cs1.Append("ghi");
            Console.WriteLine("ToString: {0}",cs1.ToString());
            Console.WriteLine("ConvertToArray[0]: {0}", cs1.ConvertToArray()[0]);
            Console.WriteLine("Compare: {0}", cs1.Compare(cs2));
            Console.WriteLine("Length: {0}", cs1.Length);
            */

            // Task 2.1.2
            Figure[] figures = new Figure[100];
            int count = 0;
            CreateFigure createfigure = new CreateFigure();
            while (true)
            {
                string str;
                Console.WriteLine(" Выберите действие\n1.Добавить фигуру\n2.Вывести фигуры\n3.Очистить холст\n4.Выход");
                str = Console.ReadLine();
                if (str == "4")
                {
                    break;
                }
                switch (str)
                {
                    case "1":
                        Console.WriteLine("\nВведите название фигуры\n");
                        Figure figure = createfigure.Create(ReadFigureType());
                        figures[count] = figure;
                        count++;
                        break;
                    case "2":
                        if (count == 0)
                        {
                            Console.WriteLine("\nФигур нет\n");
                            break;
                        }
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine('\n' + figures[i].ToString() + '\n');
                        }
                        break;
                    case "3":
                        figures = new Figure[100];
                        count = 0;
                        break;
                }
            }
        }
    }
}
