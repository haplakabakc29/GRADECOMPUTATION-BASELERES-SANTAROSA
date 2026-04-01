using System;
using System.Collections.Generic;
using System.Text;

namespace GradeComputationDataServices
{
    public interface IGradeMngDataService
    {
       public void AddLog(DModels account);
       public List<DModels> GetGradeLogs();
       public void DeleteAll();
    }
}
