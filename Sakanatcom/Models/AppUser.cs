using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sakanatcom.Models
{
    public class AppUser : IdentityUser
    {
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string CreateUser { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm}")]
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; }
        public string EditUser { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm}")]
        [DataType(DataType.DateTime)]
        public DateTime? EditDate { get; set; }
    }
}
