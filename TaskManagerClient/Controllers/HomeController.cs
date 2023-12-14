using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RestSharp;
using TaskManagerClient.Models;
using TaskManagerClient.Models.Interfaces;

namespace TaskManagerClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<TaskModel> _repository;
        private readonly StatusRepository _statusRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<TaskModel> repository,
            StatusRepository statusRepository)
        {
            _logger = logger;
            _repository = repository;
            _statusRepository = statusRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Task()
        {
            return View( await _repository.GetAsync());
        }

        public async Task<RedirectToActionResult> Delete(Guid id)
        {
            var result= await _repository.DeleteAsync(id);

            if (result == ResponseStatus.Error)
            {
                ModelState.AddModelError("", "Ошибка при удалении");
            } 
            return RedirectToAction("Task");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.StatusList = new SelectList(await _statusRepository.GetAsync(),"Id","Name");
            
            return View(new PostTaskRequestModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostTaskRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.StatusList = new SelectList(await _statusRepository.GetAsync(),"Id","Name");
                return View(model);
            }

            var result = await _repository.PostAsync(model);

            if (result != HttpStatusCode.Created)
            {
                ModelState.AddModelError("","Ошибка при создании");
                return View(model);
            }

            return RedirectToAction("Task");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var task = await _repository.GetAsync(id);

            if (task is null)
            {
                return RedirectToAction("Task");
            }
            
            ViewBag.StatusList = new SelectList(await _statusRepository.GetAsync(),"Id","Name");
            
            return View(task);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(TaskModel model)
        {
            //validation
            if (!ModelState.IsValid)
            {
                ViewBag.StatusList = new SelectList(await _statusRepository.GetAsync(),"Id","Name");
                return View(model);
            }

            //task editing 
            var result = await _repository.PutAsync(model.Id,model);

            if (result != HttpStatusCode.NoContent)
            {
                ModelState.AddModelError("",result.ToString());
                ViewBag.StatusList = new SelectList(await _statusRepository.GetAsync(),"Id","Name");
                return View(model);
            }
            
            return RedirectToAction("Task");
        }
    }
}