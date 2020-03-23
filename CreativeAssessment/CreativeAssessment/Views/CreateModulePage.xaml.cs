using CreativeAssessment.backend_Classes.Entities;
using System;
using System.Collections.Generic;
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

        private async void CreateModule()
        {
            Module m = new Module(ModuleName.Text, ModuleID.Text);

            //await DisplayAlert("Module", m.Name + " " + m.ID, "OK");
        }
    }
}