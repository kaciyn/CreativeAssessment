﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CreativeAssessment
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnClickOpenCreateModulePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateModulePage());
        }
    }
}
