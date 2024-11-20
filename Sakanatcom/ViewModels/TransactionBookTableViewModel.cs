using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sakanatcom.ViewModels
{
    public class TransactionBookTableViewModel : BaseEntity
    {
        [DisplayName("Id")]
        public int TransactionBookTableId { get; set; }
        [Required(ErrorMessage = "Full Name Is Required")]
        [DisplayName("Full Name")]
        public string TransactionBookTableFullName { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string TransactionBookTableEmail { get; set; }
        [Required(ErrorMessage = "Mobile Number Is Required")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Mobile Number")]
        public string TransactionBookTableMobileNumber { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Book Date Is Required")]
        [DisplayName("Book Date")]
        public DateTime? TransactionBookTableDate { get; set; }
    }
}
