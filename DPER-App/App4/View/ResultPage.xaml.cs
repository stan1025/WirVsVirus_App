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
    public partial class ResultPage : ContentPage
    {
        public ResultPage(ResultViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}