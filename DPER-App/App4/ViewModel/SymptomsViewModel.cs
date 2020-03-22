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

        private int _contactIndex;
        public int ContactIndex
        {
            get {
                
                if (Contact = true)
                {
                    _contactIndex = 0;
                }
                else
                {
                    _contactIndex = 1;
                }
                return _contactIndex;
            } 
            set
            {
                _contactIndex = value;
                if (ContactIndex == 0)
                {
                    Contact = true;
                }
                else
                {
                    Contact = false;
                }
            }
        }

        private bool _contact;
        public bool Contact
        {
            get => _contact;
            set { _contact = value; }
        }
             
        private float _feverValue;
        public float FeverValue
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
