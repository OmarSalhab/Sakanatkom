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
    public class MasterSocialMediaController : Controller
    {
        public IRepository<MasterSocialMedia> MasterSocialMediaRepository { get; }

        public MasterSocialMediaController(
            IRepository<MasterSocialMedia> MasterSocialMediaRepository)
        {
            this.MasterSocialMediaRepository = MasterSocialMediaRepository;
        }
        public ActionResult Index()
        {
            IList<MasterSocialMedia> dataList = MasterSocialMediaRepository.View();
            IList<MasterSocialMediaViewModel> dataViewModelList = new List<MasterSocialMediaViewModel>();
            foreach (var data in dataList)
            {
                MasterSocialMediaViewModel dataViewModel = new MasterSocialMediaViewModel()
                {
                    MasterSocialMediaId = data.MasterSocialMediaId,
                    MasterSocialMediaIcon  = data.MasterSocialMediaIcon,
                    MasterSocialMediaUrl = data.MasterSocialMediaUrl,
                    IsActive = data.IsActive,
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }

        public ActionResult Active(int id)
        {
            MasterSocialMediaRepository.Active(id, new MasterSocialMedia()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            MasterSocialMediaViewModel dataViewModel = new MasterSocialMediaViewModel();
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSocialMediaViewModel dataViewModel)
        {
            try
            {
                MasterSocialMedia data = new MasterSocialMedia()
                {
                    MasterSocialMediaUrl = dataViewModel.MasterSocialMediaUrl,
                    MasterSocialMediaIcon = dataViewModel.MasterSocialMediaIcon,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterSocialMediaRepository.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            MasterSocialMedia data = MasterSocialMediaRepository.Find(id);
            MasterSocialMediaViewModel dataViewModel = new MasterSocialMediaViewModel()
            {
                MasterSocialMediaId = data.MasterSocialMediaId,
                MasterSocialMediaIcon = data.MasterSocialMediaIcon,
                MasterSocialMediaUrl = data.MasterSocialMediaUrl
            };
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSocialMediaViewModel dataViewModel)
        {
            try
            {
                MasterSocialMedia data = MasterSocialMediaRepository.Find(id);
                data.MasterSocialMediaUrl = dataViewModel.MasterSocialMediaUrl;
                data.MasterSocialMediaIcon = dataViewModel.MasterSocialMediaIcon;
                data.EditDate = DateTime.UtcNow;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterSocialMediaRepository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            MasterSocialMediaRepository.Delete(id, new MasterSocialMedia()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
