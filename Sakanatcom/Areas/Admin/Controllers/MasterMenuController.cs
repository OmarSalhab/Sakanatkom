using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sakanatcom.Models;
using Sakanatcom.Models.Repositories;
using Sakanatcom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Sakanatcom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterMenuController : Controller
    {
        public IRepository<MasterMenu> MasterMenuRepository { get; }

        public MasterMenuController(IRepository<MasterMenu> MasterMenuRepository)
        {
            this.MasterMenuRepository = MasterMenuRepository;
        }
        public ActionResult Index()
        {
            IList<MasterMenu> dataList = MasterMenuRepository.View();
            IList<MasterMenuViewModel> dataViewModelList = new List<MasterMenuViewModel>();
            foreach (var data in dataList)
            {
                MasterMenuViewModel dataViewModel = new MasterMenuViewModel()
                {
                    MasterMenuId = data.MasterMenuId,
                    MasterMenuName = data.MasterMenuName,
                    MasterMenuUrl = data.MasterMenuUrl,
                    IsActive = data.IsActive
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }

        public ActionResult Active(int id)
        {
            MasterMenuRepository.Active(id, new MasterMenu()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            MasterMenuViewModel dataViewModel = new MasterMenuViewModel();
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMenuViewModel dataViewModel)
        {
            try
            {
                if (MasterMenuRepository.View().Where(data => data.MasterMenuName.ToUpper()
                == dataViewModel.MasterMenuName.ToUpper()).ToList().Count > 0)
                {
                    ModelState.AddModelError("", "This name is already used.");
                    return View(dataViewModel);
                }
                MasterMenu data = new MasterMenu()
                {
                    MasterMenuName = dataViewModel.MasterMenuName,
                    MasterMenuUrl = dataViewModel.MasterMenuUrl,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterMenuRepository.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            MasterMenu data = MasterMenuRepository.Find(id);
            MasterMenuViewModel dataViewModel = new MasterMenuViewModel()
            {
                MasterMenuId = data.MasterMenuId,
                MasterMenuName = data.MasterMenuName,
                MasterMenuUrl = data.MasterMenuUrl
            };
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterMenuViewModel dataViewModel)
        {
            try
            {
                MasterMenu data = MasterMenuRepository.Find(id);
                if (MasterMenuRepository.View().Where(data => data.MasterMenuName.ToUpper()
                == dataViewModel.MasterMenuName.ToUpper()).ToList().Count > 0
                && data.MasterMenuName.ToUpper() != dataViewModel.MasterMenuName.ToUpper())
                {
                    ModelState.AddModelError("", "This name is already used.");
                    return View(dataViewModel);
                }
                data.MasterMenuName = dataViewModel.MasterMenuName;
                data.MasterMenuUrl = dataViewModel.MasterMenuUrl;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.EditDate = DateTime.UtcNow;
                MasterMenuRepository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            MasterMenuRepository.Delete(id, new MasterMenu()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
