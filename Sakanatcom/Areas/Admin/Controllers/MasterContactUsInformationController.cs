using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sakanatcom.Models;
using Sakanatcom.Models.Repositories;
using Sakanatcom.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;

namespace Sakanatcom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterContactUsInformationController : Controller
    {
        public IRepository<MasterContactUsInformation> MasterContactUsInformationRepository { get; }

        public MasterContactUsInformationController(
            IRepository<MasterContactUsInformation> MasterContactUsInformationRepository)
        {
            this.MasterContactUsInformationRepository = MasterContactUsInformationRepository;
        }

        public ActionResult Index()
        {
            IList<MasterContactUsInformation> dataList = MasterContactUsInformationRepository.View();
            IList<MasterContactUsInformationViewModel> dataViewModelList = new List<MasterContactUsInformationViewModel>();
            foreach (var data in dataList)
            {
                MasterContactUsInformationViewModel dataViewModel = new MasterContactUsInformationViewModel()
                {
                    MasterContactUsInformationId = data.MasterContactUsInformationId,
                    MasterContactUsInformationDesc = data.MasterContactUsInformationDesc,
                    MasterContactUsInformationIcon = data.MasterContactUsInformationIcon,
                    MasterContactUsInformationRedirect = data.MasterContactUsInformationRedirect,
                    IsActive = data.IsActive,
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }

        public ActionResult Active(int id)
        {
            MasterContactUsInformationRepository.Active(id, new MasterContactUsInformation()
            {
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                EditDate = DateTime.UtcNow
            });
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            MasterContactUsInformationViewModel dataViewModel = new MasterContactUsInformationViewModel();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterContactUsInformationViewModel dataViewModel)
        {
            try
            {
                MasterContactUsInformation data = new MasterContactUsInformation()
                {
                    MasterContactUsInformationDesc = dataViewModel.MasterContactUsInformationDesc,
                    MasterContactUsInformationIcon = dataViewModel.MasterContactUsInformationIcon,
                    MasterContactUsInformationRedirect = dataViewModel.MasterContactUsInformationRedirect,
                    IsActive = true,
                    IsDelete = false,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreateDate = DateTime.UtcNow
                };
                MasterContactUsInformationRepository.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            MasterContactUsInformation data = MasterContactUsInformationRepository.Find(id);
            MasterContactUsInformationViewModel dataViewModel = new MasterContactUsInformationViewModel()
            {
                MasterContactUsInformationId = data.MasterContactUsInformationId,
                MasterContactUsInformationDesc = data.MasterContactUsInformationDesc,
                MasterContactUsInformationIcon = data.MasterContactUsInformationIcon,
                MasterContactUsInformationRedirect = data.MasterContactUsInformationRedirect,
            };
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterContactUsInformationViewModel dataViewModel)
        {
            try
            {
                MasterContactUsInformation data = MasterContactUsInformationRepository.Find(id);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.MasterContactUsInformationDesc = dataViewModel.MasterContactUsInformationDesc;
                data.MasterContactUsInformationIcon = dataViewModel.MasterContactUsInformationIcon;
                data.MasterContactUsInformationRedirect = dataViewModel.MasterContactUsInformationRedirect;
                MasterContactUsInformationRepository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            MasterContactUsInformationRepository.Delete(id, new MasterContactUsInformation()
            {
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                EditDate = DateTime.UtcNow
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
