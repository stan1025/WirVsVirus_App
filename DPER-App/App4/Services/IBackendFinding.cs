using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vdivsvirus.Types;

namespace DPER_App.Services
{
    public interface IBackendFinding
    {
        bool NewFindingAvailable(Guid id, DateTime time);

        UserResponseDataSet RequestFinding(Guid id, DateTime time);

        UserHistoryDataSet RequestFindingHistory(Guid id);
    }
}
