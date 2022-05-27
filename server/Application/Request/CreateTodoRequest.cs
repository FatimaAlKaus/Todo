using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class CreateTodoRequest
    {
        [Required]
        public string Body { get; init; }
    }
}
