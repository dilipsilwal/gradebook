using System;
using Xunit;
//using GradeBook;

namespace GradeBook.Tests
{

public delegate string WriteLogDelegate(string logMessage);


    public class TypeTests
    {

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
           WriteLogDelegate log;  //delege type variable

           //log = new WriteLogDelegate(ReturnMessage);
            log = ReturnMessage;  //shorthand for above line
           var result =log("Hello");
           Assert.Equal("Hello",result)
        }
       
       string ReturnMessage(string message)
       {
            return message;
       }

       


       [Fact]
        public void Test1()
       {

           var book1 =GetBook("Book 1");
           GetBookSetName(book1,"NewName");
                     
           Assert.Equal("NewName",book1.Name);
  
        }

        private void GetBookSetName(InMemoryBook bk, string name )
        {
          bk= new InMemoryBook(name);
;      }





        [Fact]    //attribute 
        public void CanSetNameFromReference()
       {

           var book1 =GetBook("Book 1");
           SetName(book1,"NewName");
                     
           Assert.Equal("NewName",book1.Name);
  
        }

        private void SetName(InMemoryBook b, string name )
        {
            b.Name=name;
        }

        [Fact]    //attribute 
        public void GetBookReturnsDifferentObject()
       {
            var book1= GetBook("Book 1");
            var book2= GetBook("Book 2");

           Assert.Equal("Book 1",book1.Name);           
           Assert.Equal("Book 2",book2.Name);
           Assert.NotSame(book1,book2);

        } 


        [Fact]
         public void TwoVarsCanReferenceSameObject()
       {
            var book1= GetBook("Book 1");
            var book2= book1;

           Assert.Same(book1,book2);    
           Assert.True(Object.ReferenceEquals(book1,book2));
          
          
        } 

         InMemoryBook GetBook(string  name)
        {
            return  new InMemoryBook(name); //return what happens when we construct a new instance of the book by using the new keyword
        }
    }
}
