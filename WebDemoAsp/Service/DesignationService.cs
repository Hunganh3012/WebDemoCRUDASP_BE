using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDemoAsp.Data;
using WebDemoAsp.Domain;

namespace WebDemoAsp.Service
{
    public class DesignationService : IDesignationService
    {
        private readonly DataContext _dtcontext;
        public DesignationService(DataContext dtcontext)
        {
            _dtcontext = dtcontext;
        }
        public async Task<List<Designations>> GetDesignationAsync()
        {
            //throw new NotImplementedException();
            return await _dtcontext.Designation.ToListAsync();
        }
    }
}
