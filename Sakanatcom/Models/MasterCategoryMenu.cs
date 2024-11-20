using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

#nullable disable

namespace Sakanatcom.Models
{
    public partial class MasterCategoryMenu : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterCategoryMenuId { get; set; }
        [MaxLength(250)]
        [MinLength(2)]
        [Required(ErrorMessage = "Name Is Required")]
        [DisplayName("City")]
        public string MasterCategoryMenuName { get; set; }
    }
}
