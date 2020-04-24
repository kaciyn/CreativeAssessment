using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CreativeAssessment.backend_Classes.Entities
{
    [Table("Modules")]
    public class Module
    {

        //Module name
        public string Name { get; private set; }

        //Module ID
        [PrimaryKey]
        public string ID { get; private set; }

        /// <summary>
        /// Projects in module
        /// </summary>
        /// <value>
        /// The projects.
        /// </value>
        public ObservableCollection<int> ProjectIDs { get; set; }

        /// <summary>
        /// Module's learning outcome IDs, not currently implemented
        /// </summary>
        /// <value>
        /// The learning outcome.
        /// </value>
        // [ForeignKey(typeof(LearningOutcome))]
        // public ObservableCollection<int> LearningOutcomeIDs { get; set; }

        /// <summary>
        /// Calculated from assessment marks, of 100
        /// </summary>
        /// <value>
        /// The mark.
        /// </value>
        public float Mark { get; set; }

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
        /// <param name="id"></param>
        public Module(string n, string id)
        {
            this.Name = n;
            this.ID = id;
        }
    }
}