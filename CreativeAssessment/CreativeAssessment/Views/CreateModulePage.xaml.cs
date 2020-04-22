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

            Project project1 = new Project("Assessment 1");
            Project project2 = new Project("Assessment 2");
            Project project3 = new Project("Assessment 3");
            Project project4 = new Project("Assessment 4");
            Project project5 = new Project("Assessment 5");

            switch(AssessmentPicker.SelectedItem.ToString())
            {
                case "1":
                    CreateDeliverables(Assessment1Research.Text, Assessment1Ideas.Text, Assessment1Devel.Text,
                        Assessment1Presentation.Text, Assessment1Pride.Text, project1.ID);
                    projects.Add(project1.ID);
                    break;
                case "2":
                    CreateDeliverables(Assessment1Research.Text, Assessment1Ideas.Text, Assessment1Devel.Text,
                        Assessment1Presentation.Text, Assessment1Pride.Text, project1.ID);
                    projects.Add(project1.ID);

                    CreateDeliverables(Assessment2Research.Text, Assessment2Ideas.Text, Assessment2Devel.Text,
                        Assessment2Presentation.Text, Assessment2Pride.Text, project2.ID);
                    projects.Add(project2.ID);
                    break;
                case "3":
                    CreateDeliverables(Assessment1Research.Text, Assessment1Ideas.Text, Assessment1Devel.Text,
                        Assessment1Presentation.Text, Assessment1Pride.Text, project1.ID);
                    projects.Add(project1.ID);

                    CreateDeliverables(Assessment2Research.Text, Assessment2Ideas.Text, Assessment2Devel.Text,
                        Assessment2Presentation.Text, Assessment2Pride.Text, project2.ID);
                    projects.Add(project2.ID);

                    CreateDeliverables(Assessment3Research.Text, Assessment3Ideas.Text, Assessment3Devel.Text,
                        Assessment3Presentation.Text, Assessment3Pride.Text, project3.ID);
                    projects.Add(project2.ID);
                    break;
                case "4":
                    CreateDeliverables(Assessment1Research.Text, Assessment1Ideas.Text, Assessment1Devel.Text,
                    Assessment1Presentation.Text, Assessment1Pride.Text, project1.ID);
                    projects.Add(project1.ID);

                    CreateDeliverables(Assessment2Research.Text, Assessment2Ideas.Text, Assessment2Devel.Text,
                        Assessment2Presentation.Text, Assessment2Pride.Text, project2.ID);
                    projects.Add(project2.ID);

                    CreateDeliverables(Assessment3Research.Text, Assessment3Ideas.Text, Assessment3Devel.Text,
                        Assessment3Presentation.Text, Assessment3Pride.Text, project3.ID);
                    projects.Add(project2.ID);

                    CreateDeliverables(Assessment4Research.Text, Assessment4Ideas.Text, Assessment4Devel.Text,
                        Assessment4Presentation.Text, Assessment4Pride.Text, project4.ID);
                    projects.Add(project2.ID);
                    break;
                default:
                    await DisplayAlert("Error", "Error you need to specify the number of assessments the module has", "Ok");
                    break;
            }



            //await DisplayAlert("Module", m.Name + " " + m.ID, "OK");
        }

       /// <summary>
       /// Creates the deliverable objects for the specified project
       /// </summary>
       /// <param name="r"></param>
       /// <param name="i"></param>
       /// <param name="dev"></param>
       /// <param name="presen"></param>
       /// <param name="pr"></param>
       /// <param name="pid"></param>
        private void CreateDeliverables(string r, string i, string dev,
            string presen, string pr, int pid)
        {
            Deliverable research = new Deliverable("Research", float.Parse(r), pid);
            Deliverable ideas = new Deliverable("Research", float.Parse(i), pid);
            Deliverable devl = new Deliverable("Research", float.Parse(dev), pid);
            Deliverable presentation = new Deliverable("Research", float.Parse(presen), pid);
            Deliverable pride = new Deliverable("Research", float.Parse(pr), pid);
        }

    }
}