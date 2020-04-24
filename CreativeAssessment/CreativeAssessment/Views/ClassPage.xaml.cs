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
using System.Net.Mail;
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
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {

                try
                {

                    conn.CreateTable<Student>();

                    var students = conn.Table<Student>().ToList();



                    foreach (var item in students)
                    {

                        Class.Add(new Student { Marked = item.Marked, MatriculationNumber = item.MatriculationNumber, Name = item.Name, Surname = item.Surname, Email = item.Email, LastDownloaded = DateTime.Now });
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
                    conn.CreateTable<DetailedFeedback>();

                    //TODO if null show a message? maybe kick the user out to the module creation page to upload the csv or just straight up provide the upload dialogue
                    DetailedFeedbackMatrix = conn.Table<DetailedFeedback>().ToList();
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
                var markedUnsentStudents = Class.Where(x => x.Marked == true && x.FeedbackSent == false).ToArray();
                foreach (var student in markedUnsentStudents)
                {

                    try
                    {

                        MailMessage mail = new MailMessage();
                        // can we get the uni to provide a server
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                        mail.From = new MailAddress("creativeassessmenttest@gmail.com");
                        mail.To.Add("40406489@live.napier.ac.uk");
                        //mail.To.Add(student.Email);
                        //when we have it set this to the project/assessment name
                        mail.Subject = "Assessment Marks";
                        mail.Body = EmailHandler.GenerateResultsEmail(student.MatriculationNumber
                            //,assessmentID
                            );

                        SmtpServer.Port = 587;
                        SmtpServer.Host = "smtp.gmail.com";
                        SmtpServer.EnableSsl = true;
                        SmtpServer.UseDefaultCredentials = false;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("creativeassessmenttest@gmail.com", "wdqkby7J$B8T");

                        SmtpServer.Send(mail);

                        student.FeedbackSent = true;
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert($"Email not sent to {student.Email}", ex.Message, "OK");
                    }

                }

                using (SQLiteConnection db = new SQLiteConnection(App.FilePath))
                {
                    db.Insert(Class);
                }

                await DisplayAlert("Success", "Emails sent", "OK");


            }
        }
    }
}