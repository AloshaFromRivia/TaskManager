using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/status")]
    public class StatusController : Controller
    {
        private StatusRepository _repository;

        public StatusController(StatusRepository repository)
        {
            _repository = repository;
        }

        //GET: api/status/
        [HttpGet]
        public IQueryable<Status> Get() => _repository.GetStatuses();

        //api/status/1
        [HttpGet("{id}")]
        public Status Get(Guid id) => _repository.GetStatus(id);
    }
}