using System;
using System.Collections.Generic;
using System.Text;

namespace CreativeAssessment
{
    /// <summary>
    /// Student Information
    /// </summary>
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ID { get; set; }
        public string Email { get; set; }
        public int MatriculationNumber { get; set; }
        public int LastDownloaded { get; set; }
        public bool Marked { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
