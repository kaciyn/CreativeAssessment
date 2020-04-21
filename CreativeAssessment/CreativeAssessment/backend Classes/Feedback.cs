using System;
using System.Collections.Generic;
using System.Text;

namespace CreativeAssessment
{
    public static class Feedback
    {
        /// <summary>
        /// Returns the letter grade based on mark.
        /// </summary>
        /// <param name="mark">The mark.</param>
        /// <returns></returns>
        public static string ReturnLetterGrade(double mark)
        {
            //Functionality for custom grade scales could be easily added here but that's :) outwith :) our purview :)
            if (mark >= 84.5)
            {
                return "A+";

            }
            if (mark >= 74.49)
            {
                return "A";

            }
            if (mark >= 69.49)
            {
                return "A-";

            }
            if (mark >= 66.49)
            {
                return "B+";

            }
            if (mark >= 62.49)
            {
                return "B";

            }
            if (mark >= 59.49)
            {
                return "B-";

            }
            if (mark >= 56.49)
            {
                return "C+";
            }
            if (mark >= 52.49)
            {
                return "C";
            }
            if (mark >= 49.49)
            {
                return "C-";
            }
            if (mark >= 46.49)
            {
                return "D+";

            }
            if (mark >= 42.49)
            {
                return "D";

            }
            if (mark >= 39.49)
            {
                return "D-";

            }
            return mark >= 39.49 ? "E" : "F";
        }


    }
}
