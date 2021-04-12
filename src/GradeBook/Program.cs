using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {


            IBook book = new DiskBook("Dilips GradeBook"); // new book  invokes  the constructor Book() Method when its initilized
            book.GradeAdded += OnGradeAdded;
           
            EnterGrade(book);          

            //Static members belong to the class  only , not to its copies (object instance), instance members are not duplicated in the memory.
            //anything static is not associated with the object, it kinda defeeats the purpose of OOP.      

            var stats = book.GetStatistics();  //returns a class object

            System.Console.WriteLine($"HighestGrade is:  {stats.High}");
            System.Console.WriteLine($"LowestGrade is:  {stats.Low}");
            System.Console.WriteLine($"AverageGrade is:  {stats.Average}");
            System.Console.WriteLine($"THe letter grade is is:  {stats.Letter}");

            static void OnGradeAdded(object sender, EventArgs args)
            {

                System.Console.WriteLine(" One Grade Added");

            }

        }

        private static void EnterGrade(IBook book)
        {
            while (true)
            {

                System.Console.WriteLine("Please enter grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);

                }

                catch (ArgumentException ex)
                {

                    System.Console.WriteLine(ex.Message);
                }

                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);

                }

                finally
                {
                    System.Console.WriteLine("Finally Executed");  //this bloack is always executed no matter what
                }
            }
        }
    }
}

 //  book.AddGrade(86.30);
            //  book.AddGrade(89.3);
            //  book.AddGrade(1.1);
            //      var numbers= new [] {22.5,12.8,3.6}; // c sharp compiler will know its an array of double of size 3.
            //      double result=0.0;    
            //    Console.WriteLine(result);
            //    Console.WriteLine($" the Avergae grade is {result/grades.Count:N3}"); //format the output with 3 numbers after the decimal