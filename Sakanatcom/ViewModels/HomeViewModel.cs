using Sakanatcom.Models;
using System.Collections.Generic;

namespace Sakanatcom.ViewModels
{
    public class HomeViewModel
    {
        public IList<MasterMenu> MasterMenuList { get; set; }
        public IList<MasterSlider> MasterSliderList { get; set; }
        public IList<MasterWorkingHour> MasterWorkingHourList { get; set; }
        public IList<MasterPartner> MasterPartnerList { get; set; }
        public IList<MasterItemMenu> LastFiveMasterItemMenu { get; set; }
        public IList<MasterItemMenu> MasterItemMenuList { get; set; }
        public TransactionBookTable TransactionBookTable { get; set; }
        public TransactionContactUs TransactionContactUs { get; set; }
        public MasterAbout MasterAbout { get; set; }
        public MasterOffer MasterOffer { get; set; }
        public SystemSetting SystemSetting { get; set; }
        public IList<MasterService> MasterServiceList { get; set; }
        public IList<MasterContactUsInformation> ContactUsFooterList { get; set; }
        public IList<MasterContactUsInformation> ContactUsList { get; set; }
        public IList<MasterSocialMedia> MasterSocialMediaList { get; set; }
        public IList<MasterCategoryMenu> MasterCategoryMenuList { get; set; }
    }
}
