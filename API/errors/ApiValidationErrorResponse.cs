using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.errors
{
    public class ApiValidationErrorResponse :ApiResponse
    {
        public ApiValidationErrorResponse()
            : base(400)
        {
            // we know that we will be sending the same status code  to the base controller
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
