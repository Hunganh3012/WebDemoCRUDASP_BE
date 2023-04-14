using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebDemoAsp.Contract.Model;

namespace WebDemoAsp.DAL
{
    public class EmpStore
    {

        //private readonly string connectionString;
        //public EmpStore(string connectionString)
        //{
        //    this.connectionString = connectionString;
        //}
        //public IEnumerable<EmployeeModel> GetDatabyStore(int param1, int param2)
        //{
        //    List<EmployeeModel> mydata = new List<EmployeeModel>()
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand("dbo.CountDown_Age", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@Param1", param1);
        //            command.Parameters.AddWithValue("@Param2", param2);


        //            connection.Open();
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    EmployeeModel myModel = new EmployeeModel();
        //                    myModel.Id = Convert.ToInt32(reader["Id"]);
        //                    myModel.Name = Convert.ToString(reader["Name"]);
        //                    mydata.Add(myModel);
        //                }
        //            }
        //        }

        //    }
        //    return mydata;
        //}
    }
}
