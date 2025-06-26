using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace to_do_list.Requests
{
    public class AddToDoModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}