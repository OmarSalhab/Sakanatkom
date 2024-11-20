using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sakanatcom.ViewModels
{
    public class MasterCategoryMenuViewModel : BaseEntity
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
