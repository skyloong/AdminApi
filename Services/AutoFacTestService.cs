using IRepository;
using IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class AutoFacTestService : IAutoFacTestService
    {
        private readonly IAutofacTestRepository _autofacTestRepository;
        public AutoFacTestService(IAutofacTestRepository autofacTestRepository)
        {
            _autofacTestRepository = autofacTestRepository;
        }
        public string Fuck(string fuck)
        {
            return _autofacTestRepository.Fuck() + fuck;
        }
    }
}
