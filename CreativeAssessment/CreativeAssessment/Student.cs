using System;
using System.Collections.Generic;
using System.Text;

namespace CreativeAssessment
{
    public class Student
    {
        public int MatriculationNumber { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
