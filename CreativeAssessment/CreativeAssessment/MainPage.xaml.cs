using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using SQLite;
using TinyCsvParser;
using TinyCsvParser.Mapping;
using Xamarin.Forms;


namespace CreativeAssessment
{
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Initialises class list
        /// </summary>
        /// <value>
        /// The class.
        /// </value>
        public ObservableCollection<Student> Class { get; private set; }
        public MainPage()
        {
            InitializeComponent();
            Class = new ObservableCollection<Student>();

            // AddTestStudents();

            BindingContext = this;
        }


        /// <summary>
        /// Called when [ListView item selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instance containing the event data.</param>
        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Student selectedItem = e.SelectedItem as Student;
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
                var csvParser = new CsvParser(); ;
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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }


    }

}



