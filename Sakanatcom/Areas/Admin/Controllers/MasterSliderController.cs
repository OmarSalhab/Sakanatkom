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
using System.Security.Claims;

namespace Sakanatcom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterSliderController : Controller
    {
        public IRepository<MasterSlider> MasterSliderRepository { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public MasterSliderController(
            IRepository<MasterSlider> MasterSliderRepository,
            IHostingEnvironment HostingEnvironment)
        {
            this.MasterSliderRepository = MasterSliderRepository;
            this.HostingEnvironment = HostingEnvironment;
        }
        public ActionResult Index()
        {
            IList<MasterSlider> dataList = MasterSliderRepository.View();
            IList<MasterSliderViewModel> dataViewModelList = new List<MasterSliderViewModel>();
            foreach (var data in dataList)
            {
                MasterSliderViewModel dataViewModel = new MasterSliderViewModel()
                {
                    MasterSliderId = data.MasterSliderId,
                    MasterSliderTitle = data.MasterSliderTitle,
                    MasterSliderBreif = data.MasterSliderBreif,
                    MasterSliderDesc = data.MasterSliderDesc,
                    MasterSliderImageUrl = data.MasterSliderImageUrl,
                    MasterSliderUrl = data.MasterSliderUrl,
                    IsActive = data.IsActive,
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }

        public ActionResult Active(int id)
        {
            MasterSliderRepository.Active(id, new MasterSlider()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            MasterSliderViewModel dataViewModel = new MasterSliderViewModel();
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSliderViewModel dataViewModel)
        {
            try
            {
                string imageName = "";
                if (dataViewModel.UploadImage != null)
                {
                    string imagePath = Path.Combine(HostingEnvironment.WebRootPath, "images/slider");
                    FileInfo fileInfo = new FileInfo(dataViewModel.UploadImage.FileName);
                    imageName = "masterSliderImage" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName);
                    dataViewModel.UploadImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                MasterSlider data = new MasterSlider()
                {
                    MasterSliderTitle = dataViewModel.MasterSliderTitle,
                    MasterSliderBreif = dataViewModel.MasterSliderBreif,
                    MasterSliderDesc = dataViewModel.MasterSliderDesc,
                    MasterSliderUrl = dataViewModel.MasterSliderUrl,
                   
                    MasterSliderImageUrl = (string.IsNullOrEmpty(imageName) ? null : imageName),
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterSliderRepository.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            MasterSlider data = MasterSliderRepository.Find(id);
            MasterSliderViewModel dataViewModel = new MasterSliderViewModel()
            {
                MasterSliderId = data.MasterSliderId,
                MasterSliderTitle = data.MasterSliderTitle,
                MasterSliderDesc = data.MasterSliderDesc,
                MasterSliderBreif = data.MasterSliderBreif,
                MasterSliderImageUrl = data.MasterSliderImageUrl,
                MasterSliderUrl = data.MasterSliderUrl
            };
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSliderViewModel dataViewModel)
        {
            try
            {
                string imageName = dataViewModel.MasterSliderImageUrl;
                if (dataViewModel.UploadImage != null)
                {
                    string imagePath = Path.Combine(HostingEnvironment.WebRootPath, "images/slider");
                    FileInfo fileInfo = new FileInfo(dataViewModel.UploadImage.FileName);
                    imageName = "masterSliderImage" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName);
                    dataViewModel.UploadImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                MasterSlider data = MasterSliderRepository.Find(id);
                data.MasterSliderTitle = dataViewModel.MasterSliderTitle;
                data.MasterSliderDesc = dataViewModel.MasterSliderDesc;
                data.MasterSliderUrl = dataViewModel.MasterSliderUrl;
                data.MasterSliderImageUrl = (string.IsNullOrEmpty(imageName) ? null : imageName);
                data.EditDate = DateTime.UtcNow;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterSliderRepository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            MasterSliderRepository.Delete(id, new MasterSlider()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
