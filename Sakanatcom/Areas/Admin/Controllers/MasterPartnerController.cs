using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sakanatcom.Models;
using Sakanatcom.Models.Repositories;
using Sakanatcom.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace Sakanatcom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterPartnerController : Controller
    {
        public IRepository<MasterPartner> MasterPartnerRepository { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public MasterPartnerController(
            IRepository<MasterPartner> MasterPartnerRepository,
            IHostingEnvironment HostingEnvironment)
        {
            this.MasterPartnerRepository = MasterPartnerRepository;
            this.HostingEnvironment = HostingEnvironment;
        }
        public ActionResult Index()
        {
            IList<MasterPartner> dataList = MasterPartnerRepository.View();
            IList<MasterPartnerViewModel> dataViewModelList = new List<MasterPartnerViewModel>();
            foreach (var data in dataList)
            {
                MasterPartnerViewModel dataViewModel = new MasterPartnerViewModel()
                {
                    MasterPartnerId = data.MasterPartnerId,
                    MasterPartnerName = data.MasterPartnerName,
                    MasterPartnerLogoImageUrl = data.MasterPartnerLogoImageUrl,
                    MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl,
                    IsActive = data.IsActive,
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }

        public ActionResult Active(int id)
        {
            MasterPartnerRepository.Active(id, new MasterPartner()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            MasterPartnerViewModel dataViewModel = new MasterPartnerViewModel();
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterPartnerViewModel dataViewModel)
        {
            try
            {
                if (MasterPartnerRepository.View().Where(data => data.MasterPartnerName.ToUpper()
                == dataViewModel.MasterPartnerName.ToUpper()).ToList().Count > 0)
                {
                    ModelState.AddModelError("", "This name is already used.");
                    return View(dataViewModel);
                }
                string imageName = "";
                if (dataViewModel.UploadLogo != null)
                {
                    string imagePath = Path.Combine(HostingEnvironment.WebRootPath, "images/partner");
                    FileInfo fileInfo = new FileInfo(dataViewModel.UploadLogo.FileName);
                    imageName = "masterPartnerLogo" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName);
                    dataViewModel.UploadLogo.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                MasterPartner data = new MasterPartner()
                {
                    MasterPartnerName = dataViewModel.MasterPartnerName,
                    MasterPartnerWebsiteUrl = dataViewModel.MasterPartnerWebsiteUrl,
                    MasterPartnerLogoImageUrl = (string.IsNullOrEmpty(imageName) ? null : imageName),
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterPartnerRepository.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            MasterPartner data = MasterPartnerRepository.Find(id);
            MasterPartnerViewModel dataViewModel = new MasterPartnerViewModel()
            {
                MasterPartnerId = data.MasterPartnerId,
                MasterPartnerName = data.MasterPartnerName,
                MasterPartnerLogoImageUrl = data.MasterPartnerLogoImageUrl,
                MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl
            };
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterPartnerViewModel dataViewModel)
        {
            try
            {

                MasterPartner data = MasterPartnerRepository.Find(id);
                if (MasterPartnerRepository.View().Where(data => data.MasterPartnerName.ToUpper()
                == dataViewModel.MasterPartnerName.ToUpper()).ToList().Count > 0
                && data.MasterPartnerName.ToUpper() != dataViewModel.MasterPartnerName.ToUpper())
                {
                    ModelState.AddModelError("", "This name is already used.");
                    return View(dataViewModel);
                }
                string imageName = dataViewModel.MasterPartnerLogoImageUrl;
                if (dataViewModel.UploadLogo != null)
                {
                    string imagePath = Path.Combine(HostingEnvironment.WebRootPath, "images/partner");
                    FileInfo fileInfo = new FileInfo(dataViewModel.UploadLogo.FileName);
                    imageName = "masterPartnerLogo" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName);
                    dataViewModel.UploadLogo.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                data.MasterPartnerName = dataViewModel.MasterPartnerName;
                data.MasterPartnerWebsiteUrl = dataViewModel.MasterPartnerWebsiteUrl;
                data.MasterPartnerLogoImageUrl = (string.IsNullOrEmpty(imageName) ? null : imageName);
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.EditDate = DateTime.UtcNow;
                MasterPartnerRepository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            MasterPartnerRepository.Delete(id, new MasterPartner()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
