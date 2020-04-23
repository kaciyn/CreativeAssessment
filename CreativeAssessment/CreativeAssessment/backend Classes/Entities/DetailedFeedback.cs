using System;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace CreativeAssessment.backendClasses.Entities
{
    [Table("DetailedFeedback")]
    public class DetailedFeedback
    {
        /// <summary>
        /// Detailed feedback for project criteria
        /// </summary>

        [PrimaryKey]
        public int ID { get; set; }

        public string Criterion { get; set; }

        public string APlus { get; set; }

        public string A { get; set; }

        public string AMinus { get; set; }

        public string BPlus { get; set; }

        public string B { get; set; }

        public string BMinus { get; set; }

        public string CPlus { get; set; }

        public string C { get; set; }

        public string CMinus { get; set; }

        public string DPlus { get; set; }

        public string D { get; set; }

        public string DMinus { get; set; }

        public string E { get; set; }

        public string F { get; set; }
    }
}
