using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class UpdateTodoRequest
    {
        [Required]
        public int ID { get; init; }

        [Required]
        public string Body { get; init; }
    }
}
