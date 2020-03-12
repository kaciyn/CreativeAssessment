using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CreativeAssessment
{


    [Table("Modules")]
    class Module
    {

        //Constructor

        public Module()
        { }

        public ObservableCollection<AssessmentCriterion> assessmentCriteria = new ObservableCollection<AssessmentCriterion>
            {
                new AssessmentCriterion { Description = "Pride", Weighting = .2f},
                new AssessmentCriterion { Description = "Research", Weighting = .2f},
                new AssessmentCriterion { Description = "Concept", Weighting = .2f},
                new AssessmentCriterion { Description = "Develop", Weighting = .2f},
                new AssessmentCriterion { Description = "Present", Weighting = .2f},
            };


        /// <summary>
        /// Projects in module
        /// </summary>
        /// <value>
        /// The projects.
        /// </value>
        public ObservableCollection<Project> Projects { get; set; }

        /// <summary>
        /// Module's learning outcomes
        /// </summary>
        /// <value>
        /// The learning outcome.
        /// </value>
        [ForeignKey(typeof(LearningOutcome))]
        public ObservableCollection<int> LearningOutcomeIDs { get; set; }

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


    }












    /// <summary>
    /// Generic Mark Component
    /// </summary>
    class MarkComponent
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

    /// <summary>
    /// The assessment/project being marked
    /// </summary>
    /// 
    [Table("Projects")]
    class Project : MarkComponent
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
    class LearningOutcome : MarkComponent
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
    class Deliverable : MarkComponent
    {
        public string Name { get; set; }

        [ForeignKey(typeof(AssessmentCriterion))]
        public ObservableCollection<int> AssessmentCriteriaIDs { get; set; }

        [ForeignKey(typeof(LearningOutcome))]
        public ObservableCollection<int> LearningOutcomeIDs { get; set; }

    }

    [Table("AssessmentCriteria")]
    class AssessmentCriterion : MarkComponent
    {
        public string Name { get; set; }

    }
}


    /*
     * //init learning criteria - are we hardcoding this? do we want to provide facility for customising it? maybe a department-wide initial setup? are the weightings all equal?
            public ObservableCollection<AssessmentCriterion> assessmentCriteria = new ObservableCollection<AssessmentCriterion>
            {
                new AssessmentCriterion { Description = "Pride", Weighting = .2f},
                new AssessmentCriterion { Description = "Research", Weighting = .2f},
                new AssessmentCriterion { Description = "Concept", Weighting = .2f},
                new AssessmentCriterion { Description = "Develop", Weighting = .2f},
                new AssessmentCriterion { Description = "Present", Weighting = .2f},
            };


        var module = new Module { LearningOutcomes = new ObservableCollection<LearningOutcome>(), Projects = new ObservableCollection<Project>() };


        //init LOs
        var learningOutcomes = new ObservableCollection<LearningOutcome>
            {
                new LearningOutcome
                {
                    ID = 1,
                    Description = "Appraise professional skills and knowledge for design or related industries",
                    Deliverables = new ObservableCollection<Deliverable>(),
                    Weighting = .5f
                },
                new LearningOutcome
                {
                    ID = 2,
                    Description =
                        "Appraise the role, contribution and impact of designers and design practice within a creative economy.",
                    Deliverables = new ObservableCollection<Deliverable>(),
                    Weighting = .5f
                }
            };


        //create projects
        //i'm assuming in practice we'll be instantiating collections first and then adding
        var projects = new ObservableCollection<Project>
            {
                new Project { Name = "Retail", Weighting = .5f, Description = "Retail project" },
                new Project { Name = "Big Ideas", Weighting = .5f, Description = "Big Ideas project" }
            };


        projects[0].Deliverables = new ObservableCollection<Deliverable>();
            //retail
            //need to make sure we're adding deliverables to the learning outcomes too - better way to do this?
            projects[0].Deliverables.Add(new Deliverable
            {
                Description = "Business Model Canvas",
                AssessmentCriteria = assessmentCriteria,
                LearningOutcomes = new ObservableCollection<LearningOutcome> { learningOutcomes[0], learningOutcomes[1]
    }
});

            projects[0].Deliverables.Add(new Deliverable
            {
                Description = "Business Model Canvas",
                AssessmentCriteria = assessmentCriteria,
                LearningOutcomes = new ObservableCollection<LearningOutcome> { learningOutcomes[0], learningOutcomes[1] }
            });


            //finding learning outcome by id
            learningOutcomes.FirstOrDefault(x => x.ID == 1)?.Deliverables.Add(deliverables[0]);
            //learning outcome by index, probably easier than the previous one, just need ot make sure we add the learning outcomes in the right order of id
            learningOutcomes[1].Deliverables.Add(deliverables[0]);

            deliverables.Add(new Deliverable
            {
                Description = "Business Card",
                AssessmentCriteria = assessmentCriteria,
                LearningOutcomes = new ObservableCollection<LearningOutcome> { learningOutcomes[1] }

            });

            //Big Ideas
            deliverables.Add
            new Deliverable
            {
                Description = "Elevator Pitch",
                AssessmentCriteria = assessmentCriteria,
                LearningOutcomes = new ObservableCollection<LearningOutcome> { learningOutcomes[0] }

            },

            new Deliverable
            {
                Description = "Crowd Funder Video",
                AssessmentCriteria = assessmentCriteria,
                LearningOutcomes = new ObservableCollection<LearningOutcome> { learningOutcomes[0], learningOutcomes[1] }

            }

        //ADD A LIST OF DELIVERABLES PER PROJECT YOU DUMB ASS


            learningOutcomes[1].Deliverables.Add(businessCard);


            learningOutcomes[0].Deliverables.Add(elevatorPitch);

            learningOutcomes[0].Deliverables.Add(crowdFunderVideo);
            learningOutcomes[1].Deliverables.Add(crowdFunderVideo);





            retail.Deliverables.Add(businessModelCanvas);
            retail.Deliverables.Add(businessCard);

            bigIdeas.Deliverables.Add(elevatorPitch);
            bigIdeas.Deliverables.Add(crowdFunderVideo);

            module.LearningOutcomes = learningOutcomes;
            */











