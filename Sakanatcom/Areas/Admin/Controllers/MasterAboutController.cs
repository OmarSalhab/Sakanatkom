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

namespace Sakanatcom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterAboutController : Controller
    {
        public IRepository<MasterAbout> MasterAboutRepository { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public MasterAboutController(
            IRepository<MasterAbout> MasterAboutRepository,
            IHostingEnvironment HostingEnvironment)
        {
            this.MasterAboutRepository = MasterAboutRepository;
            this.HostingEnvironment = HostingEnvironment;
        }
        public ActionResult Index()
        {
            IList<MasterAbout> dataList = MasterAboutRepository.View();
            IList<MasterAboutViewModel> dataViewModelList = new List<MasterAboutViewModel>();
            foreach (var data in dataList)
            {
                MasterAboutViewModel dataViewModel = new MasterAboutViewModel()
                {
                    MasterAboutId = data.MasterAboutId,
                    MasterAboutTitle = data.MasterAboutTitle,
                    MasterAboutBrief = data.MasterAboutBrief,
                    MasterAboutDesc = data.MasterAboutDesc,
                    MasterAboutUrl = data.MasterAboutUrl,
                    MasterAboutImageUrl = data.MasterAboutImageUrl,
                    IsActive = data.IsActive,
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }

        public ActionResult Active(int id)
        {
            MasterAboutRepository.Active(id, new MasterAbout()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            MasterAboutViewModel dataViewModel = new MasterAboutViewModel();
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterAboutViewModel dataViewModel)
        {
            try
            {
               
                string imageName = "";
                if (dataViewModel.UploadImage != null)
                {
                    string imagePath = Path.Combine(HostingEnvironment.WebRootPath, "images/about");
                    FileInfo fileInfo = new FileInfo(dataViewModel.UploadImage.FileName);
                    imageName = "MasterAboutImage" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName);
                    dataViewModel.UploadImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                MasterAbout data = new MasterAbout()
                {
                    MasterAboutTitle = dataViewModel.MasterAboutTitle,
                    MasterAboutBrief = dataViewModel.MasterAboutBrief,
                    MasterAboutDesc = dataViewModel.MasterAboutDesc,
                    MasterAboutUrl = dataViewModel.MasterAboutUrl,
                    MasterAboutImageUrl = (string.IsNullOrEmpty(imageName) ? null : imageName),
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterAboutRepository.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            MasterAbout data = MasterAboutRepository.Find(id);
            MasterAboutViewModel dataViewModel = new MasterAboutViewModel()
            {
                MasterAboutId = data.MasterAboutId,
                MasterAboutTitle = data.MasterAboutTitle,
                MasterAboutBrief = data.MasterAboutBrief,
                MasterAboutDesc = data.MasterAboutDesc,
                MasterAboutImageUrl = data.MasterAboutImageUrl,
                MasterAboutUrl = data.MasterAboutUrl,
            };
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterAboutViewModel dataViewModel)
        {
            try
            {

                MasterAbout data = MasterAboutRepository.Find(id);
                string imageName = dataViewModel.MasterAboutImageUrl;
                if (dataViewModel.UploadImage != null)
                {
                    string imagePath = Path.Combine(HostingEnvironment.WebRootPath, "images/about");
                    FileInfo fileInfo = new FileInfo(dataViewModel.UploadImage.FileName);
                    imageName = "MasterAboutLogo" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName);
                    dataViewModel.UploadImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                data.MasterAboutTitle = dataViewModel.MasterAboutTitle;
                data.MasterAboutBrief = dataViewModel.MasterAboutBrief;
                data.MasterAboutDesc = dataViewModel.MasterAboutDesc;
                data.MasterAboutUrl = dataViewModel.MasterAboutUrl;
                data.MasterAboutImageUrl = (string.IsNullOrEmpty(imageName) ? null : imageName);
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.EditDate = DateTime.UtcNow;
                MasterAboutRepository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            MasterAboutRepository.Delete(id, new MasterAbout()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
