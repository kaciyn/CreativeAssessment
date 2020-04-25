using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativeAssessment.backend_Classes.Entities;
using CreativeAssessment.backendClasses.Entities;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CreativeAssessment.backendClasses;

namespace CreativeAssessment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClassPage : ContentPage
    {
        /// <summary>
        /// Initialises class list
        /// </summary>
        /// <value>
        /// The class.
        /// </value>
        public ObservableCollection<Student> Class { get; private set; }
        public List<DetailedFeedback> DetailedFeedbackMatrix { get; private set; }

        Student selectedStudent;


        public ClassPage()
        {
            InitializeComponent();
            Class = new ObservableCollection<Student>();
            DetailedFeedbackMatrix = new List<DetailedFeedback>();

            BindingContext = this;
        }

        protected async override void OnAppearing()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.FilePath))
            {
                //db.DeleteAll<CriterionMark>();
                try
                {

                    db.CreateTable<Student>();

                    var students = db.Table<Student>().ToList();

                    foreach (var student in students)
                    {
                        //student.FeedbackSent = false;
                        //student.Marked = false;
                        //db.Update(student);

                        Class.Add(new Student { Marked = student.Marked, MatriculationNumber = student.MatriculationNumber, Name = student.Name, Surname = student.Surname, Email = student.Email, LastDownloaded = DateTime.Now });
                    }

                    if (Class.Count < 1)
                    {
                        UploadBtn.IsVisible = true;
                    }
                    else
                    {
                        UploadBtn.IsVisible = false;
                    }

                    //loads detailed feedback matrix from db
                    db.CreateTable<DetailedFeedback>();

                    //TODO if null show a message? maybe kick the user out to the module creation page to upload the csv or just straight up provide the upload dialogue
                    DetailedFeedbackMatrix = db.Table<DetailedFeedback>().ToList();
                }
                catch (Exception ex)
                {
                    string reason = ex.ToString();
                    await DisplayAlert("!", "Failed to load students:  " + reason, "OK");
                    UploadBtn.IsVisible = true;

                }
            }
        }

        /// <summary>
        /// Called when [ListView item selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instance containing the event data.</param>
        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedStudent = e.SelectedItem as Student;
        }

        /// <summary>
        /// Called when [ListView item tapped].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ItemTappedEventArgs"/> instance containing the event data.</param>
        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            Student tappedItem = e.Item as Student;
        }


        /// <summary>Opens .</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        async void OnClickOpenCSV(object sender, EventArgs e)
        {
            try
            {
                FileData filedata = await CrossFilePicker.Current.PickFile();

                // the dataarray of the file will be found in filedata.DataArray 
                // file name will be found in filedata.FileName;
                //etc etc.

                var fileStream = filedata.GetStream();
                var csvParser = new CsvParser();
                var parseResults = csvParser.ParseStreamToStudentList(fileStream);

                foreach (var item in parseResults)
                {
                    //added the other fields so that a complete student record is added (email , datetime)

                    Class.Add(new Student { Marked = item.Result.Marked, MatriculationNumber = item.Result.MatriculationNumber, Name = item.Result.Name, Surname = item.Result.Surname, Email = item.Result.Email, LastDownloaded = DateTime.Now });
                }

                //Initialise a new SQLite connection , connecting to a specific database file defined in App.
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<Student>();

                    //add each student to a students database.
                    foreach (Student person in Class)
                    {
                        conn.Insert(person);
                    }


                }
                // just a notification to say it was a success.
                await DisplayAlert("!", "Upload successful", "OK");
                UploadBtn.IsVisible = false;

            }
            catch (Exception ex)
            {
                string reason = ex.ToString();
                await DisplayAlert("!", "Upload Failed: " + reason, "OK");
            }


        }

        //delete individual students
        private void DeleteStudent_Clicked(object sender, EventArgs e)
        {
            //Class.Remove(selectedItem);
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Student>();
                conn.Delete(selectedStudent);
                Class.Remove(selectedStudent);

            }
        }

        //delete all button
        private async void DeleteAll_Clicked(object sender, EventArgs e)
        {

            var answer = await DisplayAlert("Warning", "This will delete the list of students, proceed?", "Yes", "No");

            if (answer == true)
            {
                Class.Clear();

                using (SQLiteConnection db = new SQLiteConnection(App.FilePath))
                {
                    db.CreateTable<Student>();
                    db.DeleteAll<Student>();

                }

                UploadBtn.IsVisible = true;
            }
            else { }

        }

        private void MarkButton_Clicked(object sender, EventArgs e)
        {
            //placeholder module id for now
            Navigation.PushAsync(new Views.MarkingPage(selectedStudent, DetailedFeedbackMatrix, "SET98797"));

        }

        private async void SendMarked_Clicked(object sender, EventArgs e)
        {
            {
                var markedUnsentStudents = Class.Where(x => x.Marked == true && x.FeedbackSent == false).ToList();

                var emailHandler = new EmailHandler();

                //try
                //{
                emailHandler.SendEmails(markedUnsentStudents, DetailedFeedbackMatrix);

                await DisplayAlert("Success", "Emails sent", "OK");
                //}
                //catch (Exception ex)
                //{
                //    await DisplayAlert($"Error sending emails", ex.InnerException.Message, "OK");
                //}
            }
        }
    }
}