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
using TinyCsvParser;
using TinyCsvParser.Mapping;
using Xamarin.Forms;


namespace CreativeAssessment
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Student> Class { get; private set; }
        public MainPage()
        {
            InitializeComponent();
            Class = new ObservableCollection<Student>();

            // AddTestStudents();

            BindingContext = this;



        }

        void AddTestStudents()
        {
            Class.Add(new Student
            {
                MatriculationNumber = 40406489,
                Name = "Kaci",
                Surname = "Yan",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40442953,
                Name = "Claire",
                Surname = "Duffy",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40441523,
                Name = "Sean",
                Surname = "Patterson",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40089476,
                Name = "Colin",
                Surname = "Kean",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40340717,
                Name = "Grant",
                Surname = "Shaw",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40442328,
                Name = "John",
                Surname = "Gibb",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40406489,
                Name = "Kaci",
                Surname = "Yan",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40442953,
                Name = "Claire",
                Surname = "Duffy",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40441523,
                Name = "Sean",
                Surname = "Patterson",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40089476,
                Name = "Colin",
                Surname = "Kean",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40340717,
                Name = "Grant",
                Surname = "Shaw",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40442328,
                Name = "John",
                Surname = "Gibb",
            });
            Class.Add(new Student
            {
                MatriculationNumber = 40406489,
                Name = "Kaci",
                Surname = "Yan",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40442953,
                Name = "Claire",
                Surname = "Duffy",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40441523,
                Name = "Sean",
                Surname = "Patterson",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40089476,
                Name = "Colin",
                Surname = "Kean",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40340717,
                Name = "Grant",
                Surname = "Shaw",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40442328,
                Name = "John",
                Surname = "Gibb",
            });
            Class.Add(new Student
            {
                MatriculationNumber = 40406489,
                Name = "Kaci",
                Surname = "Yan",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40442953,
                Name = "Claire",
                Surname = "Duffy",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40441523,
                Name = "Sean",
                Surname = "Patterson",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40089476,
                Name = "Colin",
                Surname = "Kean",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40340717,
                Name = "Grant",
                Surname = "Shaw",
            });

            Class.Add(new Student
            {
                MatriculationNumber = 40442328,
                Name = "John",
                Surname = "Gibb",
            });

        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Student selectedItem = e.SelectedItem as Student;
        }

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
                var parseResults=csvParser.ParseStreamToStudentList(fileStream);

                foreach (var item in parseResults)
                {
                    Class.Add(new Student{Marked = item.Result.Marked,MatriculationNumber = item.Result.MatriculationNumber,Name = item.Result.Name,Surname = item.Result.Surname});
                }
            }
            catch (Exception ex)
            {
                // ExceptionHandler.ShowException(ex.Message);
            }


        }


    }

}



