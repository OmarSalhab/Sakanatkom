using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
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
    public class MasterWorkingHourController : Controller
    {
        public IRepository<MasterWorkingHour> MasterWorkingHourRepository { get; }

        public MasterWorkingHourController(IRepository<MasterWorkingHour> MasterWorkingHourRepository)
        {
            this.MasterWorkingHourRepository = MasterWorkingHourRepository;
        }
        public ActionResult Index()
        {
            IList<MasterWorkingHour> dataList = MasterWorkingHourRepository.View();
            IList<MasterWorkingHourViewModel> dataViewModelList = new List<MasterWorkingHourViewModel>();
            foreach (var data in dataList)
            {
                MasterWorkingHourViewModel dataViewModel = new MasterWorkingHourViewModel()
                {
                    MasterWorkingHourId = data.MasterWorkingHourId,
                    MasterWorkingHourName = data.MasterWorkingHourName,
                    MasterWorkingHourTimeFormTo = data.MasterWorkingHourTimeFormTo,
                    IsActive = data.IsActive,
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }

        public ActionResult Active(int id)
        {
            MasterWorkingHourRepository.Active(id, new MasterWorkingHour()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            MasterWorkingHourViewModel data = new MasterWorkingHourViewModel();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterWorkingHourViewModel dataViewModel)
        {
            try
            {
                MasterWorkingHour data = new MasterWorkingHour()
                {
                    MasterWorkingHourName = dataViewModel.MasterWorkingHourName,
                    MasterWorkingHourTimeFormTo = dataViewModel.MasterWorkingHourTimeFormTo,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterWorkingHourRepository.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            MasterWorkingHour data = MasterWorkingHourRepository.Find(id);
            MasterWorkingHourViewModel dataViewModel = new MasterWorkingHourViewModel()
            {
                MasterWorkingHourId = data.MasterWorkingHourId,
                MasterWorkingHourName = data.MasterWorkingHourName,
                MasterWorkingHourTimeFormTo = data.MasterWorkingHourTimeFormTo,
            };
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterWorkingHour dataViewModel)
        {
            try
            {
                MasterWorkingHour data = MasterWorkingHourRepository.Find(id);
                data.MasterWorkingHourName = dataViewModel.MasterWorkingHourName;
                data.MasterWorkingHourTimeFormTo = dataViewModel.MasterWorkingHourTimeFormTo;
                data.EditDate = DateTime.UtcNow;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterWorkingHourRepository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            MasterWorkingHourRepository.Delete(id, new MasterWorkingHour()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
