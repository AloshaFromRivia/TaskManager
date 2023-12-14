using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models;
using TaskManagerAPI.Models.Interfaces;
using TaskManagerAPI.Models.Requests;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : Controller
    {
        private IRepository<TaskModel> _repository;

        public TaskController(IRepository<TaskModel> repository)
        {
            _repository = repository;
        }

        //GET: api/task/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetAll() => Ok( await _repository.GetAsync());

        //GET: api/task/1
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> Get(Guid id)
        {
            var result = await _repository.GetAsync(id);
            if (result is null) return NotFound();
            else return Ok(result);
        }

        //DELETE: api/task/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var item = await _repository.GetAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            
            await _repository.DeleteAsync(item);

            return NoContent();
        }

        //POST: /api/task/
        [HttpPost]
        public async Task<ActionResult<TaskModel>> Post([FromBody]PostTaskRequest taskRequest)
        {
            var task = new TaskModel()
            {
                Id = Guid.NewGuid(),
                Name = taskRequest.Name,
                Description = taskRequest.Description,
                StatusId = taskRequest.StatusId
            };

            await _repository.PostAsync(task);

            return CreatedAtAction("Get", new { id = task.Id }, task);
        }

        //PUT: api/task/
        [HttpPut]
        public async Task<ActionResult> Put(PutTaskRequest request)
        {
            if (request.Id != request.TaskModel.Id) return BadRequest();
            else
            {
                await _repository.PutAsync(request.Id,request.TaskModel);
            }

            return NoContent();
        }
    }
}