// [Authorize(Policy = "RequireStudentEmail")]
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sakanatcom.Models;
using Sakanatcom.Models.Repositories;
using Sakanatcom.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;

namespace Sakanatcom.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class PropController : Controller
    {
        public IRepository<MasterItemMenu> MasterItemMenuRepository { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenuRepository { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public PropController(
            IRepository<MasterItemMenu> MasterItemMenuRepository,
            IRepository<MasterCategoryMenu> MasterCategoryMenuRepository,
            IHostingEnvironment HostingEnvironment)
        {
            this.MasterItemMenuRepository = MasterItemMenuRepository;
            this.MasterCategoryMenuRepository = MasterCategoryMenuRepository;
            this.HostingEnvironment = HostingEnvironment;
        }
        public ActionResult Index()
        {

            IList<MasterItemMenu> dataList = MasterItemMenuRepository.View();
            IList<MasterItemMenuViewModel> dataViewModelList = new List<MasterItemMenuViewModel>();
            foreach (var data in dataList)
            {
                MasterItemMenuViewModel dataViewModel = new MasterItemMenuViewModel()
                {
                    MasterItemMenuId = data.MasterItemMenuId,
                    MasterCategoryMenuId = data.MasterCategoryMenuId,
                    MasterItemMenuTitle = data.MasterItemMenuTitle,
                    MasterItemMenuBreif = data.MasterItemMenuBreif,
                    MasterItemMenuDesc = data.MasterItemMenuDesc,
                    MasterItemMenuPrice = data.MasterItemMenuPrice,
                    MasterItemMenuImageUrl = data.MasterItemMenuImageUrl,
                    MasterItemMenuDate = data.MasterItemMenuDate,
                    MasterCategoryMenu = data.MasterCategoryMenu,
                    IsActive = data.IsActive,

                    // New Fields
                    MasterItemMenuPhone = data.MasterItemMenuPhone,
                    MasterItemMenuEmail = data.MasterItemMenuEmail,
                    MasterItemMenuName = data.MasterItemMenuName,
                    MasterItemMenuAddress = data.MasterItemMenuAddress,
                    MasterItemMenuCapicity = data.MasterItemMenuCapicity,
                    MasterItemMenuImageUrl2 = data.MasterItemMenuImageUrl2,
                    MasterItemMenuImageUrl3 = data.MasterItemMenuImageUrl3,
                    MasterItemMenuImageUrl4 = data.MasterItemMenuImageUrl4
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }
        public ActionResult Active(int id)
        {
            MasterItemMenuRepository.Active(id, new MasterItemMenu()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult SendEmail(string recipientEmail, string subject, string message)
        {
            try
            {
               
                var smtpClient = new SmtpClient("smtp-relay.brevo.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("kareemmaher2002@icloud.com", "sKFgQ8B3xRDLG0Ch"),
                    EnableSsl = true,
                };

               
                var fromAddress = new MailAddress("kareemmaher2002@icloud.com", "SacantCom");

               
                var toAddress = new MailAddress(recipientEmail, "Recipient Name");

               
                var emailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true,
                };

                smtpClient.Send(emailMessage);

               
                return Json(new { success = true, message = "Email sent successfully." });
            }
            catch (Exception ex)
            {
                
                return Json(new { success = false, message = $"Error sending email: {ex.Message}" });
            }
        }
    }
}

