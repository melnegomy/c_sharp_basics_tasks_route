using System;
using System.Linq.Expressions;

class Program
{
    static void Main()
    {

        #region Q1
        //What will this print and explain what happens ?
        //double d = 9.99;
        //int x = (int)d;
        //Console.WriteLine(x);
        #endregion

        #region Q1_Answer
        // This will print 9.
        // When we cast a double to an int, it truncates the decimal part and keeps only the whole number part.
        // So, 9.99 becomes 9 when cast to an int.
        #endregion



        #region Q2
        // This code doesn’t compile. Fix it with the smallest change?
        //int n = 5;
        //double d2 = n / 2.0;
        //Console.WriteLine(d2);
        #endregion

        #region Q2_Answer
        //int n = 5;
        //double d2 = n / 2.0;
        //Console.WriteLine(d2);
        //--------------
        //int n = 5;
        //double d2 = (double)n / 2;
        //Console.WriteLine(d2);
        #endregion



        #region Q3
        // You read a number from user input ..
        // Write the correct line to get age as int.
        #endregion

        #region Q3_Answer
        // Console.WriteLine("Enter your age:");
        //int age = Convert.ToInt32(Console.ReadLine());
        #endregion



        #region Q4
        // What happens here and why?
        //string s = "12a";
        //int x = int.Parse(s);
        //Console.WriteLine(x);
        #endregion

        #region Q4_Answer
        // This will throw a FormatException at runtime.
        // The reason is that the string "12a" cannot be parsed into an integer because it contains a non-numeric character 'a'.
        #endregion



        #region Q5
        // Complete the code from the previous question so it prints
        // Invalid if conversion into int fails,
        // otherwise prints the number
        #endregion

        #region Q5_Answer
        //try
        //{
        //    string s = "12a";
        //    int x = int.Parse(s);
        //    Console.WriteLine(x);
        //}
        //catch (FormatException ex )
        //{
        //    Console.WriteLine("Invalid format: " + ex.Message);
        //}

        #endregion



        #region Q6
        // What will this print and explain why ?
        //object o = 10;
        //int a = (int)o;
        //Console.WriteLine(a + 1);
        #endregion

        #region Q6_Answer
        //1. This will print 11.

        //2. The object 'o' is assigned the value 10, which is a boxed integer.
        //      When we cast it back to an int using (int)o,
        //      it unboxes the value and retrieves the original integer 10.
        //      Then, when we add 1 to it, we get 11.
        #endregion



        #region Q7
        // What will this print and explain why
        // and if there is a problem handle it ?
        //object o = 10;
        //long x = (long)o;
        //Console.WriteLine(x);
        #endregion

        #region Q7_Answer
        // This will throw an InvalidCastException at runtime.
        // The reason is that the object 'o' contains a boxed integer (10),
        // and we are trying to cast it directly to a long.
        //--------------------
        // object o = 10l;
        //long x = (long)o;
        //Console.WriteLine(x);
        //--------------------
        // object o = 10;
        //long x = (int)o;
        //Console.WriteLine(x);
        #endregion



        #region Q8
        // Fix this to avoid exceptions and print -1 if conversion isn’t possible?
        //object o = 10;
        //long x = o;
        //Console.WriteLine(x);
        #endregion

        #region Q8_Answer
        //try 
        //{
        //    object o = 10;
        //    long x = (int)o;
        //    Console.WriteLine(x);
        //}
        //catch
        //{
        //    Console.WriteLine(-1);
        //}
        #endregion


        #region Q9
        // What will this print and explain why ?
        //string? name = null;
        //Console.WriteLine(name?.Length);
        #endregion

        #region Q9_Answer
        // This will print an empty line .
        // The reason is that the null-conditional operator (?.) is used to access the Length property of the string 'name'.
        // Since 'name' is null, the expression 'name?.Length' evaluates to null instead of throwing a NullReferenceException.
        #endregion


        #region Q10  
        // What will this print and explain the process?
        //string? name2 = null;
        //int length = name2?.Length ?? 8;
        #endregion

        #region Q10_Answer
        // This will print 0.
        // The process is as follows:
        // 1. The null-conditional operator (?.) is used to access the Length property of the string 'name2'.
        // 2. Since 'name2' is null, the expression 'name2?.Length' evaluates to null.
        // 3. The null-coalescing operator (??) is then used to provide a default value of 0 when the left-hand side is null.

        #endregion


        #region Q11
        // What’s wrong with this “safe” code and how can we solve it ?
        //string? s = "fff";
        //int x = int.Parse(s ?? "0");
        //Console.WriteLine(x);
        #endregion

        #region Q11_Answer
        // The problem with this code is that it assumes that the string 's' will always be a valid integer or null.
        // If 's' contains a non-numeric string (like "fff"), it will throw a FormatException at runtime when trying to parse it as an integer.
        //string? s = null;

        //if (int.TryParse(s, out int x))
        //{
        //    Console.WriteLine(x);
        //}
        //else
        //{
        //    Console.WriteLine(0);
        //}

        #endregion



        #region Q12
        // What happens here and if there is a problem, handle it
        //string? s = null;
        //Console.WriteLine(s!.Length);
        #endregion

        #region Q12_Answer
        // This will throw a NullReferenceException at runtime.
        //string? s = null;
        //if (s != null)
        //{
        //    Console.WriteLine(s!.Length);

        //}
        //else
        //{
        //    Console.WriteLine("s is null, cannot access Length.");
        //} 

        //--------------------------------------------------

        //string? s = null;
        //Console.WriteLine(s?.Length);

        #endregion



        #region Q13
        // What will this print?
        //string? s = null;
        //int x = Convert.ToInt32(s);
        //Console.WriteLine(x);
        #endregion

        #region Q13_Answer
        // This will print 0.
        // The reason is that the Convert.ToInt32 method returns 0 when the input string is null.
        #endregion



        #region Q14
        // Compare results and explain each result:
        //string? s = null;
        //  A
        //int a = int.Parse(s);
        //  B
        // int b = Convert.ToInt32(s);
        //Console.WriteLine(b);
        #endregion

        #region Q14_Answer
        // A will throw a FormatException at runtime because int.Parse does not handle null values and expects a valid numeric string.
        // B will print 0 because Convert.ToInt32 returns 0 when the input string is null, providing a default value instead of throwing an exception.

        #endregion


        #region Q15
        // Complete the line to print "Guest" when user is null,
        // otherwise print the user name in uppercase:
        // string? user = null;
        #endregion

        #region Q15_Answer

        //string? user = null;
        //string result = user != null ? user.ToUpper() : "Guest";
        //Console.WriteLine(result);

        //---------------

        //if ( user != null)
        //{
        //    Console.WriteLine(user.ToUpper());
        //}
        //else
        //{
        //    Console.WriteLine("Guest");
        //}
        #endregion


    }
}
