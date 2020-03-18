using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CreativeAssessment.backend_Classes.Entities
{

    /// <summary>
    /// The module's learning outcomes,
    /// TODO NOT CURRENTLY IMPLEMENTED
    /// </summary>
    [Table("LearningOutcomes")]
    public class LearningOutcome : MarkComponent
    {
        // [PrimaryKey, AutoIncrement]
        // public int ID { get; set; }

        /// <summary>
        /// the numeric component of the learning outcome i.e. L01 -> 1 etc.
        /// </summary
        // public int ObjectiveNumber { get; set; }

        /// <summary>
        /// The deliverables which the learning outcome encompasses
        /// </summary>
        /// <value>
        /// The deliverables.
        /// </value>
        // [ForeignKey(typeof(Deliverable))]
        // public ObservableCollection<int> DeliverableIDs { get; set; }
    }

}
