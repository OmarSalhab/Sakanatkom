using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sakanatcom.Models.Repositories;
using Sakanatcom.Models;
using Sakanatcom.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace Sakanatcom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> SystemSettingRepository { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public SystemSettingController(
            IRepository<SystemSetting> SystemSettingRepository,
            IHostingEnvironment HostingEnvironment)
        {
            this.SystemSettingRepository = SystemSettingRepository;
            this.HostingEnvironment = HostingEnvironment;
        }
        public ActionResult Index()
        {
            IList<SystemSetting> dataList = SystemSettingRepository.View();
            IList<SystemSettingViewModel> dataViewModelList = new List<SystemSettingViewModel>();
            foreach (var data in dataList)
            {
                SystemSettingViewModel dataViewModel = new SystemSettingViewModel()
                {
                    SystemSettingId = data.SystemSettingId,
                    SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl,
                    SystemSettingLogoImageUrl2 = data.SystemSettingLogoImageUrl2,
                    SystemSettingCopyright = data.SystemSettingCopyright,
                    SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreif = data.SystemSettingWelcomeNoteBreif,
                    SystemSettingWelcomeNoteDesc = data.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteUrl = data.SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl,
                    SystemSettingWelcomeNoteImageUrl2 = data.SystemSettingWelcomeNoteImageUrl2,
                    SystemSettingWelcomeNoteImageUrl3 = data.SystemSettingWelcomeNoteImageUrl3,
                    SystemSettingWelcomeNoteImageUrl4 = data.SystemSettingWelcomeNoteImageUrl4,
                    SystemSettingMapLocation = data.SystemSettingMapLocation,
                    IsActive = data.IsActive,
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }

        public ActionResult Active(int id)
        {
            SystemSettingRepository.Active(id, new SystemSetting()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Create()
        {
            SystemSettingViewModel dataViewModel = new SystemSettingViewModel();
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemSettingViewModel dataViewModel)
        {
            try
            {
                string imageName = "", imageName2 = "", imageName3 = "", imageName4 = "", imageName5 = "", imageName6 = "";
                string imagePath = Path.Combine(HostingEnvironment.WebRootPath, "images/systemsetting");
                FileInfo fileInfo;
                if (dataViewModel.UploadLogo != null)
                {
                    fileInfo = new FileInfo(dataViewModel.UploadLogo.FileName);
                    imageName = "systemSettingLogo" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName);
                    dataViewModel.UploadLogo.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (dataViewModel.UploadLogo2 != null)
                {
                    fileInfo = new FileInfo(dataViewModel.UploadLogo2.FileName);
                    imageName2 = "systemSetting2Logo" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName2);
                    dataViewModel.UploadLogo2.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (dataViewModel.UploadImage != null)
                {
                    fileInfo = new FileInfo(dataViewModel.UploadImage.FileName);
                    imageName3 = "systemSettingImage" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName3);
                    dataViewModel.UploadImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (dataViewModel.UploadImage2 != null)
                {
                    fileInfo = new FileInfo(dataViewModel.UploadImage2.FileName);
                    imageName4 = "systemSetting2Image" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName4);
                    dataViewModel.UploadImage2.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (dataViewModel.UploadImage3 != null)
                {
                    fileInfo = new FileInfo(dataViewModel.UploadImage3.FileName);
                    imageName5 = "systemSetting3Image" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName5);
                    dataViewModel.UploadImage3.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (dataViewModel.UploadImage4 != null)
                {
                    fileInfo = new FileInfo(dataViewModel.UploadImage4.FileName);
                    imageName6 = "systemSetting4Image" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName6);
                    dataViewModel.UploadImage4.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                SystemSetting data = new SystemSetting()
                {
                    SystemSettingLogoImageUrl = (string.IsNullOrEmpty(imageName) ? null : imageName),
                    SystemSettingLogoImageUrl2 = (string.IsNullOrEmpty(imageName2) ? null : imageName2),
                    SystemSettingCopyright = dataViewModel.SystemSettingCopyright,
                    SystemSettingWelcomeNoteTitle = dataViewModel.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreif = dataViewModel.SystemSettingWelcomeNoteBreif,
                    SystemSettingWelcomeNoteDesc = dataViewModel.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteUrl = dataViewModel.SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteImageUrl = (string.IsNullOrEmpty(imageName3) ? null : imageName3),
                    SystemSettingWelcomeNoteImageUrl2 = (string.IsNullOrEmpty(imageName4) ? null : imageName4),
                    SystemSettingWelcomeNoteImageUrl3 = (string.IsNullOrEmpty(imageName5) ? null : imageName5),
                    SystemSettingWelcomeNoteImageUrl4 = (string.IsNullOrEmpty(imageName6) ? null : imageName6),
                    SystemSettingMapLocation = dataViewModel.SystemSettingMapLocation,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                SystemSettingRepository.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            SystemSetting data = SystemSettingRepository.Find(id);
            SystemSettingViewModel dataViewModel = new SystemSettingViewModel()
            {
                SystemSettingId = data.SystemSettingId,
                SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl,
                SystemSettingLogoImageUrl2 = data.SystemSettingLogoImageUrl2,
                SystemSettingCopyright = data.SystemSettingCopyright,
                SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteBreif = data.SystemSettingWelcomeNoteBreif,
                SystemSettingWelcomeNoteDesc = data.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteUrl = data.SystemSettingWelcomeNoteUrl,
                SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl,
                SystemSettingWelcomeNoteImageUrl2 = data.SystemSettingWelcomeNoteImageUrl2,
                SystemSettingWelcomeNoteImageUrl3 = data.SystemSettingWelcomeNoteImageUrl3,
                SystemSettingWelcomeNoteImageUrl4 = data.SystemSettingWelcomeNoteImageUrl4,
                SystemSettingMapLocation = data.SystemSettingMapLocation,
            };
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemSettingViewModel dataViewModel)
        {
            try
            {
                string imageName = dataViewModel.SystemSettingLogoImageUrl,
                    imageName2 = dataViewModel.SystemSettingLogoImageUrl2,
                    imageName3 = dataViewModel.SystemSettingWelcomeNoteImageUrl,
                    imageName4 = dataViewModel.SystemSettingWelcomeNoteImageUrl2,
                    imageName5 = dataViewModel.SystemSettingWelcomeNoteImageUrl3,
                    imageName6 = dataViewModel.SystemSettingWelcomeNoteImageUrl4;
                string imagePath = Path.Combine(HostingEnvironment.WebRootPath, "images/systemsetting");
                FileInfo fileInfo;
                if (dataViewModel.UploadLogo != null)
                {
                    fileInfo = new FileInfo(dataViewModel.UploadLogo.FileName);
                    imageName = "systemSettingLogo" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName);
                    dataViewModel.UploadLogo.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (dataViewModel.UploadLogo2 != null)
                {
                    fileInfo = new FileInfo(dataViewModel.UploadLogo2.FileName);
                    imageName2 = "systemSetting2Logo" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName2);
                    dataViewModel.UploadLogo2.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (dataViewModel.UploadImage != null)
                {
                    fileInfo = new FileInfo(dataViewModel.UploadImage.FileName);
                    imageName3 = "systemSettingImage" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName3);
                    dataViewModel.UploadImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (dataViewModel.UploadImage2 != null)
                {
                    fileInfo = new FileInfo(dataViewModel.UploadImage2.FileName);
                    imageName4 = "systemSetting2Image" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName4);
                    dataViewModel.UploadImage2.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (dataViewModel.UploadImage3 != null)
                {
                    fileInfo = new FileInfo(dataViewModel.UploadImage3.FileName);
                    imageName5 = "systemSetting3Image" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName5);
                    dataViewModel.UploadImage3.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (dataViewModel.UploadImage4 != null)
                {
                    fileInfo = new FileInfo(dataViewModel.UploadImage4.FileName);
                    imageName6 = "systemSetting4Image" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName6);
                    dataViewModel.UploadImage4.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                SystemSetting data = SystemSettingRepository.Find(id);
                data.SystemSettingLogoImageUrl = (string.IsNullOrEmpty(imageName) ? null : imageName);
                data.SystemSettingLogoImageUrl2 = (string.IsNullOrEmpty(imageName2) ? null : imageName2);
                data.SystemSettingCopyright = dataViewModel.SystemSettingCopyright;
                data.SystemSettingWelcomeNoteTitle = dataViewModel.SystemSettingWelcomeNoteTitle;
                data.SystemSettingWelcomeNoteBreif = dataViewModel.SystemSettingWelcomeNoteBreif;
                data.SystemSettingWelcomeNoteDesc = dataViewModel.SystemSettingWelcomeNoteDesc;
                data.SystemSettingWelcomeNoteUrl = dataViewModel.SystemSettingWelcomeNoteUrl;
                data.SystemSettingWelcomeNoteImageUrl = (string.IsNullOrEmpty(imageName3) ? null : imageName3);
                data.SystemSettingWelcomeNoteImageUrl2 = (string.IsNullOrEmpty(imageName4) ? null : imageName4);
                data.SystemSettingWelcomeNoteImageUrl3 = (string.IsNullOrEmpty(imageName5) ? null : imageName5);
                data.SystemSettingWelcomeNoteImageUrl4 = (string.IsNullOrEmpty(imageName6) ? null : imageName6);
                data.SystemSettingMapLocation = dataViewModel.SystemSettingMapLocation;
                data.EditDate = DateTime.UtcNow;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                SystemSettingRepository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            SystemSettingRepository.Delete(id, new SystemSetting()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
