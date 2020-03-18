using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using CreativeAssessment.backend_Classes.Entities;
using Module = System.Reflection.Module;

namespace CreativeAssessment.backend_Classes
{
    class TestModuleCreation
    {
        static void Main(string[] args)
        {
        //     //init learning criteria - are we hardcoding this? do we want to provide facility for customising it? maybe a department-wide initial setup? are the weightings all equal?
        //     var assessmentCriteria = new ObservableCollection<AssessmentCriterion>
        //     {
        //         new AssessmentCriterion { Description = "Pride", Weighting = .2f},
        //         new AssessmentCriterion { Description = "Research", Weighting = .2f},
        //         new AssessmentCriterion { Description = "Concept", Weighting = .2f},
        //         new AssessmentCriterion { Description = "Develop", Weighting = .2f},
        //         new AssessmentCriterion { Description = "Present", Weighting = .2f},
        //     };
        //
        //
        //     var module = new Module { LearningOutcomes = new ObservableCollection<LearningOutcome>(), Projects = new ObservableCollection<Project>() };
        //
        //
        //     //init LOs
        //     var learningOutcomes = new ObservableCollection<LearningOutcome>
        //     {
        //         new LearningOutcome
        //         {
        //             ID = 1,
        //             Description = "Appraise professional skills and knowledge for design or related industries",
        //             Deliverables = new ObservableCollection<Deliverable>(),
        //             Weighting = .5f
        //         },
        //         new LearningOutcome
        //         {
        //             ID = 2,
        //             Description =
        //                 "Appraise the role, contribution and impact of designers and design practice within a creative economy.",
        //             Deliverables = new ObservableCollection<Deliverable>(),
        //             Weighting = .5f
        //         }
        //     };
        //
        //
        //     //create projects
        //     //i'm assuming in practice we'll be instantiating collections first and then adding
        //     var projects = new ObservableCollection<Project>
        //     {
        //         new Project { Name = "Retail", Weighting = .5f, Description = "Retail project" },
        //         new Project { Name = "Big Ideas", Weighting = .5f, Description = "Big Ideas project" }
        //     };
        //
        //
        //     projects[0].Deliverables = new ObservableCollection<Deliverable>();
        //     //retail
        //     //need to make sure we're adding deliverables to the learning outcomes too - better way to do this?
        //     projects[0].Deliverables.Add(new Deliverable
        //     {
        //         Description = "Business Model Canvas",
        //         AssessmentCriteria = assessmentCriteria,
        //         LearningOutcomes = new ObservableCollection<LearningOutcome> { learningOutcomes[0], learningOutcomes[1] }
        //     });
        //
        //     projects[0].Deliverables.Add(new Deliverable
        //     {
        //         Description = "Business Model Canvas",
        //         AssessmentCriteria = assessmentCriteria,
        //         LearningOutcomes = new ObservableCollection<LearningOutcome> { learningOutcomes[0], learningOutcomes[1] }
        //     });
        //
        //
        //     //finding learning outcome by id
        //     learningOutcomes.FirstOrDefault(x => x.ID == 1)?.Deliverables.Add(deliverables[0]);
        //     //learning outcome by index, probably easier than the previous one, just need ot make sure we add the learning outcomes in the right order of id
        //     learningOutcomes[1].Deliverables.Add(deliverables[0]);
        //
        //     deliverables.Add(new Deliverable
        //     {
        //         Description = "Business Card",
        //         AssessmentCriteria = assessmentCriteria,
        //         LearningOutcomes = new ObservableCollection<LearningOutcome> { learningOutcomes[1] }
        //
        //     });
        //
        //     //Big Ideas
        //     deliverables.Add{
        //         new Deliverable
        //         {
        //             Description = "Elevator Pitch",
        //             AssessmentCriteria = assessmentCriteria,
        //             LearningOutcomes = new ObservableCollection<LearningOutcome> { learningOutcomes[0] }
        //
        //         },
        //
        //         new Deliverable
        //         {
        //             Description = "Crowd Funder Video",
        //             AssessmentCriteria = assessmentCriteria,
        //             LearningOutcomes = new ObservableCollection<LearningOutcome>
        //                 {learningOutcomes[0], learningOutcomes[1]}
        //
        //         }
        //     };
        //
        //     //ADD A LIST OF DELIVERABLES PER PROJECT YOU DUMB ASS
        //
        //
        //     learningOutcomes[1].Deliverables.Add(businessCard);
        //
        //
        //     learningOutcomes[0].Deliverables.Add(elevatorPitch);
        //
        //     learningOutcomes[0].Deliverables.Add(crowdFunderVideo);
        //     learningOutcomes[1].Deliverables.Add(crowdFunderVideo);
        //
        //
        //
        //
        //
        //     retail.Deliverables.Add(businessModelCanvas);
        //     retail.Deliverables.Add(businessCard);
        //
        //     bigIdeas.Deliverables.Add(elevatorPitch);
        //     bigIdeas.Deliverables.Add(crowdFunderVideo);
        //
        //     module.LearningOutcomes = learningOutcomes;
        //
        //
        }

    }

}
