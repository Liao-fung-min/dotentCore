using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCRUD.Models
{
    public class TodoList
    {
        public int id { get; set; }
        [Required]
        public string Content { get; set; }

    }
}
