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
using vdivsvirus.Types;

namespace DPER_App.ViewModel
{
    public class SymptomsViewModel : BaseViewModel
    {

        
        public Command FinishCommand { get; set; }
        public SymptomsViewModel()
        {
            FinishCommand = new Command(async () => await ExecuteFinishCommand());
            FeverValue = 35;
            List<SymptomeIdentData> ItemsList = dummyData();

            Diarrhea = new Item();
            Cough = new Item();
            Limp = new Item();
            OutOfBreath = new Item();
            Aches = new Item();
            Sorethroat = new Item();
            Headache = new Item();
            Frost = new Item();
            Nausea = new Item();
            Sniff = new Item();



            foreach (SymptomeIdentData item in ItemsList)
            {                
                int min = int.Parse(item.settings.Substring(0, item.settings.IndexOf(";") ));
                string feverSubString = item.settings.Substring(item.settings.IndexOf(";") + 1);
                int max = int.Parse(feverSubString.Substring(0, feverSubString.IndexOf(";"))); 

                switch (item.name)
                {
                    case "Fieber":
                        FeverMin = min;
                        FeverMax = max;
                        feverID = item.id;

                        break;
                    case "Schüttelfrost":
                        Frost.Min = min;
                        Frost.Max = max;
                        Frost.ID = item.id;
                        break;
                    case "Husten":
                        Cough.Min = min;
                        Cough.Max = max;
                        Cough.ID = item.id;
                        break;
                    case "Abgeschlagenheit":
                        Limp.Min = min;
                        Limp.Max = max;
                        Limp.ID = item.id;
                        break;
                    case "Kurzatmigkeit":
                        OutOfBreath.Min = min;
                        OutOfBreath.Max = max;
                        OutOfBreath.ID = item.id;
                        break;
                    case "Muskel-/Gelenkschmerz":
                        Aches.Min = min;
                        Aches.Max = max;
                        Aches.ID = item.id;
                        break;
                            case "Halsschmerz":
                        Sorethroat.Min = min;
                        Sorethroat.Max = max;
                        Sorethroat.ID = item.id;
                        break;
                    case "Kopfschmerz":
                        Headache.Min = min;
                        Headache.Max = max;
                        Headache.ID = item.id;
                        break;
                    case "Übelkeit":
                        Nausea.Min = min;
                        Nausea.Max = max;
                        Nausea.ID = item.id;
                        break;
                    case "Verstopfte Nase":
                        
                        Sniff.Max = max;
                        Sniff.Min = min;                        
                        Sniff.ID = item.id;
                        break;
                    case "Durchfall":

                        
                        Diarrhea.Max = max;
                        Diarrhea.Min = min;
                        Diarrhea.ID = item.id;
                        break;
                    default:
                        break;



                }
            }
        }

        #region Symptoms

        private int _contactIndex;
        public int ContactIndex
        {
            get {
                
                if (Contact == true)
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
        private int feverID;
        public float FeverMin { get; private set; }
        public float FeverMax { get; private set; }
        private Item _frost;
        public Item Frost
        {
            get => _frost;
            set { _frost = value; }
        }
        
        private Item _limp;
        public Item Limp
        {
            get => _limp;
            set { _limp = value; }
        }
        

        private Item _aches;
        public Item Aches
        {
            get => _aches;
            set { _aches = value; }
        }
        
        private Item _cough;
        public Item Cough
        {
            get => _cough;
            set { _cough = value; }
        }
       
        private Item _sniff;
        public Item Sniff
        {
            get => _sniff;
            set { _sniff = value; }
        }

        private Item _diarrhea;
        public Item Diarrhea
        {
            get => _diarrhea;
            set { _diarrhea = value; }
        }
     
        private Item _sorethroat;
        public Item Sorethroat
        {
            get => _sorethroat;
            set { _sorethroat = value; }
        }
     
        private Item _headache;
        public Item Headache
        {
            get => _headache;
            set { _headache = value; }
        }
      
        private Item _outOfBreath;
        public Item OutOfBreath
        {
            get => _outOfBreath;
            set { _outOfBreath = value; }
        }

        private Item _nausea;
        public Item Nausea
        {
            get => _nausea;
            set { _nausea = value; }
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
        private List<SymptomeIdentData> dummyData()
        {

            List<SymptomeIdentData> list = new List<SymptomeIdentData>();
            list.Add( new SymptomeIdentData() { name = "Durchfall", settings = "0;100;1" });
            list.Add(new SymptomeIdentData() { name = "Übelkeit", settings = "0;100;1" });
            list.Add(new SymptomeIdentData() { name = "Fieber", settings = "35;45;1" });
            list.Add(new SymptomeIdentData() { name = "Abgeschlagenheit", settings = "0;100;1" });
            list.Add(new SymptomeIdentData() { name = "Husten", settings = "0;100;1" });
            list.Add(new SymptomeIdentData() { name = "Kurzatmigkeit", settings = "0;100;1" });
            list.Add(new SymptomeIdentData() { name = "Muskel-/Gelenkschmerz", settings = "35;45;1" });
            list.Add(new SymptomeIdentData() { name = "Halsschmerz", settings = "0;100;1" });
            list.Add(new SymptomeIdentData() { name = "Kopfschmerz", settings = "0;100;1" });
            list.Add(new SymptomeIdentData() { name = "Schüttelfrost", settings = "0;100;1" });
            list.Add(new SymptomeIdentData() { name = "Verstopfte Nase", settings = "0;100;1" });
            return list;
        }
    }
}
