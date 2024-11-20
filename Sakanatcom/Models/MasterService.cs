using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sakanatcom.Models
{
    public partial class MasterService : BaseEntity 
    {
        [DisplayName("Id")]
        public int MasterServiceId { get; set; }
        [Required(ErrorMessage = "Title Is Required")]
        [DisplayName("Title")]
        public string MasterServiceTitle { get; set; }
        [Required(ErrorMessage = "Description Is Required")]
        [DisplayName("Description")]
        public string MasterServiceDesc { get; set; }
        [Required(ErrorMessage = "Icon Is Required")]
        [DisplayName("Icon")]
        public string MasterServiceIcon { get; set; }
    }
}
