using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativeAssessment.backend_Classes.Entities;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        Student selectedItem;


        public ClassPage()
        {
            InitializeComponent();
            Class = new ObservableCollection<Student>();



            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {

                conn.CreateTable<Student>();

                var students = conn.Table<Student>().ToList();

                foreach (var item in students)
                {

                    Class.Add(new Student { Marked = item.Marked, MatriculationNumber = item.MatriculationNumber, Name = item.Name, Surname = item.Surname, Email = item.Email, LastDownloaded = DateTime.Now });
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
            selectedItem = e.SelectedItem as Student;
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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        //delete individual students
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //Class.Remove(selectedItem);
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Student>();
                conn.Delete(selectedItem);
                Class.Remove(selectedItem);

            }
        }

        //delete all button
        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {

            var answer =  await DisplayAlert("Warning", "This will delete the list of students, proceed?", "Yes", "No");

            if (answer == true)
            {
                Class.Clear();

                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<Student>();
                    conn.DeleteAll<Student>();

                }
            }
            else{ }

        }

        private void MarkButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.MarkingPage(selectedItem));

        }
    }
}
