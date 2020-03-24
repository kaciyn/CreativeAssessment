using CreativeAssessment.backend_Classes.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreativeAssessment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateModulePage : ContentPage
    {
        public CreateModulePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method is fired when the the SelectedItem on the AssessmentPicker is changed,
        /// used to dynamically change the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnAssessmentPickerChange(object sender, EventArgs e)
        {
            if(AssessmentPicker.SelectedItem.ToString() == "1")
            {
                Assessment1.IsVisible = true;

                Assessment2.IsVisible = false;
                Assessment3.IsVisible = false;
                Assessment4.IsVisible = false;
            }
            else if(AssessmentPicker.SelectedItem.ToString() == "2")
            {
                Assessment1.IsVisible = true;
                Assessment2.IsVisible = true;

                Assessment3.IsVisible = false;
                Assessment4.IsVisible = false;
            }
            else if(AssessmentPicker.SelectedItem.ToString() == "3")
            {
                Assessment1.IsVisible = true;
                Assessment2.IsVisible = true;
                Assessment3.IsVisible = true;

                Assessment4.IsVisible = false;
            }
            else if(AssessmentPicker.SelectedItem.ToString() == "4")
            {
                Assessment1.IsVisible = true;
                Assessment2.IsVisible = true;
                Assessment3.IsVisible = true;
                Assessment4.IsVisible = true;
            }
        }

        /// <summary>
        /// Click event handler for the save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnSaveButtonClick(object sender, EventArgs e)
        {
            bool b = await DisplayAlert("Confirm Save", "Are you sure you want to save", "Save", "Cancel");
            if (b == true)
            {
                CreateModule();
            }
        }

        /// <summary>
        /// Creates the module using the user input
        /// </summary>
        private async void CreateModule()
        {
            Module m = new Module(ModuleName.Text, ModuleID.Text);

            ObservableCollection<int> projects = new ObservableCollection<int>();

            if (AssessmentPicker.SelectedItem.ToString() == "1")
            {
                Project p1 = new Project("Assessment 1");

                Deliverable research1 = new Deliverable("Research",
                    float.Parse(Assessment1Research.Text), p1.ID);
                Deliverable ideas1 = new Deliverable("Ideas",
                    float.Parse(Assessment1Research.Text), p1.ID);
                Deliverable devel1 = new Deliverable("Development",
                    float.Parse(Assessment1Research.Text), p1.ID);
                Deliverable presentation1 = new Deliverable("Presentation",
                    float.Parse(Assessment1Research.Text), p1.ID);
                Deliverable pride1 = new Deliverable("Pride",
                    float.Parse(Assessment1Research.Text), p1.ID);
            }


            //await DisplayAlert("Module", m.Name + " " + m.ID, "OK");
        }
    }
}