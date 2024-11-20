using Sakanatcom.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Sakanatcom.ViewModels
{
    public class MasterItemMenuViewModel : BaseEntity
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
        [DisplayName("Propirty Facilities")]
        public string MasterItemMenuBreif { get; set; }

        [Required(ErrorMessage = "Description Is Required")]
        [DisplayName("Propirty Description")]
        public string MasterItemMenuDesc { get; set; }

        [Required(ErrorMessage = "Price Is Required")]
        [DisplayName("Price/Month")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MasterItemMenuPrice { get; set; }

        [Required(ErrorMessage = "Image Is Required")]
        [DisplayName("Main Image")]
        public string MasterItemMenuImageUrl { get; set; }

        [Required(ErrorMessage = "Image Is Required")]
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
        [DisplayName("The Capacity")]
        [Range(1, 5)]
        public int MasterItemMenuCapicity { get; set; }


        [DisplayName("Upload Main Image")]
        public IFormFile UploadImage { get; set; }

        [DisplayName("Upload Image 2")]
        public IFormFile UploadImage2 { get; set; } // Add this property

        [DisplayName("Upload Image 3")]
        public IFormFile UploadImage3 { get; set; } // Add this property

        [DisplayName("Upload Image 4")]
        public IFormFile UploadImage4 { get; set; } // Add this property

        public virtual MasterCategoryMenu MasterCategoryMenu { get; set; }
    }
}
