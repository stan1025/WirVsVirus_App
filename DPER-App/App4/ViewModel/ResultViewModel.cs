using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DPER_App.Services;
using DPER_App.Models;
using vdivsvirus.Types;
using Xamarin.Forms;

namespace DPER_App.ViewModel
{
    public class ResultViewModel
    { 
        /// <summary>
        /// Result of the riskcalculation to be infected with Corona
        /// </summary>
        public string ResultMessage { get; private set; }
        public ResultViewModel()
        {
            ResultMessage = "Bitte warten, Ergebnis wird geladen";
            IBackendFinding itfFinding = new RestClient();
            if (Application.Current.Properties.ContainsKey("userId") && Application.Current.Properties.ContainsKey("lastEntry"))
            {
                Guid userId = Guid.Parse(Application.Current.Properties["userId"].ToString());
                DateTime lastEntry = DateTime.Parse(Application.Current.Properties["lastEntry"].ToString());
                while (!(itfFinding.NewFindingAvailable(userId, lastEntry)))
                    System.Threading.Thread.Sleep(500);
                UserResponseDataSet response = itfFinding.RequestFinding(userId, lastEntry);
                int prob = 0; ;
                foreach (DiseaseData item in response.propabilities)
                {
                    if (item.propability > prob)
                        prob = (int)(item.propability);
                }
                ResultMessage = "Sie haben zu " + prob.ToString() + "% Corona";
            }

        }
    }
}
