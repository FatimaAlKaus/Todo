using Application.Common;
using Application.DTO;
using Application.Interfaces;
using Application.Request;
using Domain.Entity;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _dbContext;
        public TodoService(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Error> Create(CreateTodoRequest input)
        {
            try
            {
                await _dbContext.AddAsync(new Todo { Body = input.Body });
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return Error.InternalServerError();
            }
            return null;
        }

        public async Task<Error> Delete(int id)
        {
            try
            {
                var todo = await _dbContext.Todos.FindAsync(id);
                if (todo == null)
                {
                    return Error.NotFound();
                }
                _dbContext.Remove(todo);
                await _dbContext.SaveChangesAsync();
                return null;
            }
            catch
            {
                return Error.InternalServerError();
            }
        }

        public async Task<(TodoDTO[], Error)> GetAll()
        {
            try
            {
                return (await _dbContext.Todos.Select(x => new TodoDTO(x)).ToArrayAsync(), null);
            }
            catch
            {
                return (null, Error.InternalServerError());
            }
        }

        public async Task<(TodoDTO, Error)> GetById(int id)
        {
            try
            {
                var todo = await _dbContext.Todos.FindAsync(id);
                if (todo == null)
                {
                    return (null, Error.NotFound());
                }
                return (new TodoDTO(todo), null);
            }
            catch
            {
                return (null, Error.InternalServerError());
            }
        }

        public async Task<Error> Update(UpdateTodoRequest input)
        {
            try
            {
                var todo = await _dbContext.Todos.FindAsync(input.ID);
                if (todo == null)
                {
                    return Error.NotFound();
                }

                todo.Body = input.Body;
                await _dbContext.SaveChangesAsync();

                return null;
            }
            catch
            {
                return Error.InternalServerError();
            }

        }
    }
}
