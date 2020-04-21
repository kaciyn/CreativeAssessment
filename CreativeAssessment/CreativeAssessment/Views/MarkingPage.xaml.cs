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
        public MarkingPage()
        {
            InitializeComponent();
        }

        void OnSliderValueChanged1(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            labelMark1.Text = $"{value} {Feedback.ReturnLetterGrade(value)}";
        }

        void OnSliderValueChanged2(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            labelMark2.Text = $"{value} {Feedback.ReturnLetterGrade(value)}";
        }

        void OnSliderValueChanged3(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            labelMark3.Text = $"{value} {Feedback.ReturnLetterGrade(value)}";
        }

        void OnSliderValueChanged4(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            labelMark4.Text = $"{value} {Feedback.ReturnLetterGrade(value)}";
        }

        void OnSliderValueChanged5(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            labelMark5.Text = $"{value} {Feedback.ReturnLetterGrade(value)}";
        }

    }
}
