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
      
        public Symptoms3(SymptomsViewModel vm)
        {
            InitializeComponent();            
            this.BindingContext = vm;
        }

      
    }
}