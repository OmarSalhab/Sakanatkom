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
    public class MasterItemMenuController : Controller
    {
        public IRepository<MasterItemMenu> MasterItemMenuRepository { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenuRepository { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public MasterItemMenuController(
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

        public ActionResult Create()
        {
            MasterCategoryMenu newData = new MasterCategoryMenu()
            {
                MasterCategoryMenuId = 0,
                MasterCategoryMenuName = "-- Select List --"
            };
            IList<MasterCategoryMenu> dataList = MasterCategoryMenuRepository.View();
            IList<MasterCategoryMenu> newDataList = new List<MasterCategoryMenu>();
            newDataList.Add(newData);
            foreach (var item in dataList)
            {
                newDataList.Add(item);
            }
            ViewBag.MasterCategoryMenuList = newDataList;
            MasterItemMenuViewModel dataViewModel = new MasterItemMenuViewModel();
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterItemMenuViewModel dataViewModel)
        {
            try
            {
                string imageName = "";
                if (dataViewModel.UploadImage != null)
                {
                    string imagePath = Path.Combine(HostingEnvironment.WebRootPath, "images/item");
                    FileInfo fileInfo = new FileInfo(dataViewModel.UploadImage.FileName);
                    imageName = "masterItemMenuImage" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName);
                    dataViewModel.UploadImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                string imageName2 = "";
                if (dataViewModel.UploadImage2 != null)
                {
                    string imagePath2 = Path.Combine(HostingEnvironment.WebRootPath, "images/item");
                    FileInfo fileInfo2 = new FileInfo(dataViewModel.UploadImage2.FileName);
                    imageName2 = "masterItemMenuImage2" + Guid.NewGuid() + fileInfo2.Extension;
                    string fullPath2 = Path.Combine(imagePath2, imageName2);
                    dataViewModel.UploadImage2.CopyTo(new FileStream(fullPath2, FileMode.Create));
                }
                string imageName3 = "";
                if (dataViewModel.UploadImage3 != null)
                {
                    string imagePath3 = Path.Combine(HostingEnvironment.WebRootPath, "images/item");
                    FileInfo fileInfo3 = new FileInfo(dataViewModel.UploadImage3.FileName);
                    imageName3 = "masterItemMenuImage3" + Guid.NewGuid() + fileInfo3.Extension;
                    string fullPath3 = Path.Combine(imagePath3, imageName3);
                    dataViewModel.UploadImage3.CopyTo(new FileStream(fullPath3, FileMode.Create));
                }
                string imageName4 = "";
                if (dataViewModel.UploadImage4 != null)
                {
                    string imagePath4 = Path.Combine(HostingEnvironment.WebRootPath, "images/item");
                    FileInfo fileInfo4 = new FileInfo(dataViewModel.UploadImage4.FileName);
                    imageName4 = "masterItemMenuImage4" + Guid.NewGuid() + fileInfo4.Extension;
                    string fullPath4 = Path.Combine(imagePath4, imageName4);
                    dataViewModel.UploadImage4.CopyTo(new FileStream(fullPath4, FileMode.Create));
                }

                MasterItemMenu data = new MasterItemMenu()
                {
                    MasterCategoryMenuId = (dataViewModel.MasterCategoryMenuId == 0 ? null : dataViewModel.MasterCategoryMenuId),
                    MasterItemMenuTitle = dataViewModel.MasterItemMenuTitle,
                    MasterItemMenuBreif = dataViewModel.MasterItemMenuBreif,
                    MasterItemMenuDesc = dataViewModel.MasterItemMenuDesc,
                    MasterItemMenuPrice = dataViewModel.MasterItemMenuPrice,
                    MasterItemMenuImageUrl = (string.IsNullOrEmpty(imageName) ? null : imageName),
                    MasterItemMenuDate = dataViewModel.MasterItemMenuDate,
                    IsActive = true,
                    IsDelete = false,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),

                    // New Fields
                    MasterItemMenuPhone = dataViewModel.MasterItemMenuPhone,
                    MasterItemMenuEmail = dataViewModel.MasterItemMenuEmail,
                    MasterItemMenuName = dataViewModel.MasterItemMenuName,
                    MasterItemMenuAddress = dataViewModel.MasterItemMenuAddress,
                    MasterItemMenuCapicity = dataViewModel.MasterItemMenuCapicity,
                    MasterItemMenuImageUrl2 = (string.IsNullOrEmpty(imageName2) ? null : imageName2),
                    MasterItemMenuImageUrl3 = (string.IsNullOrEmpty(imageName3) ? null : imageName3),
                    MasterItemMenuImageUrl4 = (string.IsNullOrEmpty(imageName4) ? null : imageName4)
                };
                MasterItemMenuRepository.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            MasterCategoryMenu newData = new MasterCategoryMenu()
            {
                MasterCategoryMenuId = 0,
                MasterCategoryMenuName = "-- Select List --"
            };
            IList<MasterCategoryMenu> dataList = MasterCategoryMenuRepository.View();
            IList<MasterCategoryMenu> newDataList = new List<MasterCategoryMenu>();
            newDataList.Add(newData);
            foreach (var item in dataList)
            {
                newDataList.Add(item);
            }
            ViewBag.MasterCategoryMenuList = newDataList;
            MasterItemMenu data = MasterItemMenuRepository.Find(id);
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
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterItemMenuViewModel dataViewModel)
        {
            try
            {
                string imageName = dataViewModel.MasterItemMenuImageUrl;
                if (dataViewModel.UploadImage != null)
                {
                    string imagePath = Path.Combine(HostingEnvironment.WebRootPath, "images/item");
                    FileInfo fileInfo = new FileInfo(dataViewModel.UploadImage.FileName);
                    imageName = "masterItemMenuImage" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName);
                    dataViewModel.UploadImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                string imageName2 = dataViewModel.MasterItemMenuImageUrl2;
                if (dataViewModel.UploadImage2 != null)
                {
                    string imagePath2 = Path.Combine(HostingEnvironment.WebRootPath, "images/item");
                    FileInfo fileInfo2 = new FileInfo(dataViewModel.UploadImage2.FileName);
                    imageName2 = "masterItemMenuImage2" + Guid.NewGuid() + fileInfo2.Extension;
                    string fullPath2 = Path.Combine(imagePath2, imageName2);
                    dataViewModel.UploadImage2.CopyTo(new FileStream(fullPath2, FileMode.Create));
                }

                string imageName3 = dataViewModel.MasterItemMenuImageUrl3;
                if (dataViewModel.UploadImage3 != null)
                {
                    string imagePath3 = Path.Combine(HostingEnvironment.WebRootPath, "images/item");
                    FileInfo fileInfo3 = new FileInfo(dataViewModel.UploadImage3.FileName);
                    imageName3 = "masterItemMenuImage3" + Guid.NewGuid() + fileInfo3.Extension;
                    string fullPath3 = Path.Combine(imagePath3, imageName3);
                    dataViewModel.UploadImage3.CopyTo(new FileStream(fullPath3, FileMode.Create));
                }

                string imageName4 = dataViewModel.MasterItemMenuImageUrl4;
                if (dataViewModel.UploadImage4 != null)
                {
                    string imagePath4 = Path.Combine(HostingEnvironment.WebRootPath, "images/item");
                    FileInfo fileInfo4 = new FileInfo(dataViewModel.UploadImage4.FileName);
                    imageName4 = "masterItemMenuImage4" + Guid.NewGuid() + fileInfo4.Extension;
                    string fullPath4 = Path.Combine(imagePath4, imageName4);
                    dataViewModel.UploadImage4.CopyTo(new FileStream(fullPath4, FileMode.Create));
                }

                MasterItemMenu data = MasterItemMenuRepository.Find(id);

                data.MasterCategoryMenuId = (dataViewModel.MasterCategoryMenuId == 0 ? null : dataViewModel.MasterCategoryMenuId);
                data.MasterItemMenuTitle = dataViewModel.MasterItemMenuTitle;
                data.MasterItemMenuBreif = dataViewModel.MasterItemMenuBreif;
                data.MasterItemMenuDesc = dataViewModel.MasterItemMenuDesc;
                data.MasterItemMenuPrice = dataViewModel.MasterItemMenuPrice;
                data.MasterItemMenuImageUrl = (string.IsNullOrEmpty(imageName) ? null : imageName);
                data.MasterItemMenuDate = dataViewModel.MasterItemMenuDate;
                data.EditDate = DateTime.UtcNow;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // New Fields
                data.MasterItemMenuPhone = dataViewModel.MasterItemMenuPhone;
                data.MasterItemMenuEmail = dataViewModel.MasterItemMenuEmail;
                data.MasterItemMenuName = dataViewModel.MasterItemMenuName;
                data.MasterItemMenuAddress = dataViewModel.MasterItemMenuAddress;
                data.MasterItemMenuCapicity = dataViewModel.MasterItemMenuCapicity;
                data.MasterItemMenuImageUrl2 = (string.IsNullOrEmpty(imageName2) ? null : imageName2);
                data.MasterItemMenuImageUrl3 = (string.IsNullOrEmpty(imageName3) ? null : imageName3);
                data.MasterItemMenuImageUrl4 = (string.IsNullOrEmpty(imageName4) ? null : imageName4);


                MasterItemMenuRepository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            MasterItemMenuRepository.Delete(id, new MasterItemMenu()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
