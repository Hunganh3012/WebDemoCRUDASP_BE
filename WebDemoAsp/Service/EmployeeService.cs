
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebDemoAsp.Contract.CommonFilter;
using WebDemoAsp.Contract.Model;
using WebDemoAsp.Contract.Request;
using WebDemoAsp.Data;
using WebDemoAsp.Domain;
using WebDemoAsp.Exceptions;

namespace WebDemoAsp.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _dtcontext;
         public EmployeeService( DataContext dtcontext)
        {
            _dtcontext = dtcontext;
        }
        public async Task<int> CreatEmployeeAsync(CreateEmployeeRequest request)
        {
            //throw new NotImplementedException();
            var emp = new Employee
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                Age = request.Age,
                Designation = request.Designation,
                DesignationID = request.DesignationID,
                Doj = request.Doj,
                Gender = request.Gender

            };
            _dtcontext.Employee.Add(emp);
            await _dtcontext.SaveChangesAsync();
            return emp.Id;

        }

        public async Task<List<EmployeeModel>> GetEmployeeAsync(EmployeeFilter filter)
        {
            try
            {
                var paramater = new Object[]
          {
                filter.LastName,
                filter.Name,
                filter.Email,
                filter.Gender
          };
                var employee = await _dtcontext.Employee.FromSqlRaw("EXEC [dbo].[getEmployee] @filterLastName={0}, @filterName={1} , @filterEmail={2}, @filterGender={3}", paramater).ToListAsync();
                return employee.Select(e => new EmployeeModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    LastName = e.LastName,
                    Age = e.Age,
                    Gender = e.Gender,
                    Email = e.Email,
                    Designation = e.Designation,
                    DesignationID = e.DesignationID,
                    Doj = e.Doj,
                    isDelete = e.isDelete


                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
          

        }


        public async Task<Employee> GetEmployeeAsync(int EmpId)
        {
            //throw new NotImplementedException();
            return await _dtcontext.Employee.SingleOrDefaultAsync(s => s.Id == EmpId);
        }
        public async Task<int> Delete(int empId)
        {

            {
                var id = _dtcontext.Employee.Where(e => e.Id == empId);

                foreach (var row in id)
                {
                    row.isDelete = true;
                }
                var result = await _dtcontext.Employee.Where(row => row.isDelete != true).ToListAsync();
                return await _dtcontext.SaveChangesAsync();
            }
           

        }
        public async  Task<int> UpdateD (List<int> empId)
        {
 
                                   
            var rowtoUpdate = _dtcontext.Employee.Where(row => empId.Contains(row.Id) );
            foreach(var row in rowtoUpdate)
            {
                row.isDelete = true;
            }
            var result = await  _dtcontext.Employee.Where(row => row.isDelete != true).ToListAsync();

            //return await result;
            return await _dtcontext.SaveChangesAsync();
        }

        public async Task<int> Update( UpdateEmployeeRequest request)
        {

            var emps = await _dtcontext.Employee.FirstOrDefaultAsync(x => x.Id == request.Id);
            emps.Name = request.Name;
            emps.LastName = request.LastName;
            emps.Gender = request.Gender;
            emps.Designation = request.Designation;
            emps.DesignationID = request.DesignationID;
            emps.Email = request.Email;
            emps.Doj = request.Doj;
            emps.Age = request.Age;
            return await _dtcontext.SaveChangesAsync();
        }
            
        

    }
}









//var employee = (from e in _dtcontext.Employee
//                join d in _dtcontext.Designation
//                on e.DesignationID equals d.Id

//                select new EmployeeModel()
//                {
//                    Id = e.Id,
//                    Name = e.Name,
//                    LastName = e.LastName,
//                    Email = e.Email,
//                    Age = e.Age,
//                    DesignationID = e.DesignationID,
//                    Designation = d.Designation,
//                    Doj = e.Doj,
//                    Gender = e.Gender,
//                    isDelete = e.isDelete

//                }
//              ).Where(q => q.isDelete != true
//                           && q.LastName.ToLower().IndexOf(filter.LastName) != -1
//                        && q.Name.ToLower().IndexOf(filter.Name) != -1
//                        && q.Email.ToLower().IndexOf(filter.Email) != -1
//                        && q.Gender.ToLower().IndexOf(filter.Gender) != -1
//                        && q.Email.ToLower().IndexOf(filter.Email) != -1
//                        && q.Gender.ToLower().IndexOf(filter.Gender) != -1

//                    )

//              .AsNoTracking().ToListAsync();
