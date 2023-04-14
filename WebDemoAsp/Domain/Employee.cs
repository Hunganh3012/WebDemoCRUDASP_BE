using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemoAsp.Domain
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //EF sẽ tạo cột IDENTITY trong SQL Server cho thuộc tính Id.

        public int Id { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(150)]
        public string LastName { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        public int Age { get; set; }

        public DateTime Doj { get; set; }

        [StringLength(20)]
        public string Gender { get; set; }

        public int DesignationID { get; set; }

        [NotMapped]
        public string Designation { get; set; }


        public bool? isDelete { set; get; }


        public DateTime dateDelete { set; get; }

    }
}
