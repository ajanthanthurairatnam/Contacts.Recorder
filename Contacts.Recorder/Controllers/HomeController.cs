using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Contacts.Recorder.Models;
using Contacts.Recorder.Storage;
using Contacts.Recorder.API.Models;
using Contacts.Recorder.Core.Models;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace Contacts.Recorder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repository;

        public HomeController(ILogger<HomeController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
           return View(new ContactViewModel() { Contacts= _repository.FetchAll() });
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            _repository.Add(contact);
            return Json(contact);
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            return Json(_repository.FetchAll());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
