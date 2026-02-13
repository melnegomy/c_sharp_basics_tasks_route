using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Timers;

namespace assignment_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region answer 1

            #region (a) Inefficient code

            // (a)Why is this code inefficient?
            // -String in C# is IMMUTABLE (cannot be modified)
            // -Each time we use +=, a NEW string is created in memory
            // -The OLD string becomes garbage and needs to be collected
            // -With 5000 iterations:
            //    • 5000 NEW string objects are created
            //    • 5000 OLD string objects become garbage
            //    • Each new string requires memory allocation and copying
            //* -Memory Impact:
            //    • Iteration 1: "PROD-1,"(7 bytes)
            //    • Iteration 2: Copy 7 bytes + add "PROD-2," = 14 bytes
            //    • Iteration 3: Copy 14 bytes + add "PROD-3," = 21 bytes
            #endregion

            #region (b) Efficient code using StringBuilder
            // (b)Rewrite this code using StringBuilder to be more efficient : 

            //var productListBuilder = new StringBuilder();
            //for (int i = 0; i <= 5000; i++)
            //{
            //    productListBuilder.Append("PROD-");
            //    productListBuilder.Append(i);
            //    productListBuilder.Append(",");

            //}
            //string result = productListBuilder.ToString();
            //Console.WriteLine(result);

            #endregion

            #region c stopwatch
            // (c) StopWatch to compare the execution time of both implementations:

            // Stopwatch for string concatenation : 
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string productList = "";
            for (int i = 0; i < 5000; i++)
            {
                productList += "PROD-" + i + ",";
            }
            stopwatch.Stop();
            var stringConcatenationTime = stopwatch.ElapsedTicks;
            Console.WriteLine($"stringConcatenationTime : {stringConcatenationTime}");
            //--------------------------------------------------------
            // Stopwatch for stringBuilder concatenation :
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            var productListBuilder = new StringBuilder();
            for (int i = 0; i <= 5000; i++)
            {
                productListBuilder.Append("PROD-");
                productListBuilder.Append(i);
                productListBuilder.Append(",");
            }
            stopwatch2.Stop();
            var stringBuilderConcatenationTime = stopwatch2.ElapsedTicks;
            Console.WriteLine($"stringBuilderConcatenationTime :{ stringBuilderConcatenationTime}");
            #endregion

            #endregion

            #region answer 2 

            Console.WriteLine("Enter Your Age : ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter day of week (1-7, where 6=Friday, 7=Saturday): ");
            int dayOfWeek = Convert.ToInt32(Console.ReadLine());

            Console.Write("Do you have a student ID? (yes/no): ");
            string studentInput = Console.ReadLine()!.ToLower();
            bool hasStudentId = (studentInput == "yes" || studentInput == "y");

            decimal basePrice = 0;
            decimal weekendSurcharge = 0;
            decimal discount = 0;
            decimal finalPrice = 0;
            string priceBreakdown = "";

            if (age < 5)
            {
                basePrice = 0;
                priceBreakdown += "Base Price: Free (Age < 5)\n";
            }
            else if (age >= 5 && age <= 12)
            {
                basePrice = 30;
                priceBreakdown += $"Base Price: {basePrice} LE (Age 5-12)\n";
            }
            else if (age >= 13 && age <= 59)
            {
                basePrice = 50;
                priceBreakdown += $"Base Price: {basePrice} LE (Age 13-59)\n";
            }
            else
            {
                basePrice = 25;
                priceBreakdown += $"Base Price: {basePrice} LE (Age 60+)\n";
            }


            bool isWeekend = (dayOfWeek == 6 || dayOfWeek == 7);
            if (isWeekend)
            {
                weekendSurcharge = 10;
                priceBreakdown += $"Weekend Surcharge: +{weekendSurcharge} LE\n";
            }
            decimal priceAfterWeekend = basePrice + weekendSurcharge;

            if (hasStudentId && priceAfterWeekend > 0)
            {
                discount = priceAfterWeekend * 0.20m;
                priceBreakdown += $"Student Discount (20%): -{discount} LE\n";
            }
            finalPrice = priceAfterWeekend - discount;


            Console.WriteLine("\n=== Ticket Price Breakdown ===");
            Console.WriteLine(priceBreakdown);
            Console.WriteLine("─────────────────────────────");
            Console.WriteLine($"Final Price: {finalPrice} LE");
            Console.WriteLine("─────────────────────────────");

            #endregion

            #region answer 3
            string fileExtension = ".pdf";
            string fileType;

            switch (fileExtension)
            {
                case ".pdf":
                    fileType = "PDF Document";
                    break;
                case ".docx":
                case ".doc":
                    fileType = "Word Document";
                    break;
                case ".xlsx":
                case ".xls":
                    fileType = "Excel Spreadsheet";
                    break;
                case ".jpg":
                case ".png":
                case ".gif":
                    fileType = "JPEG Image";
                    break;
                default:
                    fileType = "Unknown File Type";
                    break;
            }
            Console.WriteLine($"The File Type Is : {fileType}");

           // ---------------------------------------

             string fileType2 = fileExtension switch
             {
                 ".pdf" => fileType2 = "PDF Document",
                 ".docx" or ".doc" => fileType2 = "Word Document",
                 ".xlsx" or ".xls" => fileType2 = "Excel Spreadsheet",
                 ".jpg" or ".png" or ".gif" => fileType2 = "JPEG Image",
                 _ => fileType2 = "Unknown File Type"
             };
            Console.WriteLine($"The File Type Is : {fileType2}");

            #endregion

            #region answer 4
            int temperature = 35;
            string weatherAdvice =
                temperature < 0 ? "Freezing! Stay indoors." :
                temperature < 15 ? "Cold. Wear a jacket." :
                temperature < 25 ? "Pleasant weather." :
                temperature < 35 ? "Warm. Stay hydrated." :
                "Hot! Avoid sun exposure.";

            Console.WriteLine("Ternary version:");
            Console.WriteLine($"Advice: {weatherAdvice}");

            //------------------------------------------------------

            // The ternary operator is more readable when the condition is simple and returns a value directly.
            // However, for complex or nested conditions, if-else or switch statements are more readable and maintainable.
            #endregion

            #region answer 5

            Console.WriteLine("Password Requirements:");
            Console.WriteLine("• Minimum 8 characters");
            Console.WriteLine("• At least one uppercase letter");
            Console.WriteLine("• At least one digit");
            Console.WriteLine("• No spaces allowed");
            Console.WriteLine("• Maximum 5 attempts\n");

            const int maxAttempts = 5;
            int attemptCount = 0;
            bool isValid = false;

            
            do
            {
                attemptCount++;
                Console.Write($"Attempt {attemptCount}/{maxAttempts} - Enter password: ");
                string password = Console.ReadLine()!;

                
                bool hasMinLength = password.Length >= 8;
                bool hasUpperCase = false;
                bool hasDigit = false;
                bool hasSpace = false;

                
                foreach (char c in password)
                {
                    if (char.IsUpper(c))
                        hasUpperCase = true;

                    if (char.IsDigit(c))
                        hasDigit = true;

                    if (char.IsWhiteSpace(c))
                        hasSpace = true;
                }

                
                isValid = hasMinLength && hasUpperCase && hasDigit && !hasSpace;

                if (isValid)
                {
                    Console.WriteLine("\n✓ Password accepted!");
                    break;
                }
                else
                {
                    Console.WriteLine("\n✗ Password invalid! Violated rules:");

                    if (!hasMinLength)
                        Console.WriteLine("  • Must be at least 8 characters");

                    if (!hasUpperCase)
                        Console.WriteLine("  • Must contain at least one uppercase letter");

                    if (!hasDigit)
                        Console.WriteLine("  • Must contain at least one digit");

                    if (hasSpace)
                        Console.WriteLine("  • Spaces are not allowed");

                    if (attemptCount < maxAttempts)
                    {
                        int remaining = maxAttempts - attemptCount;
                        Console.WriteLine($"\nRemaining attempts: {remaining}\n");
                    }
                }

            } while (!isValid && attemptCount < maxAttempts);
            
            if (!isValid && attemptCount >= maxAttempts)
            {
                Console.WriteLine("Account locked!");
                Console.WriteLine("Maximum attempts exceeded.");
            }

            Console.WriteLine("\n===========================================\n\n");

            #endregion

            #region answer 6
 
            int[] scores = { 85, 42, 91, 67, 55, 78, 39, 88, 72, 95, 60, 48 };

            Console.WriteLine("Exam Scores:");
            Console.WriteLine(string.Join(", ", scores));
            Console.WriteLine($"Total Students: {scores.Length}\n");

            Console.WriteLine("(a) Failing Scores (Below 50):");
            Console.WriteLine("─────────────────────────────────");

            int failingCount = 0;   
            foreach (int score in scores)
            {
                if (score < 50)
                {
                    Console.WriteLine($"  • Score: {score}");
                    failingCount++;
                }
            }
            Console.WriteLine($"Total Failing: {failingCount} students\n");

            Console.WriteLine("(b) First Score Above 90:");
            Console.WriteLine("─────────────────────────────────");

            bool found = false;

            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] > 90)
                {
                    Console.WriteLine($"  Found: {scores[i]} at index {i}");
                    found = true;
                    break;
                }
            }

            if (!found)
                Console.WriteLine("  No score above 90 found");

            Console.WriteLine();


            Console.WriteLine("(c) Class Average (Excluding Absents < 40):");
            Console.WriteLine("─────────────────────────────────");

            int sum = 0;
            int validCount = 0;


            foreach (int score in scores)
            {
                if (score >= 40)
                {
                    sum += score;
                    validCount++;
                }
            }

            if (validCount > 0)
            {
                double average = (double)sum / validCount;
                Console.WriteLine($"  Valid Scores: {validCount}");
                Console.WriteLine($"  Sum: {sum}");
                Console.WriteLine($"  Average: {average:F2}");
            }

            Console.WriteLine();


            Console.WriteLine("(d) Grade Distribution:");
            Console.WriteLine("─────────────────────────────────");

            int gradeA = 0; 
            int gradeB = 0; 
            int gradeC = 0; 
            int gradeD = 0; 
            int gradeF = 0; 


            foreach (int score in scores)
            {
                if (score >= 90 && score <= 100)
                    gradeA++;
                else if (score >= 80 && score < 90)
                    gradeB++;
                else if (score >= 70 && score < 80)
                    gradeC++;
                else if (score >= 60 && score < 70)
                    gradeD++;
                else
                    gradeF++;
            }
            Console.WriteLine($"  A (90-100):  {gradeA} students  {new string('█', gradeA)}");
            Console.WriteLine($"  B (80-89):   {gradeB} students  {new string('█', gradeB)}");
            Console.WriteLine($"  C (70-79):   {gradeC} students  {new string('█', gradeC)}");
            Console.WriteLine($"  D (60-69):   {gradeD} students  {new string('█', gradeD)}");
            Console.WriteLine($"  F (< 60):    {gradeF} students  {new string('█', gradeF)}");

            Console.WriteLine("\n===========================================\n");
            #endregion
        }
    }
}