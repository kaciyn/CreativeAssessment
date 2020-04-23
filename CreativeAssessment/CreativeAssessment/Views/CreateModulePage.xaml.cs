using CreativeAssessment.backend_Classes.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
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

        protected override void OnAppearing()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<Module>();
                    conn.CreateTable<Project>();
                    conn.CreateTable<Deliverable>();
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
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
            bool b = await DisplayAlert("Confirm Save", "Are you sure you want to save? " +
                "This will delete all other modules stored in the system", "Save", "Cancel");
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
            Module m = new Module(ModuleName.Text, Int32.Parse(ModuleID.Text));

            ObservableCollection<Project> projects = new ObservableCollection<Project>();
            ObservableCollection<Deliverable> deliverables = new ObservableCollection<Deliverable>();
            
            //Create each project and the deliverables for them
            for(int i = 0; i < Int16.Parse(AssessmentPicker.SelectedItem.ToString()); ++i)
            {
                Project p = new Project("Assessment " + i + 1);
                projects.Add(p);

                Entry research = (Entry)this.FindByName("Assessment" + (i + 1) + "Research");
                Entry ideas = (Entry)this.FindByName("Assessment" + (i + 1) + "Ideas");
                Entry devel = (Entry)this.FindByName("Assessment" + (i + 1) + "Devel");
                Entry presen = (Entry)this.FindByName("Assessment" + (i + 1) + "Presentation");
                Entry pride = (Entry)this.FindByName("Assessment" + (i + 1) + "Pride");

                deliverables.Add(new Deliverable("Research", float.Parse(research.Text), p.ID));
                deliverables.Add(new Deliverable("Research", float.Parse(ideas.Text), p.ID));
                deliverables.Add(new Deliverable("Research", float.Parse(devel.Text), p.ID));
                deliverables.Add(new Deliverable("Research", float.Parse(presen.Text), p.ID));
                deliverables.Add(new Deliverable("Research", float.Parse(pride.Text), p.ID));
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {

                    conn.DeleteAll<Module>();
                    conn.DeleteAll<Project>();
                    conn.DeleteAll<Deliverable>();

                    conn.Insert(m);

                    foreach (Project p in projects)
                    {
                        conn.Insert(p);
                    }

                    foreach (Deliverable d in deliverables)
                    {
                        conn.Insert(d);
                    }         
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}