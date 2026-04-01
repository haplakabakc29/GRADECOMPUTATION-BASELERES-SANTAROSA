using System;
using System.Collections.Generic;
using System.Text;

namespace GradeComputationDataServices
{
    public class GradeDataService
    {
        private readonly IGradeMngDataService _service;

        public GradeDataService(IGradeMngDataService service)
        {
            _service = service;
        }

        public void AddLog(DModels account)
        {
            _service.AddLog(account);
        }
        public List<DModels> GetAccounts()
        {
           return _service.GetGradeLogs();
        }
        public void DeleteAll() 
        {     
            _service.DeleteAll(); 
        }
    }
}
