using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vdivsvirus.Types;

namespace DPER_App.Services
{
    interface IBackendSymptome
    {
        Task<List<SymptomeIdentData>> GetSymptomesAsync();

        Task SendSymptomeDataSetAsync(SymptomeInputDataSet symptomes);

        Task SendDiseaseDataSetAsync(Guid userId, DiseaseDataSet disease);
    }
}
