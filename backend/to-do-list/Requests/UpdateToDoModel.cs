using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace to_do_list.Requests
{
    public class UpdateToDoModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}