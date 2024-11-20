using Microsoft.AspNetCore.Mvc;
using Sakanatcom.Models.Repositories;
using Sakanatcom.Models;
using Sakanatcom.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Sakanatcom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionContactUsController : Controller
    {
        public IRepository<TransactionContactUs> TransactionContactUsRepository { get; }

        public TransactionContactUsController(IRepository<TransactionContactUs> TransactionContactUsRepository)
        {
            this.TransactionContactUsRepository = TransactionContactUsRepository;
        }

        public IActionResult Index()
        {
            IList<TransactionContactUs> dataList = TransactionContactUsRepository.View();
            IList<TransactionContactUsViewModel> dataViewModelList = new List<TransactionContactUsViewModel>();
            foreach (var data in dataList)
            {
                TransactionContactUsViewModel dataViewModel = new TransactionContactUsViewModel()
                {
                    TransactionContactUsId = data.TransactionContactUsId,
                    TransactionContactUsFullName = data.TransactionContactUsFullName,
                    TransactionContactUsEmail = data.TransactionContactUsEmail,
                    TransactionContactUsSubject = data.TransactionContactUsSubject,
                    TransactionContactUsMessage = data.TransactionContactUsMessage
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }
    }
}
