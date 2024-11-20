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
    public class TransactionNewsletterController : Controller
    {
        public IRepository<TransactionNewsletter> TransactionNewsletterRepository { get; }

        public TransactionNewsletterController(IRepository<TransactionNewsletter> TransactionNewsletterRepository)
        {
            this.TransactionNewsletterRepository = TransactionNewsletterRepository;
        }

        public IActionResult Index()
        {
            IList<TransactionNewsletter> dataList = TransactionNewsletterRepository.View();
            IList<TransactionNewsletterViewModel> dataViewModelList = new List<TransactionNewsletterViewModel>();
            foreach (var data in dataList)
            {
                TransactionNewsletterViewModel dataViewModel = new TransactionNewsletterViewModel()
                {
                    TransactionNewsletterId = data.TransactionNewsletterId,
                    TransactionNewsletterEmail = data.TransactionNewsletterEmail,
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }
    }
}
