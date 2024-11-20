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
    public class MasterServiceController : Controller
    {
        public IRepository<MasterService> MasterServiceRepository { get; }

        public MasterServiceController(
            IRepository<MasterService> MasterServiceRepository)
        {
            this.MasterServiceRepository = MasterServiceRepository;
        }
        public ActionResult Index()
        {
            IList<MasterService> dataList = MasterServiceRepository.View();
            IList<MasterServiceViewModel> dataViewModelList = new List<MasterServiceViewModel>();
            foreach (var data in dataList)
            {
                MasterServiceViewModel dataViewModel = new MasterServiceViewModel()
                {
                    MasterServiceId = data.MasterServiceId,
                    MasterServiceTitle = data.MasterServiceTitle,
                    MasterServiceDesc = data.MasterServiceDesc,
                    MasterServiceIcon = data.MasterServiceIcon,
                    IsActive = data.IsActive,
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }

        public ActionResult Active(int id)
        {
            MasterServiceRepository.Active(id, new MasterService()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            MasterServiceViewModel dataViewModel = new MasterServiceViewModel();
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterServiceViewModel dataViewModel)
        {
            try
            {
                MasterService data = new MasterService()
                {
                    MasterServiceTitle = dataViewModel.MasterServiceTitle,
                    MasterServiceDesc = dataViewModel.MasterServiceDesc,
                    MasterServiceIcon = dataViewModel.MasterServiceIcon,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterServiceRepository.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            MasterService data = MasterServiceRepository.Find(id);
            MasterServiceViewModel dataViewModel = new MasterServiceViewModel()
            {
                MasterServiceId = data.MasterServiceId,
                MasterServiceTitle = data.MasterServiceTitle,
                MasterServiceDesc = data.MasterServiceDesc,
                MasterServiceIcon = data.MasterServiceIcon
            };
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterServiceViewModel dataViewModel)
        {
            try
            {
                MasterService data = MasterServiceRepository.Find(id);
                data.MasterServiceTitle = dataViewModel.MasterServiceTitle;
                data.MasterServiceDesc = dataViewModel.MasterServiceDesc;
                data.MasterServiceIcon = dataViewModel.MasterServiceIcon;
                data.EditDate = DateTime.UtcNow;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterServiceRepository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            MasterServiceRepository.Delete(id, new MasterService()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
