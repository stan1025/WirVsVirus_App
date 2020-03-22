using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vdivsvirus.Types;

namespace DPER_App.Services
{
    interface IBackendSymptome
    {
        List<SymptomeIdentData> GetSymptomes();

        void SendSymptomeDataSet(SymptomeInputDataSet symptomes);

        void SendDiseaseDataSet(Guid userId, DiseaseAcknowledgeSet disease);
    }
}
