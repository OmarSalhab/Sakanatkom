using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sakanatcom.Models
{
    public partial class TransactionContactUs : BaseEntity
    {
        [DisplayName("Id")]
        public int TransactionContactUsId { get; set; }
        [Required(ErrorMessage = "Full Name Is Required")]
        [DisplayName("Full Name")]
        public string TransactionContactUsFullName { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string TransactionContactUsEmail { get; set; }
        [Required(ErrorMessage = "Subject Is Required")]
        [DisplayName("Subject")]
        public string TransactionContactUsSubject { get; set; }
        [Required(ErrorMessage = "Message Is Required")]
        [DisplayName("Message")]
        public string TransactionContactUsMessage { get; set; }
    }
}
