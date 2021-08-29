using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRepository
{
    public interface IAutofacTestRepository : IBaseRepository<SwaggerTest>
    {
        string Fuck();
    }
}
