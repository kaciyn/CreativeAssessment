﻿using System;
using SQLite;

namespace CreativeAssessment.backend_Classes.Entities
{
    /// <summary>
    /// Student Information
    /// </summary>

    [Table("Students")]
    public class Student
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int MatriculationNumber { get; set; }

        public string Email { get; set; }

        //last downloaded (presumably from moodle?)
        public int LastDownloadedCsv { get; set; }
        public DateTime LastDownloaded { get; set; }


        public bool Marked { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}