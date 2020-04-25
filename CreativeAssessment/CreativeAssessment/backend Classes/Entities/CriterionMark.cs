using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using CreativeAssessment.backend_Classes.Entities;
using CreativeAssessment.backendClasses.Entities;
using System.Linq;

namespace CreativeAssessment.backend_Classes.Entities
{
    [Table("CriteriaMarks")]
    public class CriterionMark //: MarkComponent
    {
        //would be ideal to have the pk be studentid/criterionid/moduleid in the future
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(Student))]
        public int StudentID { get; set; }

        [ForeignKey(typeof(DetailedFeedback))]
        public int CriterionID { get; set; }

        //this ideally in the future should instead be a link to Deliverable (1 deliverable has the 5 criterion marks) which in turn will link to Project (1 project may have more than one deliverable) which will then link to Module (1 module may have more than one project)
        [ForeignKey(typeof(Module))]
        public string ModuleID { get; set; }

        /// <summary>
        /// Marks earned (of 100)
        /// </summary>
        /// <value>
        /// The mark.
        /// </value>
        public double Mark { get; set; }

        /// <summary>
        /// Weighting of the deliverable
        /// </summary>
        /// <value>
        /// The weighting.
        /// </value>
        public double Weighting { get; set; }

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
        public void CalculateMark(List<CriterionMark> components)//ugh lol i hope it works with the inheritance i guess we will just have to wait and see
        {
            Mark = components.Sum(markComponent => markComponent.Mark * markComponent.Weighting) / components.Count;
        }

    }

}
