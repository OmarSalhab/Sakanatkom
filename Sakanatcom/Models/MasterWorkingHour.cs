using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sakanatcom.Models
{
    public partial class MasterWorkingHour : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterWorkingHourId { get; set; }
        [Required(ErrorMessage = "Day Name Is Required")]
        [DisplayName("Day Name")]
        public string MasterWorkingHourName { get; set; }
        [Required(ErrorMessage = "Working Time Is Required")]
        [DisplayName("Working Time")]
        public string MasterWorkingHourTimeFormTo { get; set; }
    }
}
