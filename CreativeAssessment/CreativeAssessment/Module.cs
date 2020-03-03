using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreativeAssessment
{
    //If anyone has a cleaner way of doing this fire away 
    class Module
    {
        public List<Project> Assessments { get; set; }
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
        public string Notes { get; set; }
    }


    /// <summary>
    /// The assessment/project being marked
    /// </summary>
    class Project : MarkComponent
    {
        public List<Deliverable> Deliverables { get; set; }

    }

    /// <summary>
    /// The module's learning outcomes
    /// </summary>
    class LearningOutcome : MarkComponent
    {
        /// <summary>
        /// the numeric component of the learning outcome i.e. L01 -> 1 etc.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The deliverables which the learning outcome encompasses
        /// </summary>
        /// <value>
        /// The deliverables.
        /// </value>
        public List<Deliverable> Deliverables { get; set; }
    }

 

    /// <summary>
    /// Components or project mark, i.e. Research, Development, Pride, etc.
    /// </summary>
    class Deliverable : MarkComponent
    {
        public List<MarkComponent> AssessmentCriteria { get; set; }
        public List<LearningOutcome> LearningOutcomes { get; set; }

    }

    /// <summary>
    /// Generic Mark Component
    /// </summary>
    class MarkComponent
    {
        public string Name { get; set; }
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
        public string Notes { get; set; }


        /// <summary>
        /// Calculates the total mark from the given mark components.
        /// </summary>
        /// <param name="components">The components.</param>
        /// <returns>
        /// Total mark
        /// </returns>
        public float CalculateMark(List<MarkComponent> components)//ugh lol i hope it works with the inheritance i guess we will just have to wait and see
        {
            return components.Sum(markComponent => markComponent.Mark * markComponent.Weighting) / components.Count;
        }

    }


}
