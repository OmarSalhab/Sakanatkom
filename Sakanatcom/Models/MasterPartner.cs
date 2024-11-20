using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sakanatcom.Models
{
    public partial class MasterPartner : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterPartnerId { get; set; }
        [Required(ErrorMessage = "Your Name Name Is Required")]
        [DisplayName("Name")]
        public string MasterPartnerName { get; set; }
        [DisplayName("Profile picture")]
        public string MasterPartnerLogoImageUrl { get; set; }
        [Required(ErrorMessage = "Discription Required")]
        [DisplayName("Discription")]
        public string MasterPartnerWebsiteUrl { get; set; }
    }
}
