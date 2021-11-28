using Common.Helper;
using IRepository;
using IServices;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Services
{
    public class AutoFacTestService : BaseService<SwaggerTest>, IAutoFacTestService
    {
        private readonly IAutofacTestRepository _autofacTestRepository;
        public AutoFacTestService(IAutofacTestRepository autofacTestRepository, IMapper mapper)
        {
            _autofacTestRepository = autofacTestRepository;
            base.BaseDal = autofacTestRepository;
            base.Mapper = mapper;
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
