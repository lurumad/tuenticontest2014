using System;

namespace TuentiContest.AnonymousPoll
{
    public class Survey
    {
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Education { get; set; }
        public int AcademicYear { get; set; }

        public Survey(string surveyResult)
        {
            var responses = surveyResult.Split(',');

            Gender = responses[0];
            Education = responses[2];
            Age = ParseFrom(responses[1]);
            AcademicYear = ParseFrom(responses[3]);
        }

        private int ParseFrom(string value)
        {
            int result;

            if (!int.TryParse(value, out result))
            {
                throw new ArgumentException("Invalid value");
            }

            return result;
        }
    }
}