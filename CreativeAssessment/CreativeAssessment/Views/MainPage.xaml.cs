using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CreativeAssessment.backend_Classes.Entities;
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


        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }



    }
}



