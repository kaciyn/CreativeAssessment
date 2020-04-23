using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CreativeAssessment.backend_Classes.Entities
{

    /// <summary>
    /// Components or project mark, i.e. Research, Development, Pride, etc.
    /// </summary>
    [Table("Deliverables")]
    public class Deliverable// : MarkComponent
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; private set; }

        [ForeignKey(typeof(Project))]
        public int ProjectID { get; private set; }

        public string Name { get; set; }

        [ForeignKey(typeof(CriterionMark))]
        public ObservableCollection<int> AssessmentCriteriaIDs { get; set; }

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

        //TODO NOT CURRENTLY IMPLEMENTED
        // [ForeignKey(typeof(LearningOutcome))]
        // public ObservableCollection<int> LearningOutcomeIDs { get; set; }


        public Deliverable(string n, float w, int id)
        {
            this.Name = n;
            this.Weighting = w;
            this.ProjectID = id;
        }

    }
}
