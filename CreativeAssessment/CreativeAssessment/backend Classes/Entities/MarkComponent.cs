using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SQLite;

namespace CreativeAssessment.backend_Classes.Entities
{
    //unsure if sql table mappings will still work with the inherited fields so just copying over the 
    public class MarkComponent
    {
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
        public void CalculateMark(List<MarkComponent> components)//ugh lol i hope it works with the inheritance i guess we will just have to wait and see
        {
            Mark = components.Sum(markComponent => markComponent.Mark * markComponent.Weighting) / components.Count;
        }

    }

}
