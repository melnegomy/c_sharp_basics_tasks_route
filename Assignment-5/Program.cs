
using System;

namespace Assignment05
{
    enum DayOfWeek
    {
        Saturday,
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }

    enum Grade
    {
        A,
        B,
        C,
        D,
        F
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Part 1 - Enums
            Console.WriteLine("Part - 1");
            Console.WriteLine("--------------------------------------");

            Console.Write("Enter day number (0-6): ");
            int dayNumber = int.Parse(Console.ReadLine());
            DayOfWeek day = (DayOfWeek)dayNumber;
            Console.WriteLine("Day: " + day);

            switch (day)
            {
                case DayOfWeek.Friday:
                case DayOfWeek.Saturday:
                    Console.WriteLine("Weekend");
                    break;
                default:
                    Console.WriteLine("Workday");
                    break;
            }

            #endregion

            #region Part 2 - Arrays - Q1
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Part - 2 - 1");
            Console.WriteLine("--------------------------------------");


            Console.Write("Enter array size: ");
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter element " + (i + 1) + ": ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;
            int max = arr[0];
            int min = arr[0];

            for (int i = 0; i < size; i++)
            {
                sum += arr[i];
                if (arr[i] > max) max = arr[i];
                if (arr[i] < min) min = arr[i];
            }

            double average = (double)sum / size;

            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Average: " + average);
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Min: " + min);

            Console.WriteLine("Reverse:");
            for (int i = size - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            #endregion


            #region Part 2 - Arrays - Q2
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Part - 2 - 2 ");
            Console.WriteLine("--------------------------------------");


            int[,] grades = new int[3, 4];

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Student " + (i + 1));
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("Enter grade " + (j + 1) + ": ");
                    grades[i, j] = int.Parse(Console.ReadLine());
                }
            }

            double totalAll = 0;

            for (int i = 0; i < 3; i++)
            {
                int studentSum = 0;
                for (int j = 0; j < 4; j++)
                {
                    studentSum += grades[i, j];
                }
                double studentAvg = (double)studentSum / 4;
                Console.WriteLine("Student " + (i + 1) + " Average: " + studentAvg);
                totalAll += studentAvg;
            }

            Console.WriteLine("Class Average: " + (totalAll / 3));

            #endregion


            #region Part 3 - Functions - Q1
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Question - 3 - 1");
            Console.WriteLine("--------------------------------------");



            Console.Write("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());

            Console.Write("Enter operation (+, -, *, /): ");
            string op = Console.ReadLine();

            double result = 0;

            switch (op)
            {
                case "+":
                    result = Add(num1, num2);
                    Console.WriteLine("Result: " + result);
                    break;
                case "-":
                    result = Subtract(num1, num2);
                    Console.WriteLine("Result: " + result);
                    break;
                case "*":
                    result = Multiply(num1, num2);
                    Console.WriteLine("Result: " + result);
                    break;
                case "/":
                    if (num2 == 0)
                        Console.WriteLine("Cannot divide by zero");
                    else
                    {
                        result = Divide(num1, num2);
                        Console.WriteLine("Result: " + result);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }

            #endregion

            #region Part 3 - Functions - Q2
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Question - 3 - 2");
            Console.WriteLine("--------------------------------------");



            Console.Write("Enter circle radius: ");
            double radius = double.Parse(Console.ReadLine());

            CalculateCircle(radius, out double area, out double circumference);

            Console.WriteLine("Area: " + area);
            Console.WriteLine("Circumference: " + circumference);

            #endregion

            #region Mini Project - Student Grade Manager
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Mini Project");
            Console.WriteLine("--------------------------------------");



            int[] scores = new int[5];

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter score for student " + (i + 1) + ": ");
                scores[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < 5; i++)
            {
                Grade g = ToGetGrade(scores[i]);
                Console.WriteLine("Student " + (i + 1) + " Score: " + scores[i] + " Grade: " + g);
            }

            double classAvg = ToCalculateAverage(scores);
            Console.WriteLine("Class Average: " + classAvg);

            ToGetMinMax(scores, out int minScore, out int maxScore);
            Console.WriteLine("Min Score: " + minScore);
            Console.WriteLine("Max Score: " + maxScore);

            #endregion
        }

        static double Add(double a, double b)
        {
            return a + b;
        }

        static double Subtract(double a, double b)
        {
            return a - b;
        }

        static double Multiply(double a, double b)
        {
            return a * b;
        }

        static double Divide(double a, double b)
        {
            return a / b;
        }

        static void CalculateCircle(double radius, out double area, out double circumference)
        {
            area = Math.PI * radius * radius;
            circumference = 2 * Math.PI * radius;
        }

        static Grade ToGetGrade(int score)
        {
            if (score >= 90) return Grade.A;
            else if (score >= 80) return Grade.B;
            else if (score >= 70) return Grade.C;
            else if (score >= 60) return Grade.D;
            else return Grade.F;
        }

        static double ToCalculateAverage(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return (double)sum / arr.Length;
        }

        static void ToGetMinMax(int[] arr, out int min, out int max)
        {
            min = arr[0];
            max = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[i];
            }
        }
    }
}