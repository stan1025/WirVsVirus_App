using DPER_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DPER_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPersonsPage : ContentPage
    {
        SymptomsViewModel vm;
        public ContactPersonsPage()
        {
            InitializeComponent();
          vm = new SymptomsViewModel();
            this.BindingContext = vm;
            
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            var detailPage = new Symptome1(vm);

            await Navigation.PushModalAsync(detailPage);
        }
    }
}