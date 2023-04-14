using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDemoAsp.Contract.Model;
using WebDemoAsp.Service;

namespace WebDemoAsp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        public readonly IDesignationService _Deg;
        public readonly IMapper _mapper;

        public DesignationController( IDesignationService Deg , IMapper mapper)
        {
            _Deg = Deg;
            _mapper = mapper;
        
       }

        [HttpGet]
        public  async Task<IActionResult> GetAll()
        {
            var deg = await _Deg.GetDesignationAsync();
            //var degModel = _mapper.Map<IEnumerable<DesignationModel>>(deg);
            return Ok(deg);
         }
    }
}
