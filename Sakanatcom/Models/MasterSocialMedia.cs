using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sakanatcom.Models
{
    public partial class MasterSocialMedia : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterSocialMediaId { get; set; }
        [Required(ErrorMessage = "Icon Is Required")]
        [DisplayName("Icon")]
        public string MasterSocialMediaIcon { get; set; }
        [Required(ErrorMessage = "Url Is Required")]
        [DisplayName("Url")]
        public string MasterSocialMediaUrl { get; set; }
    }
}
