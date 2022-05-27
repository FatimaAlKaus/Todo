using Application.Common;
using Application.DTO;
using Application.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITodoService
    {
        Task<(TodoDTO, Error)> GetById(int id);
        Task<(TodoDTO[], Error)> GetAll();
        Task<Error> Create(CreateTodoRequest input);
        Task<Error> Update(UpdateTodoRequest input);
        Task<Error> Delete(int id);

    }
}
