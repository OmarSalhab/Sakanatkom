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
    public class MasterCategoryMenuController : Controller
    {
        public IRepository<MasterCategoryMenu> MasterCategoryMenuRepository { get; }

        public MasterCategoryMenuController(IRepository<MasterCategoryMenu> _MasterCategoryMenuRepository)
        {
            MasterCategoryMenuRepository = _MasterCategoryMenuRepository;
        }
        public ActionResult Index()
        {
            IList<MasterCategoryMenu> dataList = MasterCategoryMenuRepository.View();
            IList<MasterCategoryMenuViewModel> dataViewModelList = new List<MasterCategoryMenuViewModel>();
            foreach (var data in dataList)
            {
                MasterCategoryMenuViewModel dataViewModel = new MasterCategoryMenuViewModel()
                {
                    MasterCategoryMenuId = data.MasterCategoryMenuId,
                    MasterCategoryMenuName = data.MasterCategoryMenuName,
                    IsActive = data.IsActive
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }

        public ActionResult Active(int id)
        {
            MasterCategoryMenuRepository.Active(id, new MasterCategoryMenu()
            {
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                EditDate = DateTime.UtcNow
            });
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            MasterCategoryMenuViewModel dataViewModel = new MasterCategoryMenuViewModel();
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterCategoryMenuViewModel dataViewModel)
        {
            try
            {
                if (MasterCategoryMenuRepository.View().Where(data => data.MasterCategoryMenuName.ToUpper() 
                == dataViewModel.MasterCategoryMenuName.ToUpper()).ToList().Count > 0)
                {
                    ModelState.AddModelError("", "This name is already used.");
                    return View(dataViewModel);
                }
                MasterCategoryMenu data = new MasterCategoryMenu()
                {
                    MasterCategoryMenuName = dataViewModel.MasterCategoryMenuName,
                    CreateDate = dataViewModel.CreateDate,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsDelete = false,
                    IsActive = true
                };
                MasterCategoryMenuRepository.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            MasterCategoryMenu data = MasterCategoryMenuRepository.Find(id);
            MasterCategoryMenuViewModel dataViewModel = new MasterCategoryMenuViewModel()
            {
                MasterCategoryMenuId = data.MasterCategoryMenuId,
                MasterCategoryMenuName = data.MasterCategoryMenuName,
            };
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterCategoryMenuViewModel dataViewModel)
        {
            try
            {
                MasterCategoryMenu data = MasterCategoryMenuRepository.Find(id);
                if (MasterCategoryMenuRepository.View().Where(data => data.MasterCategoryMenuName.ToUpper()
                == dataViewModel.MasterCategoryMenuName.ToUpper()).ToList().Count > 0 
                && data.MasterCategoryMenuName.ToUpper() != dataViewModel.MasterCategoryMenuName.ToUpper())
                {
                    ModelState.AddModelError("", "This name is already used.");
                    return View(dataViewModel);
                }
                data.MasterCategoryMenuName = dataViewModel.MasterCategoryMenuName;
                data.EditDate = DateTime.UtcNow;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterCategoryMenuRepository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            MasterCategoryMenuRepository.Delete(id, new MasterCategoryMenu()
            {
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                EditDate = DateTime.UtcNow
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
