using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace CreativeAssessment
{
    public class MarkComponent
    {

        

            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }

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
            /// Calculates the total mark from the given mark components.
            /// </summary>
            /// <param name="components">The components.</param>
            /// <returns>
            /// Total mark
            /// </returns>
            public float CalculateMark(ObservableCollection<MarkComponent> components)//ugh lol i hope it works with the inheritance i guess we will just have to wait and see
            {
                return components.Sum(markComponent => markComponent.Mark * markComponent.Weighting) / components.Count;
            }

    }


    [Table("Projects")]
     public class Project : MarkComponent
    {
        public string Name { get; set; }

        /// <summary>
        /// The project's deliverable ids
        /// </summary>
        /// <value>
        /// The deliverables.
        /// </value>
        [ForeignKey(typeof(Deliverable))]
        public ObservableCollection<int> DeliverableIDs { get; set; }

    }

    /// <summary>
    /// The module's learning outcomes
    /// </summary>
    [Table("LearningOutcomes")]
   public class LearningOutcome : MarkComponent
    {
        /// <summary>
        /// the numeric component of the learning outcome i.e. L01 -> 1 etc.
        /// </summary
        public int ObjectiveNumber { get; set; }

        /// <summary>
        /// The deliverables which the learning outcome encompasses
        /// </summary>
        /// <value>
        /// The deliverables.
        /// </value>
        [ForeignKey(typeof(Deliverable))]
        public ObservableCollection<int> DeliverableIDs { get; set; }
    }



    /// <summary>
    /// Components or project mark, i.e. Research, Development, Pride, etc.
    /// </summary>
    [Table("Deliverables")]
    public class Deliverable : MarkComponent
    {
        public string Name { get; set; }

        [ForeignKey(typeof(AssessmentCriterion))]
        public ObservableCollection<int> AssessmentCriteriaIDs { get; set; }

        [ForeignKey(typeof(LearningOutcome))]
        public ObservableCollection<int> LearningOutcomeIDs { get; set; }

    }

    [Table("AssessmentCriteria")]
     public class AssessmentCriterion : MarkComponent
    {
        public string Name { get; set; }

    }


}
