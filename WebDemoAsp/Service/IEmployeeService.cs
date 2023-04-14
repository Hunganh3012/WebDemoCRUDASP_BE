using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDemoAsp.Contract.CommonFilter;
using WebDemoAsp.Contract.Model;
using WebDemoAsp.Contract.Request;
using WebDemoAsp.Domain;

namespace WebDemoAsp.Service
{
    public interface IEmployeeService  
    {
    
        //Lấy danh sách nhân viên (bđbộ)
        Task<List<EmployeeModel>> GetEmployeeAsync(EmployeeFilter filter);

        //Lấy chi tiết nhân viên
        Task<Employee> GetEmployeeAsync(int EmpId);

        Task<int> CreatEmployeeAsync(CreateEmployeeRequest request);

        Task<int> Delete(int Empid);
        Task<int> UpdateD(List<int> EmpId);
        
        Task<int> Update(UpdateEmployeeRequest request);

    }
}
