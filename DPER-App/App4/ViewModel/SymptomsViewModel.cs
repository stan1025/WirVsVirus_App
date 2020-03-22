using DPER_App.ViewModels;
using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DPER_App.View;
using System.Diagnostics;

namespace DPER_App.ViewModel
{
    public class SymptomsViewModel : BaseViewModel
    {

        public Command FinishCommand { get; set; }
        public SymptomsViewModel()
        {
            FinishCommand = new Command(async () => await ExecuteFinishCommand());
            FeverValue = 35;

        }

        #region Symptoms
        private bool _contact;
        public bool Contact
        {
            get => _contact;
            set { _contact = value; }
        }
             
        private int _feverValue;
        public int FeverValue
        {
            get => _feverValue;
            set { _feverValue = value; }
        }
        private int _frost;
        public int Frost
        {
            get => _frost;
            set { _frost = value; }
        }
        private int _limp;
        public int Limp
        {
            get => _limp;
            set { _limp = value; }
        }
        private int _aches;
        public int Aches
        {
            get => _aches;
            set { _aches = value; }
        }
        private int _cough;
        public int Cough
        {
            get => _cough;
            set { _cough = value; }
        }
        private int _sniff;
        public int Sniff
        {
            get => _sniff;
            set { _sniff = value; }
        }
        private int _diarrhea;
        public int Diarrhea
        {
            get => _diarrhea;
            set { _diarrhea = value; }
        }
        private int _sorethroat;
        public int Sorethroat
        {
            get => _sorethroat;
            set { _sorethroat = value; }
        }
        private int _headache;
        public int Headache
        {
            get => _headache;
            set { _headache = value; }
        }

        private int _outOfBreath;
        public int OutOfBreath
        {
            get => _outOfBreath;
            set { _outOfBreath = value; }
        }
        #endregion
        async Task ExecuteFinishCommand()
        {
            IsBusy = true;

            try
            {
                Debug.WriteLine(FeverValue.ToString());
                Debug.WriteLine(Headache);
                Debug.WriteLine(Limp);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}
