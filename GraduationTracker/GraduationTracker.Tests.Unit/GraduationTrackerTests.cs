/*This is Test class to test all the criteria of 
 * what scenario student will be graduate or fail.
 * 
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasGraduated()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var students = new[]
            {
                new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=100 },
                        new Course{Id = 2, Name = "Science", Mark=100 },
                        new Course{Id = 3, Name = "Literature", Mark=100 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=100 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }
               },

               new Student
               {
                   Id = 3,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
               },

               new Student
               {
                   Id = 4,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=51 },
                        new Course{Id = 2, Name = "Science", Mark=51 },
                        new Course{Id = 3, Name = "Literature", Mark=51 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=51 }
                   }
               },

               new Student
               {
                   Id =5,
                   Courses = new Course[]
                   {
                         new Course{Id = 1, Name = "Math", Mark=40 },
                         new Course{Id = 2, Name = "Science", Mark=40 },
                         new Course{Id = 3, Name = "Literature", Mark=40 },
                         new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                   }
               },

               new Student
               {
                   Id =6,
                   Courses = new Course[]
                   {
                         new Course{Id = 1, Name = "Math", Mark=0 },
                         new Course{Id = 2, Name = "Science", Mark=0 },
                         new Course{Id = 3, Name = "Literature", Mark=0 },
                         new Course{Id = 4, Name = "Physichal Education", Mark=0 }
                   }
               },

               new Student
               {
                   Id =7,
                   Courses = new Course[]
                   {
                         new Course{Id = 1, Name = "Math", Mark=-50 },
                         new Course{Id = 2, Name = "Science", Mark=-50 },
                         new Course{Id = 3, Name = "Literature", Mark=-50 },
                         new Course{Id = 4, Name = "Physichal Education", Mark=-50 }
                   }
               }
            };

            Assert.IsTrue(tracker.HasGraduated(diploma, students[0]).Item1);
            Assert.IsTrue(tracker.HasGraduated(diploma, students[1]).Item1);
            Assert.IsTrue(tracker.HasGraduated(diploma, students[2]).Item1);
            Assert.IsTrue(tracker.HasGraduated(diploma, students[3]).Item1);
            Assert.IsFalse(tracker.HasGraduated(diploma, students[4]).Item1);
            Assert.IsFalse(tracker.HasGraduated(diploma, students[5]).Item1);
            Assert.IsFalse(tracker.HasGraduated(diploma, students[6]).Item1);

            Assert.AreEqual("SumaCumLaude", tracker.HasGraduated(diploma, students[0]).Item2.ToString());
            Assert.AreEqual("SumaCumLaude", tracker.HasGraduated(diploma, students[1]).Item2.ToString());
            Assert.AreEqual("MagnaCumLaude", tracker.HasGraduated(diploma, students[2]).Item2.ToString());
            Assert.AreEqual("Average", tracker.HasGraduated(diploma, students[3]).Item2.ToString());
            Assert.AreEqual("Remedial", tracker.HasGraduated(diploma, students[4]).Item2.ToString());
            Assert.AreEqual("Remedial", tracker.HasGraduated(diploma, students[5]).Item2.ToString());


        }


    }
}
