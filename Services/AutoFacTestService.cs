using Common.Helper;
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
            try
            {
                throw new Exception("发生错误");
                return _autofacTestRepository.Fuck() + fuck;
            } catch (Exception e)
            {
                LogHelper.Error("错误", e);
            }
            return "";
        }
    }
}
