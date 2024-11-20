using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sakanatcom.Models
{
    public partial class MasterSlider : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterSliderId { get; set; }
        [Required(ErrorMessage = "Title Is Required")]
        [DisplayName("Title")]
        public string MasterSliderTitle { get; set; }
        [Required(ErrorMessage = "Breif Is Required")]
        [DisplayName("Breif")]
        public string MasterSliderBreif { get; set; }
        [Required(ErrorMessage = "Description Is Required")]
        [DisplayName("Description")]
        public string MasterSliderDesc { get; set; }
        [Required(ErrorMessage = "Url Is Required")]
        [DisplayName("Url")]
        public string MasterSliderUrl { get; set; }
        [DisplayName("Image")]
        public string MasterSliderImageUrl { get; set; }
    }
}
