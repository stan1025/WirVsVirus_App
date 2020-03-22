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
    public partial class Symptoms2 : ContentPage
    {
        SymptomsViewModel vm;
        public Symptoms2(SymptomsViewModel _vm)
        {
            InitializeComponent();
            vm = _vm;
            this.BindingContext = vm;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            var detailPage = new Symptoms3(vm);

            await Navigation.PushModalAsync(detailPage);
        }
    }
}