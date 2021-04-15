using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodosWebApi.WebApi.Dtos;
using TodosWebApi.WebApi.Entities;
using TodosWebApi.WebApi.Interfaces;

namespace TodosWebApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodosController(ITodoRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> Get()
        {
            return await _repository.Get();
        }

        [HttpPost]
        public async Task<TodoDto> Create(TodoDto item)
        {
            return await _repository.Create(item);
        }

        [HttpPut("{id}")]
        public async Task ToggleTodo(TodoItem todo)
        {
            
            await _repository.ToggleTodo(todo);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTodoAsync(int id)
        {
            await _repository.DeleteTodoAsync(id);
        }
    }

}
