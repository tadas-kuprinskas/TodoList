using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodosWebApi.WebApi.Data;
using TodosWebApi.WebApi.Dtos;
using TodosWebApi.WebApi.Entities;
using TodosWebApi.WebApi.Interfaces;

namespace TodosWebApi.WebApi.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext dataContext)
        {
            _context = dataContext;
        }


        public async Task<IEnumerable<TodoItem>> Get()
        {
            return await _context.Items.ToListAsync();
        }


        public async Task<TodoDto> Create(TodoDto item)
        {
            _context.Items.Add(new TodoItem()
            {
                Title = item.Title,
                Completed = item.Completed
            });
            await _context.SaveChangesAsync();

            return item;
        }


        public async Task ToggleTodo(TodoItem todo)
        {
            _context.Update(todo);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteTodoAsync(int id)
        {
            var todo = await _context.Items.FindAsync(id);
            _context.Items.Remove(todo);
            await _context.SaveChangesAsync();
        }
    }
}
