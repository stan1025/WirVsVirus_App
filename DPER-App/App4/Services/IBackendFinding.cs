using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vdivsvirus.Types;

namespace DPER_App.Services
{
    public interface IBackendFinding
    {
        Task<bool> NewFindingAvailable(Guid id, DateTime time);

        Task<UserResponseDataSet> RequestFinding(Guid id, DateTime time);

        Task<UserHistoryDataSet> RequestFindingHistory(Guid id);
    }
}
