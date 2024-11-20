using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sakanatcom.Models
{
    public partial class TransactionNewsletter : BaseEntity
    {
        [DisplayName("Id")]
        public int TransactionNewsletterId { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string TransactionNewsletterEmail { get; set; }
    }
}
