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
      
       
        public SymptomsViewModel()
        {
            if (Application.Current.Properties.ContainsKey("userId"))
                userId = Guid.Parse(Application.Current.Properties["userId"].ToString());
            else
            {
                userId = Guid.NewGuid();
                Application.Current.Properties["userId"] = userId;
            }

            
                        itfSymptome = new RestClient();
            List<SymptomeIdentData> ItemsList = itfSymptome.GetSymptomesAsync().Result;
            //List<SymptomeIdentData> ItemsList = dummyData();


            //initialize Symptoms
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


            //Match sympthoms with their backendnames
            foreach (SymptomeIdentData item in ItemsList)
            {
                switch (item.name)
                {
                    case "Fieber":
                        Fever.parseSettings(item.settings);
                        Fever.ID = item.id;

                        break;
                    case "Schüttelfrost":
                        Frost.parseSettings(item.settings);
                        Frost.ID = item.id;
                        break;
                    case "Husten":
                        Cough.parseSettings(item.settings);
                        Cough.ID = item.id;
                        break;
                    case "Abgeschlagenheit":
                        Limp.parseSettings(item.settings);
                        Limp.ID = item.id;
                        break;
                    case "Kurzatmigkeit":
                        OutOfBreath.parseSettings(item.settings);
                        OutOfBreath.ID = item.id;
                        break;
                    case "Muskel-/Gelenkschmerz":
                        Aches.parseSettings(item.settings);
                        Aches.ID = item.id;
                        break;
                    case "Halsschmerz":
                        Sorethroat.parseSettings(item.settings);
                        Sorethroat.ID = item.id;
                        break;
                    case "Kopfschmerz":
                        Headache.parseSettings(item.settings);
                        Headache.ID = item.id;
                        break;
                    case "Übelkeit":
                        Nausea.parseSettings(item.settings);
                        Nausea.ID = item.id;
                        break;
                    case "Verstopfte Nase":
                        Sniff.parseSettings(item.settings);
                        Sniff.ID = item.id;
                        break;
                    case "Durchfall":
                        Diarrhea.parseSettings(item.settings);
                        Diarrhea.ID = item.id;
                        break;
                    default:
                        break;



                }
            }
        }

        #region Symptoms
        /// <summary>
        /// Pickerindex für Contacts
        /// </summary>
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
            get { return _feverValue; }
            set
            {
                _feverValue = value;
                _feverString = _feverValue.Value.ToString();

            }
        }

        /// <summary>
        /// Fieber
        /// </summary>
        private string _feverString;
        public string FeverString
        {
            get => _feverString;
            set
            {
                _feverString = value;
            }
        }

        /// <summary>
        /// Schüttelfrost
        /// </summary>
        private Item<int> _frost;
        public Item<int> Frost
        {
            get => _frost;
            set { _frost = value; }
        }
        /// <summary>
        /// Abgeschlagenheit
        /// </summary>
        private Item<int> _limp;
        public Item<int> Limp
        {
            get => _limp;
            set { _limp = value; }
        }

        /// <summary>
        /// Muskel und Gliederschmerzen
        /// </summary>
        private Item<int> _aches;
        public Item<int> Aches
        {
            get => _aches;
            set { _aches = value; }
        }

        /// <summary>
        /// Husten
        /// </summary>
        private Item<int> _cough;
        public Item<int> Cough
        {
            get => _cough;
            set { _cough = value; }
        }

        /// <summary>
        /// Schnupfen/ verstopfte Nase
        /// </summary>
        private Item<int> _sniff;
        public Item<int> Sniff
        {
            get => _sniff;
            set { _sniff = value; }
        }

        /// <summary>
        /// Durchfall
        /// </summary>
        private Item<int> _diarrhea;
        public Item<int> Diarrhea
        {
            get => _diarrhea;
            set { _diarrhea = value; }
        }

        /// <summary>
        /// Halsschmerzen
        /// </summary>

        private Item<int> _sorethroat;
        public Item<int> Sorethroat
        {
            get => _sorethroat;
            set { _sorethroat = value; }
        }

        /// <summary>
        /// Kopfschmerzen
        /// </summary>
        private Item<int> _headache;
        public Item<int> Headache
        {
            get => _headache;
            set { _headache = value; }
        }


        /// <summary>
        /// Kurzatmigkeit/ Atemnot
        /// </summary>
        private Item<int> _outOfBreath;
        public Item<int> OutOfBreath
        {
            get => _outOfBreath;
            set { _outOfBreath = value; }
        }

        /// <summary>
        /// Übelkeit
        /// </summary>
        private Item<int> _nausea;
        public Item<int> Nausea
        {
            get => _nausea;
            set { _nausea = value; }
        }
        #endregion

        public async Task ExecuteFinishCommand()
        {
            IsBusy = true;

            try
            {
                SymptomeInputDataSet data = new SymptomeInputDataSet();                
                Application.Current.Properties["lastEntry"] = DateTime.Now.ToString();
                data.time = DateTime.Parse(Application.Current.Properties["lastEntry"].ToString());
                data.userID = userId;
                data.geodata = new List<GeoData>();
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
                await itfSymptome.SendSymptomeDataSetAsync(data);
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
            list.Add(new SymptomeIdentData() { name = "Halsschmerz", settings = "min=0;max=100;step=1" });
            list.Add(new SymptomeIdentData() { name = "Kopfschmerz", settings = "min=0;max=100;step=1" });
            list.Add(new SymptomeIdentData() { name = "Schüttelfrost", settings = "Min=0;max=100;step=1" });
            list.Add(new SymptomeIdentData() { name = "Verstopfte Nase", settings = "min=0;Max=100;tep=1" });
            return list;
        }
    }
}
