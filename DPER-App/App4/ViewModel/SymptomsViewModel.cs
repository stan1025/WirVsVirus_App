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
using DPER_App.Services;
using DPER_App.Models;
using System.Text.RegularExpressions;

namespace DPER_App.ViewModel
{
    public class SymptomsViewModel : BaseViewModel
    {
        private IBackendSymptome itfSymptome;

        private static Guid userId;

        public Command FinishCommand { get; set; }
        public SymptomsViewModel()
        {
            //TODO: besserer Ort, muss für einen Nutzer fix sein
            userId = Guid.NewGuid();

            FinishCommand = new Command(async () => await ExecuteFinishCommand());
                        itfSymptome = new RestClient();
          // List<SymptomeIdentData> ItemsList = itfSymptome.GetSymptomesAsync().Result;
            List<SymptomeIdentData> ItemsList = dummyData();

            Fever = new Item<float>();
            Diarrhea = new Item<int>();
            Cough = new Item<int>();
            Limp = new Item<int>();
            OutOfBreath = new Item<int>();
            Aches = new Item<int>();
            Sorethroat = new Item<int>();
            Headache = new Item<int>();
            Frost = new Item<int>();
            Nausea = new Item<int>();
            Sniff = new Item<int>();



            foreach (SymptomeIdentData item in ItemsList)
            {
                int min = 0;
                int max = 100;
                if (!string.IsNullOrWhiteSpace(item.settings) & item.settings.Contains(";"))
                {
                   
                    string input = item.settings;
                    string pattern = @";";

                    string[] splttingeResults = Regex.Split(input, pattern);

                    foreach (string part in Regex.Split(input, pattern))
                    {
                        switch (part)
                        {
                            case "min":
                            case "Min":
                                min = int.Parse(part.Substring(part.IndexOf("=")));
                                break;
                            case "max":
                            case "Max":
                                max = int.Parse(part.Substring(part.IndexOf("=")));
                                break;
                            default: break;
                        }
                    }
                }
                switch (item.name)
                {
                    case "Fieber":
                        Fever.Min = min;
                        Fever.Max = max;
                        Fever.ID = item.id;

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
            get
            {

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
                if (_contactIndex == 0)
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

        private Item<float> _feverValue;
        public Item<float> Fever
        {
            get => _feverValue;
            set { _feverValue = value; }
        }

        private Item<int> _frost;
        public Item<int> Frost
        {
            get => _frost;
            set { _frost = value; }
        }

        private Item<int> _limp;
        public Item<int> Limp
        {
            get => _limp;
            set { _limp = value; }
        }


        private Item<int> _aches;
        public Item<int> Aches
        {
            get => _aches;
            set { _aches = value; }
        }

        private Item<int> _cough;
        public Item<int> Cough
        {
            get => _cough;
            set { _cough = value; }
        }

        private Item<int> _sniff;
        public Item<int> Sniff
        {
            get => _sniff;
            set { _sniff = value; }
        }

        private Item<int> _diarrhea;
        public Item<int> Diarrhea
        {
            get => _diarrhea;
            set { _diarrhea = value; }
        }

        private Item<int> _sorethroat;
        public Item<int> Sorethroat
        {
            get => _sorethroat;
            set { _sorethroat = value; }
        }

        private Item<int> _headache;
        public Item<int> Headache
        {
            get => _headache;
            set { _headache = value; }
        }

        private Item<int> _outOfBreath;
        public Item<int> OutOfBreath
        {
            get => _outOfBreath;
            set { _outOfBreath = value; }
        }

        private Item<int> _nausea;
        public Item<int> Nausea
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
                SymptomeInputDataSet data = new SymptomeInputDataSet();
                data.time = DateTime.Now;
                data.userID = userId;
                data.symptomes = new List<SymptomeInputData>();
                data.symptomes.Add(new SymptomeInputData() { id = Fever.ID, strength = Fever.Value });
                data.symptomes.Add(new SymptomeInputData() { id = Diarrhea.ID, strength = Diarrhea.Value });
                data.symptomes.Add(new SymptomeInputData() { id = Cough.ID, strength = Cough.Value });
                data.symptomes.Add(new SymptomeInputData() { id = Limp.ID, strength = Limp.Value });
                data.symptomes.Add(new SymptomeInputData() { id = OutOfBreath.ID, strength = OutOfBreath.Value });
                data.symptomes.Add(new SymptomeInputData() { id = Aches.ID, strength = Aches.Value });
                data.symptomes.Add(new SymptomeInputData() { id = Sorethroat.ID, strength = Sorethroat.Value });
                data.symptomes.Add(new SymptomeInputData() { id = Headache.ID, strength = Headache.Value });
                data.symptomes.Add(new SymptomeInputData() { id = Frost.ID, strength = Frost.Value });
                data.symptomes.Add(new SymptomeInputData() { id = Nausea.ID, strength = Nausea.Value });
                data.symptomes.Add(new SymptomeInputData() { id = Sniff.ID, strength = Sniff.Value });
                itfSymptome.SendSymptomeDataSetAsync(data);
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
            list.Add(new SymptomeIdentData() { name = "Durchfall", settings = "Min=0;Max=100;step=1" });
            list.Add(new SymptomeIdentData() { name = "Übelkeit", settings = "min=0;max=100;step=1" });
            list.Add(new SymptomeIdentData() { name = "Fieber", settings = "min=35;max=45;step=1" });
            list.Add(new SymptomeIdentData() { name = "Abgeschlagenheit", settings = "min=0;max=100;step=1" });
            list.Add(new SymptomeIdentData() { name = "Husten", settings = "min=0;max=100;step=1" });
            list.Add(new SymptomeIdentData() { name = "Kurzatmigkeit", settings = "min=0;max=100;step=1" });
            list.Add(new SymptomeIdentData() { name = "Muskel-/Gelenkschmerz", settings = "min=35;max=45;step=1" });
            list.Add(new SymptomeIdentData() { name = "Halsschmerz", settings = "min=0;max=100;step01" });
            list.Add(new SymptomeIdentData() { name = "Kopfschmerz", settings = "min=0;max=100;step=1" });
            list.Add(new SymptomeIdentData() { name = "Schüttelfrost", settings = "Min=0;max=100;step=1" });
            list.Add(new SymptomeIdentData() { name = "Verstopfte Nase", settings = "min=0;Max=100;tep=1" });
            return list;
        }
    }
}
