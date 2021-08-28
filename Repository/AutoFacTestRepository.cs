using IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class AutoFacTestRepository : IAutofacTestRepository
    {
        public string Fuck()
        {
            return "fuck";
        }
    }
}
