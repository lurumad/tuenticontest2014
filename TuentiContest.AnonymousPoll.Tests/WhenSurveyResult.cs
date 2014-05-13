using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TuentiContest.AnonymousPoll.Tests
{
    [TestFixture]
    public class WhenSurveyResult
    {
        [Test]
        public void DoesntMatchStudentsProfileReturnsNone()
        {
            var students = CreateListOf();
           
            var result = FindBy("M,21,Human Resources,3", students);

            result.Should().Be("NONE");
        }

        [Test]
        public void MatchWithAtLeastOneStudentProfileReturnsNameOfStudent()
        {
            var students = CreateListOf();

            var result = FindBy("F,22,Scientist,3", students);

            result.Should().Be("Harrys Mon");
        }
        
        [Test]
        public void MatchWithMoreThanOneStudentProfileReturnsAListOfStudentsNamesInLexicographicalOrder()
        {
            var students = CreateListOf();

            var result = FindBy("M,20,System Engeneering,2", students);

            result.Should().Be("George Ham,Morgan Freeman");
        }

        private IList<Student> CreateListOf()
        {
            return new List<Student>
            {
                new Student
                {
                    Name = "Morgan Freeman",
                    Gender = "M",
                    Age = 20,
                    Education = "System Engeneering",
                    AcademicYear = 2
                },
                new Student
                {
                    Name = "George Ham",
                    Gender = "M",
                    Age = 20,
                    Education = "System Engeneering",
                    AcademicYear = 2
                },
                new Student
                {
                    Name = "Harrys Mon",
                    Gender = "F",
                    Age = 22,
                    Education = "Scientist",
                    AcademicYear = 3
                }
            };
        }

        private static string FindBy(string surveyResult, IList<Student> students)
        {
            var repository = new Mock<IRepository>();
            repository.Setup(repo => repo.All()).Returns(() => students);
            var studentsSearchEngine = new StudentsSearchEngine(repository.Object);

            var result = studentsSearchEngine.FindBy(surveyResult);

            return result;
        }
    }
}
