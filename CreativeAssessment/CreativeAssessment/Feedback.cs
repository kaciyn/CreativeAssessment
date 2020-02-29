using System;
using System.Collections.Generic;
using System.Text;

namespace CreativeAssessment
{
    class Feedback
    {
        /// <summary>
        /// Returns the letter grade based on mark.
        /// </summary>
        /// <param name="mark">The mark.</param>
        /// <returns></returns>
        public string ReturnLetterGrade(float mark)
        {
            //TODO need clarification on the actual scale
            if (mark <= 90)
            {
                return "A+";

            }
            if (mark <= 80)
            {
                return "A";

            }
            if (mark <= 70)
            {
                return "A-";

            }
            if (mark <= 60)
            {
                return "B";

            }
            if (mark <= 50)
            {
                return "C";
            }
            if (mark <= 40)
            {
                return "D+";

            }
            if (mark <= 30)
            {
                return "D";

            }
            if (mark <= 20)
            {
                return "D-";

            }
            if (mark <= 10)
            {
                return "E";

            }
            return mark <= 0 ? "F" : "NM";
        }


    }
}
