using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sakanatcom.ViewModels
{
    public class TransactionContactUsViewModel : BaseEntity
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
