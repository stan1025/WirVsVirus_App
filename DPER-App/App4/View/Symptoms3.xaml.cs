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
    public partial class Symptoms3 : ContentPage
    {
        SymptomsViewModel vm;
        public Symptoms3(SymptomsViewModel _vm)
        {
            InitializeComponent();
            vm = _vm;
            this.BindingContext = vm;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await vm.ExecuteFinishCommand();
            ResultViewModel vm_result = new ResultViewModel();
            var detailPage = new ResultPage();
            await Navigation.PushModalAsync(detailPage);

        }
    }
}