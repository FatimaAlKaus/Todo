using Application.DTO;
using Application.Interfaces;
using Application.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("v1/todo")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoService _todoService;
        public TodoController(ILogger<TodoController> logger, ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<TodoDTO[]>> GetAll()
        {
            var (result, err) = await _todoService.GetAll(); if (err != null)
            {
                _logger.LogError(err.Message);
                return StatusCode(err.Code, err.Message);
            }
            _logger.LogInformation("GET");


            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDTO>> GetById(int id)
        {
            var (result, err) = await _todoService.GetById(id); if (err != null)
            {
                _logger.LogError(err.Message);
                return StatusCode(err.Code, err.Message);
            }
            _logger.LogInformation("GET", id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTodoRequest input)
        {
            var err = await _todoService.Create(input); if (err != null)
            {
                _logger.LogError(err.Message);
                return StatusCode(err.Code, err.Message);
            }
            _logger.LogInformation("POST", input);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var err = await _todoService.Delete(id); if (err != null)
            {
                _logger.LogError(err.Message);
                return StatusCode(err.Code, err.Message);
            }
            _logger.LogInformation("DELETE", id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateTodoRequest input)
        {
            var err = await _todoService.Update(input); if (err != null)
            {
                _logger.LogError(err.Message);
                return StatusCode(err.Code, err.Message);
            }
            _logger.LogInformation("PUT", input);

            return Ok();
        }
    }
}
