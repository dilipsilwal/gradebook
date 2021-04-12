using System;
using System.Collections.Generic;

namespace GradeBook
{
public delegate void GradeAddedDelegate(object sender, EventArgs args); //usually a separate type, in c# a separate file per type, this is an event delegate

    public class InMemoryBook : Book
    {

        //public accesss modifier allows access to code outside of this class , private is only accessieble within the class. 
            public InMemoryBook( string name) : base (name)    //Contructor is used to intitilaize the object (class) , yu can write your own constrctors tto control the initiliazation of the  object instead of the default constructor
            {
                //constructors can be overloaded

                category="Math";
                grades = new List<double>();
                Name =name;  //this is implicit variable , available inside of the construtor or method. used to refer the object that is currently being operated on.
            }

        public override void AddGrade( double grade)
        {

            if (grade<=100 && grade>=0)
            {
                grades.Add(grade);

                if (GradeAdded !=null)
                {
                    GradeAdded(this,new EventArgs());
                }
            }
            else
            {
             throw new ArgumentException($" invalid is {nameof (grade)}");
            }
        }
      
             public List<double> grades ; //declare fieldd( and initialized in constructor)
              string name; //field assigned from constructor

              readonly string category="Scicence ";   // readonly field   can only changed from constructors  or when its intitiliazed
              const float pi =3.145f ;   //constant can not be changed.

 


         public void AddGrade(char Letter) //method overloading , method looks at method signature
         {
             switch(Letter)
             {
                 case 'A':
                 AddGrade(90);
                 break;

                 case 'B':
                 AddGrade(70);
                 break;

                 case 'C':
                 AddGrade(50);
                 break;

                 default:
                 AddGrade(0);
                 break;

             }

         }

        public override event GradeAddedDelegate GradeAdded;
 

        public override Statistics  GetStatistics()
         {
            var result = new Statistics();          

            for(var index=0; index<grades.Count; index +=1)
             {                
                 result.Add(grades[index]);
             }
        
                  
             return result;


         }
    }
}


             
            //   public string  Name
            //   {
            //         get
            //         {
            //            return name;
            //         }

            //         set 
            //         {
            //            if (!String.IsNullOrEmpty(value))
            //              name =value;
            //         }
            //   }