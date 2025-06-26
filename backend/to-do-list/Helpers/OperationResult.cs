using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace to_do_list.Helpers
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public static OperationResult Ok(string message = "operation done successfully")
        {
            return new OperationResult
            {
                Success = true,
                Message = message
            };
        }

        public static OperationResult Fail(string message = "something went wrong")
        {
            return new OperationResult
            {
                Success = false,
                Message = message
            };
        }
    }
}