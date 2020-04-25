using CreativeAssessment.backend_Classes.Entities;
using CreativeAssessment.backendClasses.Entities;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace CreativeAssessment.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarkingPage : ContentPage
    {

        Student student;
        List<DetailedFeedback> feedbackMatrix;
        public List<CriterionMark> criterionMarks;

        public string ModuleID { get; }

        public MarkingPage(Student selectedStudent, List<DetailedFeedback> feedbackMatrix, string moduleID)
        {
            InitializeComponent();

            student = selectedStudent;
            ModuleID = moduleID;
            this.feedbackMatrix = feedbackMatrix;
            //TODO can make this check for whether the student is already marked in the db/populate the sliders
            //TODO also need to add a "marked" status to the student when marked
            criterionMarks = new List<CriterionMark>();
            for (int i = 0; i < 6; i++)
            {
                //overall shouldn't be weighted as .2 here but we'll be pulling from db in the future so it doesn't matter right now
                //also the id is a shitshow i just need this to work right now
                criterionMarks.Add(new CriterionMark
                { //ID = student.MatriculationNumber * i,
                    CriterionID = i,
                    Weighting = .2,
                    StudentID = student.MatriculationNumber,
                    ModuleID = moduleID
                });
            }

            labelCriterion1.Text = $"{feedbackMatrix[1].Criterion}";
            labelCriterion2.Text = $"{feedbackMatrix[2].Criterion}";
            labelCriterion3.Text = $"{feedbackMatrix[3].Criterion}";
            labelCriterion4.Text = $"{feedbackMatrix[4].Criterion}";
            labelCriterion5.Text = $"{feedbackMatrix[5].Criterion}";
        }

        public MarkingPage()
        {
            InitializeComponent();


        }

        void OnSliderValueChanged1(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;


            criterionMarks[1].Mark = value;
            labelMark1.Text = $"{value} {Feedback.ReturnLetterGradeString(value)}";
            labelDetailedFeedback1.Text = $"{Feedback.ReturnDetailedFeedback(value, 1, feedbackMatrix)}";
        }

        void OnSliderValueChanged2(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            criterionMarks[2].Mark = value;
            labelMark2.Text = $"{value} {Feedback.ReturnLetterGradeString(value)}";
            labelDetailedFeedback2.Text = $"{Feedback.ReturnDetailedFeedback(value, 2, feedbackMatrix)}";
        }

        void OnSliderValueChanged3(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            criterionMarks[2].Mark = value;
            labelMark3.Text = $"{value} {Feedback.ReturnLetterGradeString(value)}";
            labelDetailedFeedback3.Text = $"{Feedback.ReturnDetailedFeedback(value, 3, feedbackMatrix)}";
        }

        void OnSliderValueChanged4(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            criterionMarks[4].Mark = value;
            labelMark4.Text = $"{value} {Feedback.ReturnLetterGradeString(value)}";
            labelDetailedFeedback4.Text = $"{Feedback.ReturnDetailedFeedback(value, 4, feedbackMatrix)}";
        }

        void OnSliderValueChanged5(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            criterionMarks[5].Mark = value;
            labelMark5.Text = $"{value} {Feedback.ReturnLetterGradeString(value)}";
            labelDetailedFeedback5.Text = $"{Feedback.ReturnDetailedFeedback(value, 5, feedbackMatrix)}";
        }



        private async void SaveButton_Clicked(object sender, EventArgs e)
        {

            criterionMarks[0].CalculateMark(criterionMarks.GetRange(1, 5));
            criterionMarks[0].Comments = editorComments0.Text;

            criterionMarks[1].Comments = editorComments1.Text;
            criterionMarks[2].Comments = editorComments2.Text;
            criterionMarks[3].Comments = editorComments3.Text;
            criterionMarks[4].Comments = editorComments4.Text;
            criterionMarks[5].Comments = editorComments5.Text;

            //Initialise a new SQLite connection , connecting to a specific database file defined in App.
            using (SQLiteConnection db = new SQLiteConnection(App.FilePath))
            {
                db.CreateTable<CriterionMark>();

                //adds detailed feedback to db.
                foreach (CriterionMark mark in criterionMarks)
                {
                    db.Insert(mark);
                }

                var currentStudent = db.Table<Student>().Where(x => x.MatriculationNumber == this.student.MatriculationNumber).FirstOrDefault();
                currentStudent.Marked = true;

                db.Update(currentStudent);
            }
            // just a notification to say it was a success.
            await DisplayAlert("Success!", "Marks saved", "Return to class list");

            await Navigation.PushAsync(new ClassPage());
        }
    }
}
