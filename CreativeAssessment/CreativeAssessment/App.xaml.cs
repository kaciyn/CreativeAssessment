using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CreativeAssessment
{
    public partial class App : Application
    {
        //Contains filepath, no need for instance to be accessed.
        public static string FilePath;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            
           
        }

        //Constructor which takes filepath to database
        public App(string filepath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.LaunchPage());
            

            FilePath = filepath;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
