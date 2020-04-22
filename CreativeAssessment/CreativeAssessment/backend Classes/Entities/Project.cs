using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CreativeAssessment.backend_Classes.Entities
{
    [Table("Projects")]
    public class Project //: MarkComponent
    {
        /// <summary>
        /// Unique Indentifier
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int ID { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }
        /// <summary>
        /// Marks earned (of 100)
        /// </summary>
        /// <value>
        /// The mark.
        /// </value>
        public float Mark { get; set; }

        /// <summary>
        /// Weighting of the deliverable
        /// </summary>
        /// <value>
        /// The weighting.
        /// </value>
        public float Weighting { get; set; }

        /// <summary>
        /// Any additional notes
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public string Comments { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="n"></param>
        public Project(string n)
        {
            this.Name = n;
        }
    }
}
