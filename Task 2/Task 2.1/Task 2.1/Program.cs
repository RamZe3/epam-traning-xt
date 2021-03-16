using System;
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

        override
        public string ToString()
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

    public enum FigureType : byte
    {
        Point = 0,
        Circle = 1,
        Ring = 2,
        Line = 3,
        Rectangle = 4,
        Triangle =5,
    }

    

    public class CreateFigure
    {
        public Figure Create(FigureType type)
        {
            switch (type)
            {
                case FigureType.Point:
                    Console.WriteLine("X Y");
                    return new Point(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));                   
                case FigureType.Circle:
                    Console.WriteLine("X Y R");
                    return new Circle(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                case FigureType.Ring:
                    Console.WriteLine("X Y R outR");
                    return new Ring(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                case FigureType.Line:
                    Console.WriteLine("X1 Y1 X2 Y2");
                    return new Line(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                case FigureType.Rectangle:
                    Console.WriteLine("X1 Y1 X2 Y2 X3 Y3 X4 Y4");
                    return new Rectangle(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()),
                        int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                case FigureType.Triangle:
                    Console.WriteLine("X1 Y1 X2 Y2 X3 Y3");
                    return new Triangle(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()),
                        int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                default:
                    return new Point(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            }

        }
    }

    public abstract class Figure
    {
        public override abstract string ToString();
    }


    public class Point : Figure
    {
        public int x { get; set; }
        public int y { get; set; }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        override
        public string ToString()
        {
            string str = String.Format("X:{0} Y:{1}", this.x, this.y);
            return this.GetType().Name + " " + str;
        }

    }

    public class Circle : Point
    {
        public int r { get; set; }

        public Circle(int x, int y, int r) : base(x,y)
        {
            this.r = r;
        }

        public double CalculateLength() => 2 * Math.PI * this.r;

        public double CalculateArea() => Math.PI * this.r * this.r;

        override
        public string ToString()
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
        public Ring(int x, int y, int r, int outerRadius) : base(x,y,r)
        {
            this.outerRadius = outerRadius;
        }

        new
        public double CalculateArea() => Math.PI * (this.outerRadius * this.outerRadius - this.r * this.r);
        new
        public double CalculateLength() => CalculateLength() + 2 * Math.PI * this.outerRadius;

        override
        public string ToString()
        {
            string str = String.Format(" OuterRadius:{0}", this.outerRadius);
            return base.ToString() + str;
        }

    }

    public class Line : Figure
    {
        public Point point1;
        public Point point2;
        public Line(int x1, int y1, int x2, int y2)
        {
            this.point1 = new Point(x1, y1);
            this.point2 = new Point(x2, y2);
        }

        override
        public string ToString()
        {
            string str = String.Format("X1: {0} Y1: {1} X2: {2} Y2: {3}", this.point1.x, this.point1.y, this.point2.x, this.point2.y);
            return this.GetType().Name + " " + str;
        }
    }

    public class Rectangle : Line
    {
        Point point3;
        Point point4;
        public Rectangle(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4) : base(x1, y1, x2, y2)
        {
            this.point3 = new Point(x3, y3);
            this.point4 = new Point(x4, y4);
        }
        override
        public string ToString()
        {
            string str = String.Format("X1: {0} Y1: {1} X2: {2} Y2: {3}\n" +
                "X3: {4} Y3: {5} X4: {6} Y4: {7}", this.point1.x, this.point1.y, this.point2.x, this.point2.y, 
                this.point3.x, this.point3.y, this.point4.x, this.point4.y);
            return this.GetType().Name + " " + str;
        }
    }

    public class Triangle : Line
    {
        Point point3;
        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3) : base(x1, y1, x2, y2)
        {
            this.point3 = new Point(x3, y3);
        }
        override
        public string ToString()
        {
            string str = String.Format("X1: {0} Y1: {1} X2: {2} Y2: {3} X3: {4} Y3: {5}", this.point1.x, this.point1.y, this.point2.x, this.point2.y,
                this.point3.x, this.point3.y);
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
            char[] arr = { 'd', 'e', 'f' };
            CustomString cs1 = new CustomString("abc");
            CustomString cs2 = new CustomString(arr);
            cs1.Append(cs2);
            cs1.Append("ghi");
            Console.WriteLine("ToString: {0}",cs1.ToString());
            Console.WriteLine("ConvertToArray[0]: {0}", cs1.ConvertToArray()[0]);
            Console.WriteLine("Compare: {0}", cs1.Compare(cs2));
            Console.WriteLine("Length: {0}", cs1.Length);

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
                        Console.WriteLine("Введите название фигуры");
                        Figure figure = createfigure.Create(ReadFigureType());
                        figures[count] = figure;
                        count++;
                        break;
                    case "2":
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine(figures[i].ToString());
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
