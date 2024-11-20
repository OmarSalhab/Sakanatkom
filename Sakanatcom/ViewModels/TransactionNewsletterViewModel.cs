using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sakanatcom.ViewModels
{
    public class TransactionNewsletterViewModel : BaseEntity
    {
        [DisplayName("Id")]
        public int TransactionNewsletterId { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string TransactionNewsletterEmail { get; set; }
    }
}
