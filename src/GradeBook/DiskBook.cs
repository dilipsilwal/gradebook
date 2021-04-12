using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }
        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
          using (var writer=File.AppendText($"{Name}.txt"))  //using will close the connection at the end of the operation, behind the scences the compiler has something like finally to close the connection
          {
            writer.WriteLine(grade);
            if (GradeAdded !=null)
            {
                    GradeAdded (this, new EventArgs());
            }
          } //dispose
      }

        public override Statistics GetStatistics()
        {
           var result = new Statistics();            
           
           using(var Reader= File.OpenText($"{Name}.txt"))
           {

                 var line= Reader.ReadLine();
                 while (line!=null)
                 {
                    var number =double.Parse(line);  
                    result.Add(number);
                    line= Reader.ReadLine();
                
                 }

           }

           return result;
        }
    }
}