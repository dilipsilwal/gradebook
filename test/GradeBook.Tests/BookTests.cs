using System;
using Xunit;
//using GradeBook;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]    //attribute 
        public void BookCalculatesAnAverageGrade()
        {


            //arrange
            var book =  new InMemoryBook("");
             book.AddGrade(45.23);
             book.AddGrade(13.69);
             book.AddGrade(36.12);
             book.AddGrade(99.32);
            
             


            //act 

            var result= book.GetStatistics();


            //assert
          
            Assert.Equal(48.6,result.Average,1);
            Assert.Equal(99.3,result.High,1);
            Assert.Equal(13.7,result.Low,1);
           

        }
    }
}
