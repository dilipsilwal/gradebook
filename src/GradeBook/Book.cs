namespace GradeBook
{
    public abstract class Book : NamedObject,IBook
    {
        protected Book(string name) : base(name)
        {
        }

       public abstract event GradeAddedDelegate GradeAdded;
       public abstract void AddGrade(double grade);
       public abstract Statistics GetStatistics(); //virtual, derived class may or may not chose to implement it, unlike abstract where you need to implement it
        
    }
}