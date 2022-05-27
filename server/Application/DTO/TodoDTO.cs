using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class TodoDTO
    {
        public TodoDTO(Todo todo)
        {
            ID = todo.ID;
            Body = todo.Body;
        }
        public int ID { get; init; }
        public string Body { get; init; }
    }
}
