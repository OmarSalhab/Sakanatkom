using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sakanatcom.Models.Repositories;
using Sakanatcom.Models;
using Sakanatcom.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace Sakanatcom.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {

        public IRepository<MasterMenu> MasterMenuRepository { get; }
        public IRepository<MasterSlider> MasterSliderRepository { get; }
        public IRepository<MasterWorkingHour> MasterWorkingHourRepository { get; }
        public IRepository<MasterPartner> MasterPartnerRepository { get; }
        public IRepository<MasterItemMenu> MasterItemMenuRepository { get; }
        public IRepository<TransactionNewsletter> TransactionNewsletterRepository { get; }
        public IRepository<TransactionBookTable> TransactionBookTableRepository { get; }
        public IRepository<TransactionContactUs> TransactionContactUsRepository { get; }
        public IRepository<MasterAbout> MasterAboutRepository { get; }
        public IRepository<MasterOffer> MasterOfferRepository { get; }
        public IRepository<SystemSetting> SystemSettingRepository { get; }
        public IRepository<MasterService> MasterServiceRepository { get; }
        public IRepository<MasterContactUsInformation> MasterContactUsInformationRepository { get; }
        public IRepository<MasterSocialMedia> MasterSocialMediaRepository { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenuRepository { get; }

        public HomeController(
            IRepository<MasterMenu> MasterMenuRepository,
            IRepository<MasterSlider> MasterSliderRepository,
            IRepository<MasterWorkingHour> MasterWorkingHourRepository,
            IRepository<MasterPartner> MasterPartnerRepository,
            IRepository<MasterItemMenu> MasterItemMenuRepository,
            IRepository<TransactionNewsletter> TransactionNewsletterRepository,
            IRepository<TransactionBookTable> TransactionBookTableRepository,
            IRepository<TransactionContactUs> TransactionContactUsRepository,
            IRepository<MasterAbout> MasterAboutRepository,
            IRepository<MasterOffer> MasterOfferRepository,
            IRepository<SystemSetting> SystemSettingRepository,
            IRepository<MasterService> MasterServiceRepository,
            IRepository<MasterContactUsInformation> MasterContactUsInformationRepository,
            IRepository<MasterSocialMedia> MasterSocialMediaRepository,
            IRepository<MasterCategoryMenu> MasterCategoryMenuRepository

            )
        {
            this.MasterMenuRepository = MasterMenuRepository;
            this.MasterSliderRepository = MasterSliderRepository;
            this.MasterWorkingHourRepository = MasterWorkingHourRepository;
            this.MasterPartnerRepository = MasterPartnerRepository;
            this.MasterItemMenuRepository = MasterItemMenuRepository;
            this.TransactionNewsletterRepository = TransactionNewsletterRepository;
            this.TransactionBookTableRepository = TransactionBookTableRepository;
            this.TransactionContactUsRepository = TransactionContactUsRepository;
            this.MasterAboutRepository = MasterAboutRepository;
            this.MasterOfferRepository = MasterOfferRepository;
            this.SystemSettingRepository = SystemSettingRepository;
            this.MasterServiceRepository = MasterServiceRepository;
            this.MasterContactUsInformationRepository = MasterContactUsInformationRepository;
            this.MasterSocialMediaRepository = MasterSocialMediaRepository;
            this.MasterCategoryMenuRepository = MasterCategoryMenuRepository;
        }

        public IActionResult Index(string Message)
        {
            ViewBag.message = Message;
            HomeViewModel dataViewModel = new HomeViewModel()
            {
                SystemSetting = (SystemSettingRepository.ViewForClient().ToList().Count == 0 ? null : SystemSettingRepository.ViewForClient().Take(1).OrderByDescending(data => data.SystemSettingId).ToList().ElementAt(0)),
                MasterMenuList = MasterMenuRepository.ViewForClient(),
                MasterSliderList = MasterSliderRepository.ViewForClient(),
                MasterAbout = (MasterAboutRepository.ViewForClient().ToList().Count == 0 ? null : MasterAboutRepository.ViewForClient().Take(1).OrderByDescending(data => data.MasterAboutId).ToList().ElementAt(0)),
                LastFiveMasterItemMenu = MasterItemMenuRepository
                .ViewForClient()
                .OrderByDescending(data => data.MasterCategoryMenuId)
                .Take(3).ToList(),
                MasterOffer = (MasterOfferRepository.ViewForClient().ToList().Count == 0 ? null : MasterOfferRepository.ViewForClient().Take(1).OrderByDescending(data => data.MasterOfferId).ToList().ElementAt(0)),
                MasterPartnerList = MasterPartnerRepository.ViewForClient(),
                MasterSocialMediaList = MasterSocialMediaRepository.ViewForClient(),
                ContactUsFooterList = MasterContactUsInformationRepository.ViewForClient().Where(data => data.MasterContactUsInformationRedirect.ToUpper() == "FOOTER").ToList(),
                MasterWorkingHourList = MasterWorkingHourRepository.ViewForClient(),
            };
            return View(dataViewModel);
        }

        [HttpPost]
        public IActionResult Subscribe(string TransactionNewsletterEmail, string ViewName)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.message = "Failed";
                return RedirectToAction("Index", "Home", new { Message = ViewBag.message });
            }
            ViewBag.message = "Thank You For Subscribe Our Sakanatcom";
            TransactionNewsletter transactionNewsletter = new TransactionNewsletter()
            {
                TransactionNewsletterEmail = TransactionNewsletterEmail
            };
            TransactionNewsletterRepository.Add(transactionNewsletter);
            return RedirectToAction(ViewName, "Home", new { Message = ViewBag.message });
        }

        [HttpPost]
        public IActionResult BookTable(HomeViewModel data)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.message = "Failed";
                return RedirectToAction("Index", "Home", new { Message = ViewBag.message });
            }
            ViewBag.message = "Thank You For Book At Our Sakanatcom";
            TransactionBookTableRepository.Add(data.TransactionBookTable);
            return RedirectToAction("Index", "Home", new { Message = ViewBag.message });
        }

        public IActionResult About(string Message)
        {
            ViewBag.message = Message;
            HomeViewModel dataViewModel = new HomeViewModel()
            {
                SystemSetting = (SystemSettingRepository.ViewForClient().ToList().Count == 0 ? null : SystemSettingRepository.ViewForClient().Take(1).OrderByDescending(data => data.SystemSettingId).ToList().ElementAt(0)),
                MasterMenuList = MasterMenuRepository.ViewForClient(),
                MasterAbout = (MasterAboutRepository.ViewForClient().ToList().Count == 0 ? null : MasterAboutRepository.ViewForClient().Take(1).OrderByDescending(data => data.MasterAboutId).ToList().ElementAt(0)),
                MasterServiceList = MasterServiceRepository.ViewForClient(),
                MasterSocialMediaList = MasterSocialMediaRepository.ViewForClient(),
                ContactUsFooterList = MasterContactUsInformationRepository.ViewForClient().Where(data => data.MasterContactUsInformationRedirect.ToUpper() == "FOOTER").ToList(),
                MasterWorkingHourList = MasterWorkingHourRepository.ViewForClient(),
            };
            return View(dataViewModel);
        }

        public IActionResult ContactUs(string Message)
        {
            ViewBag.message = Message;
            HomeViewModel dataViewModel = new HomeViewModel()
            {
                SystemSetting = (SystemSettingRepository.ViewForClient().ToList().Count == 0 ? null : SystemSettingRepository.ViewForClient().Take(1).OrderByDescending(data => data.SystemSettingId).ToList().ElementAt(0)),
                MasterMenuList = MasterMenuRepository.ViewForClient(),
                ContactUsList = MasterContactUsInformationRepository.ViewForClient().Where(data => data.MasterContactUsInformationRedirect.ToUpper() != "FOOTER").ToList(),
                MasterAbout = (MasterAboutRepository.ViewForClient().ToList().Count == 0 ? null : MasterAboutRepository.ViewForClient().Take(1).OrderByDescending(data => data.MasterAboutId).ToList().ElementAt(0)),
                MasterSocialMediaList = MasterSocialMediaRepository.ViewForClient(),
                ContactUsFooterList = MasterContactUsInformationRepository.ViewForClient().Where(data => data.MasterContactUsInformationRedirect.ToUpper() == "FOOTER").ToList(),
                MasterWorkingHourList = MasterWorkingHourRepository.ViewForClient(),
            };
            return View(dataViewModel);
        }

        [HttpPost]
        public IActionResult Message(HomeViewModel data)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.message = "Failed";
                return RedirectToAction("ContactUs", "Home", new { Message = ViewBag.message });
            }
            ViewBag.message = "Your Massage Is Send Successfully";
            TransactionContactUsRepository.Add(data.TransactionContactUs);
            return RedirectToAction("ContactUs", "Home", new { Message = ViewBag.message });
        }

        public IActionResult Menu(string Message)
        {
            ViewBag.message = Message;
            HomeViewModel dataViewModel = new HomeViewModel()
            {
                SystemSetting = (SystemSettingRepository.ViewForClient().ToList().Count == 0 ? null : SystemSettingRepository.ViewForClient().Take(1).OrderByDescending(data => data.SystemSettingId).ToList().ElementAt(0)),
                MasterMenuList = MasterMenuRepository.ViewForClient(),
                MasterCategoryMenuList = MasterCategoryMenuRepository.ViewForClient(),
                MasterItemMenuList = MasterItemMenuRepository.ViewForClient(),
                MasterPartnerList = MasterPartnerRepository.ViewForClient(),
                MasterAbout = (MasterAboutRepository.ViewForClient().ToList().Count == 0 ? null : MasterAboutRepository.ViewForClient().Take(1).OrderByDescending(data => data.MasterAboutId).ToList().ElementAt(0)),
                MasterSocialMediaList = MasterSocialMediaRepository.ViewForClient(),
                ContactUsFooterList = MasterContactUsInformationRepository.ViewForClient().Where(data => data.MasterContactUsInformationRedirect.ToUpper() == "FOOTER").ToList(),
                MasterWorkingHourList = MasterWorkingHourRepository.ViewForClient(),
            };
            return View(dataViewModel);
        }
    }
}