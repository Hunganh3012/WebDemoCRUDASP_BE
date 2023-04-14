using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDemoAsp.Contract.Model;
using WebDemoAsp.Domain;

namespace WebDemoAsp.Mapping
{
    public class DomainToRespoMappingProfile : Profile
    {
        public  DomainToRespoMappingProfile()
        {
            CreateMap<Employee, EmployeeModel>();
            CreateMap<Designations, DesignationModel>();
        }
    }
}
