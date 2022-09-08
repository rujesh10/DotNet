using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace krishmakc.Models
{
    public class StudentModel
    {
        [DisplayName("Roll No.")]
        
        public int RollNo { get; set; }

        [DisplayName("Full Name")]
        [MaxLength(50)]
        public string FullName { get; set; }
        public string Address { get; set; }

        [Range(1,120)]
        
        public int Age { get; set; }

        [DisplayName("Contact Number")]
        public string ContactNo { get; set; }

    }
}