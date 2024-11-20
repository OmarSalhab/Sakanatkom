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
    public class MasterOfferController : Controller
    {
        public IRepository<MasterOffer> MasterOfferRepository { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public MasterOfferController(
            IRepository<MasterOffer> MasterOfferRepository,
            IHostingEnvironment HostingEnvironment)
        {
            this.MasterOfferRepository = MasterOfferRepository;
            this.HostingEnvironment = HostingEnvironment;
        }
        public ActionResult Index()
        {
            IList<MasterOffer> dataList = MasterOfferRepository.View();
            IList<MasterOfferViewModel> dataViewModelList = new List<MasterOfferViewModel>();
            foreach (var data in dataList)
            {
                MasterOfferViewModel dataViewModel = new MasterOfferViewModel()
                {
                    MasterOfferId = data.MasterOfferId,
                    MasterOfferTitle = data.MasterOfferTitle,
                    MasterOfferDesc = data.MasterOfferDesc,
                    MasterOfferBreif = data.MasterOfferBreif,
                    MasterOfferImageUrl = data.MasterOfferImageUrl,
                    IsActive = data.IsActive
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }

        public ActionResult Active(int id)
        {
            MasterOfferRepository.Active(id, new MasterOffer()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            MasterOfferViewModel dataViewModel = new MasterOfferViewModel();
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterOfferViewModel dataViewModel)
        {
            try
            {
                string imageName = "";
                if (dataViewModel.UploadImage != null)
                {
                    string imagePath = Path.Combine(HostingEnvironment.WebRootPath, "images/offer");
                    FileInfo fileInfo = new FileInfo(dataViewModel.UploadImage.FileName);
                    imageName = "masterOfferImage" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName);
                    dataViewModel.UploadImage.CopyTo(new FileStream(fullPath, FileMode.Create));

                }
                MasterOffer data = new MasterOffer()
                {
                    MasterOfferTitle = dataViewModel.MasterOfferTitle,
                    MasterOfferDesc = dataViewModel.MasterOfferDesc,
                    MasterOfferBreif = dataViewModel.MasterOfferBreif,
                    MasterOfferImageUrl = (string.IsNullOrEmpty(imageName) ? null : imageName),
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false,
                };
                MasterOfferRepository.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            MasterOffer data = MasterOfferRepository.Find(id);
            MasterOfferViewModel dataViewModel = new MasterOfferViewModel()
            {
                MasterOfferId = data.MasterOfferId,
                MasterOfferTitle = data.MasterOfferTitle,
                MasterOfferDesc = data.MasterOfferDesc,
                MasterOfferBreif = data.MasterOfferBreif,
                MasterOfferImageUrl = data.MasterOfferImageUrl,
            };
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterOfferViewModel dataViewModel)
        {
            try
            {
                MasterOffer data = MasterOfferRepository.Find(id);
                string imageName = dataViewModel.MasterOfferImageUrl;
                if (dataViewModel.UploadImage != null)
                {
                    string imagePath = Path.Combine(HostingEnvironment.WebRootPath, "images/offer");
                    FileInfo fileInfo = new FileInfo(dataViewModel.UploadImage.FileName);
                    imageName = "masterOfferImage" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName);
                    dataViewModel.UploadImage.CopyTo(new FileStream(fullPath, FileMode.Create));

                }
                data.MasterOfferTitle = dataViewModel.MasterOfferTitle;
                data.MasterOfferDesc = dataViewModel.MasterOfferDesc;
                data.MasterOfferBreif = dataViewModel.MasterOfferBreif;
                data.MasterOfferImageUrl = (string.IsNullOrEmpty(imageName) ? null : imageName);
                data.EditDate = DateTime.UtcNow;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterOfferRepository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            MasterOfferRepository.Delete(id, new MasterOffer()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
