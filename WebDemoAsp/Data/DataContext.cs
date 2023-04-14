using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDemoAsp.Domain;

namespace WebDemoAsp.Data
{
    public class DataContext :DbContext
    {

        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {
        }

        public DbSet<Designations> Designation { set; get; }

        public DbSet<Employee> Employee { set; get; }
    }
}
