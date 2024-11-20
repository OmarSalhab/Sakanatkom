using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Sakanatcom.Models
{
    public partial class MasterItemMenu : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterItemMenuId { get; set; }

        [Required(ErrorMessage = "City Is Required")]
        [DisplayName("City")]
        public int? MasterCategoryMenuId { get; set; }

        [Required(ErrorMessage = "Title Is Required")]
        [DisplayName("Title (For Search)")]
        public string MasterItemMenuTitle { get; set; }

        [Required(ErrorMessage = "Breif Is Required")]
        [DisplayName("Facilities")]
        public string MasterItemMenuBreif { get; set; }

        [Required(ErrorMessage = "Description Is Required")]
        [DisplayName("Room Description")]
        public string MasterItemMenuDesc { get; set; }

        [Required(ErrorMessage = "Price Is Required")]
        [DisplayName("Price/Month")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MasterItemMenuPrice { get; set; }

        [Required(ErrorMessage = "Image Is Required")]
        [DisplayName("Main Image")]
        public string MasterItemMenuImageUrl { get; set; }

        [DisplayName("Image 2")]
        public string MasterItemMenuImageUrl2 { get; set; } // Add this property

        [DisplayName("Image 3")]
        public string MasterItemMenuImageUrl3 { get; set; } // Add this property

        [DisplayName("Image 4")]
        public string MasterItemMenuImageUrl4 { get; set; } // Add this property

        [Required(ErrorMessage = "Availability Date Is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.DateTime)]
        [DisplayName("Availability Date")]
        public DateTime? MasterItemMenuDate { get; set; }

        [Required(ErrorMessage = "Phone Number Is Required")]
        [DisplayName("Phone Number")]
        public string MasterItemMenuPhone { get; set; }


        [Required(ErrorMessage = "Email Adress Is Required")]
        [DisplayName("Email Address")]
        public string MasterItemMenuEmail { get; set; }


        [Required(ErrorMessage = "Your Name Is Required")]
        [DisplayName("Your Name")]
        public string MasterItemMenuName { get; set; }


        [Required(ErrorMessage = "Propirty Address Is Required")]
        [DisplayName("Propirty Address")]
        public string MasterItemMenuAddress { get; set; }


        [Required(ErrorMessage = "Room Capacity Is Required")]
        [DisplayName("Room Capacity")]
        [Range(1, 5)]
        public int MasterItemMenuCapicity { get; set; }
   

        public virtual MasterCategoryMenu MasterCategoryMenu { get; set; }

    }
}
