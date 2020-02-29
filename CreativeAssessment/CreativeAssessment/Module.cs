using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreativeAssessment
{
    //If anyone has a cleaner way of doing this fire away 
    class Module
    {
        public List<Assessment> Assessments { get; set; }
        /// <summary>
        /// Calculated from assessment marks, of 100
        /// </summary>
        /// <value>
        /// The mark.
        /// </value>
        public float Mark { get; set; }
    }

    /// <summary>
    /// The assessment/project being marked
    /// </summary>
    class Assessment : MarkComponent
    {
        public List<Deliverable> LearningOutcomes { get; set; }

    }

    /// <summary>
    /// Components or project mark, i.e. Research, Development, Pride, etc.
    /// </summary>
    class Deliverable : MarkComponent
    {
        //Leaving this here for now in case there's other properties outwith the scope of the generic mark component we might like to add
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
        /// Calculates the total mark from the given mark components.
        /// </summary>
        /// <param name="components">The components.</param>
        /// <returns></returns>
        public float CalculateMark(List<MarkComponent> components)
        {
            return components.Sum(markComponent => markComponent.Mark * markComponent.Weighting) / components.Count;
        }

    }

    /// <summary>
    /// The module's learning outcomes, linked to deliverables
    /// </summary>
    class LearningOutcome
    {
        /// <summary>
        /// i.e. L01, L02
        /// </summary>
        public string ID { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// The deliverables which the learning outcome encompasses
        /// </summary>
        /// <value>
        /// The deliverables.
        /// </value>
        public List<Deliverable> Deliverables { get; set; }
    }
}
