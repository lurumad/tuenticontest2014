using System;
using System.Collections.Generic;
using System.Linq;

namespace TuentiContest.AnonymousPoll
{
    public class StudentsSearchEngine
    {
        private readonly IRepository _repository;

        public StudentsSearchEngine(IRepository repository)
        {
            _repository = repository;
        }

        public string FindBy(string surveyResult)
        {
            var survey = new Survey(surveyResult);
            var nameOfTheStudents = FindBy(survey);

            if (!nameOfTheStudents.Any())
            {
                return "NONE";
            }

            return String.Join(",", nameOfTheStudents);
        }

        private List<string> FindBy(Survey survey)
        {
            var results = _repository
                .All()
                .Where(user => user.Gender == survey.Gender &&
                               user.Age == survey.Age &&
                               user.Education == survey.Education &&
                               user.AcademicYear == survey.AcademicYear)
                .Select(user => user.Name)
                .OrderBy(name => name)
                .ToList();

            return results;
        }
    }
}