using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDemoAsp.Contract.CommonFilter;
using WebDemoAsp.Contract.Model;
using WebDemoAsp.Contract.Request;
using WebDemoAsp.Domain;
using WebDemoAsp.Service;

namespace WebDemoAsp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _EmpService;
        private readonly IMapper _mapper;
        public EmployeeController( IEmployeeService EmpService, IMapper mapper)
        {
            _EmpService = EmpService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] EmployeeFilter filter)
        {
            
            var emp = await _EmpService.GetEmployeeAsync(filter);
            var empModel =  _mapper.Map<IEnumerable<EmployeeModel>>(emp);
            return Ok(empModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var emp = await _EmpService.GetEmployeeAsync(id);
            //var empModel = _mapper.Map<List<EmployeeModel>>(emp);
            if (id == null)
                return NotFound("No record  found");    
            return Ok(emp);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request)
        {
            var emp = await _EmpService.CreatEmployeeAsync(request);
            if( emp == 0)
            {
                return BadRequest();
            };
            return CreatedAtAction("GetAll", new { id = emp }, emp);

        }
        [HttpPost("DeleteList")]
        public async Task<IActionResult> DeleteList([FromBody] List<int> Ids)
        {
            if(Ids==null || Ids.Count==0)
            {
                return BadRequest();
            }    
            var emp = await _EmpService.UpdateD(Ids);
            //var empMap = _mapper.Map <List<EmployeeModel>>(emp);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( int id)
        {
            if (id == 0) return BadRequest();
            
            var emp = await _EmpService.Delete(id);
            return Ok(emp);
 ;       }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update( int Id, [FromBody] UpdateEmployeeRequest request)
        {
            request.Id = Id;
            var empUpdate = await _EmpService.Update(request);
            //var empModel= _mapper.Map < IEnumerable<EmployeeModel>>(empUpdate);
            return Ok(empUpdate);
        }

        
    }
}
