using System;

namespace TuentiContest.AnonymousPoll
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine();
            int numberOfCases;

            if (!int.TryParse(firstLine, out numberOfCases))
            {
                Console.WriteLine("Number of cases must be numeric");
            }
            else
            {
                var studentsSearchEngine =
                    new StudentsSearchEngine(
                        new StudentsRepository());

                for (var i = 1; i <= numberOfCases; i++)
                {
                    var surveyResult = Console.ReadLine();
                    var result = studentsSearchEngine.FindBy(surveyResult);
                    Console.WriteLine("Case #{0}: {1}", i, result);
                }
            }
        }
    }
}
