using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace Sakanatcom.ViewModels
{
    public class MasterWorkingHourViewModel : BaseEntity
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
