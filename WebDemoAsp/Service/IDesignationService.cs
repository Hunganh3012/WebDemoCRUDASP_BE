using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDemoAsp.Domain;

namespace WebDemoAsp.Service
{
    public interface IDesignationService
    {
        Task<List<Designations>> GetDesignationAsync();
    }
}
