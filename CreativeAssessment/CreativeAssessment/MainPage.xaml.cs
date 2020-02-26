using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            AddTestStudents();

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


        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Student selectedItem = e.SelectedItem as Student;
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            Student tappedItem = e.Item as Student;
        }

    }


}
