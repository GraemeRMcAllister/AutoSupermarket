using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompleteUserInterface.Models
{
    public class StaffModel
    {
        [Key]
        public int StaffId { get; set; }

        [MaxLength(256)]
        public String FirstNames { get; set; }
        [Required]
        [MaxLength(256)]
        public String LastNames { get; set; }

        public String AddressLineOne { get; set; }

        public String PostCode { get; set; }

        [Phone]
        public String PhoneNumber { get; set; }

        public String StaffEmail;
        public void setStaffEmail()
        {
            this.StaffEmail = StaffId + "@COMPANYNAME.DOMAIN";
        }
        public String getStaffEmail()
        {
           return this.StaffEmail;
        }


    }
}
