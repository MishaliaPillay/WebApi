using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ToDoCreateDto
    {

        public required string Name { get; set; }

        public required string PriorityLevel { get; set; }

        public DateOnly DateDue { get; set; }

    }
}
