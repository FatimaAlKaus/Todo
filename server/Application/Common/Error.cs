using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class Error
    {
        public string Message { get; set; }
        public int Code { get; set; }

        public static Error InternalServerError(string message) => new Error() { Message = message, Code = 500 };
        public static Error NotFound(string message) => new Error() { Message = message, Code = 404 };
        public static Error NotFound() => new Error() { Message = "The resource with such ID was not found.", Code = 404 };
        public static Error InternalServerError() => new Error() { Message = "We encountered an error while processing your request.", Code = 500 };
    }
}
