using IRepository;
using IRepository.UnitOfWork;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class AutoFacTestRepository : BaseRepository<SwaggerTest>, IAutofacTestRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public AutoFacTestRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string Fuck()
        {
            return "fuck";
        }
    }
}
