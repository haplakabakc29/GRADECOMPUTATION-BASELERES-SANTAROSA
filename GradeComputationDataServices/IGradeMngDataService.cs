using System;
using System.Collections.Generic;
using System.Text;

namespace GradeComputationDataServices
{
    public interface IGradeMngDataService
    {
        void AddLog(DModels account);
        List<DModels> GetGradeLogs();
        void DeleteAll();
        void UpdateGrade(DModels account);
    }
}

