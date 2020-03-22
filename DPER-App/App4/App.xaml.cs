using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DPER_App.View;

namespace DPER_App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new Startpage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
