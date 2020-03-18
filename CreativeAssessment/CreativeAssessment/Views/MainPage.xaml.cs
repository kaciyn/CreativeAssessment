﻿using System;
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
        // public ObservableCollection<Student> Class { get; private set; }

        public ObservableCollection<Module> Modules { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            // Class = new ObservableCollection<Student>();
            Modules = new ObservableCollection<Module>();

            // AddTestStudents();

            BindingContext = this;
        }



    }
}


