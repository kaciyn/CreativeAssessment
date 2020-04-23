using CreativeAssessment.backend_Classes.Entities;
using CreativeAssessment.backendClasses.Entities;
using System;
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

        public MarkingPage(Student selectedStudent, List<DetailedFeedback> feedbackMatrix)
        {
            InitializeComponent();

            this.student = selectedStudent;
            this.feedbackMatrix = feedbackMatrix;

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

            labelMark1.Text = $"{value} {Feedback.ReturnLetterGradeString(value)}";
            labelDetailedFeedback1.Text = $"{Feedback.ReturnDetailedFeedback(value, 1, feedbackMatrix)}";
        }

        void OnSliderValueChanged2(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            labelMark2.Text = $"{value} {Feedback.ReturnLetterGradeString(value)}";
            labelDetailedFeedback2.Text = $"{Feedback.ReturnDetailedFeedback(value, 2, feedbackMatrix)}";
        }

        void OnSliderValueChanged3(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            labelMark3.Text = $"{value} {Feedback.ReturnLetterGradeString(value)}";
            labelDetailedFeedback3.Text = $"{Feedback.ReturnDetailedFeedback(value, 3, feedbackMatrix)}";
        }

        void OnSliderValueChanged4(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            labelMark4.Text = $"{value} {Feedback.ReturnLetterGradeString(value)}";
            labelDetailedFeedback4.Text = $"{Feedback.ReturnDetailedFeedback(value, 4, feedbackMatrix)}";
        }

        void OnSliderValueChanged5(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            labelMark5.Text = $"{value} {Feedback.ReturnLetterGradeString(value)}";
            labelDetailedFeedback5.Text = $"{Feedback.ReturnDetailedFeedback(value, 5, feedbackMatrix)}";
        }

       

        private void SaveButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}
