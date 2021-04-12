using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return sum / count;
            }
        }

        public double High;
        public double Low;
        public char Letter
        {
            get
            {

                switch (Average)
                {
                    case var x when x >= 90:
                        return  'A';                       

                    case var x when x >= 80 && x < 90:
                       return 'B';                   

                    case var x when x >= 50 && x < 80:
                        return  'C';                      

                    default:
                        return 'F';                     
                }
            }
        }
        public double sum;
        public int count;


        public Statistics()
        {
            // double Average = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
            sum = 0.0;
            count = 0;
        }



        public void Add(double number)
        {
            sum += number;
            count += 1;

            High = Math.Max(High, number);
            Low = Math.Min(Low, number);


        }

    }
}


