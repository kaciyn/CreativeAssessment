using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreativeAssessment.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LaunchPage : ContentPage
	{
		public LaunchPage ()
		{
			InitializeComponent ();
		}

       
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateModulePage());

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ClassPage());

        }

        private void Button_Clicked_Mark(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MarkingPage());

        }
    }
}