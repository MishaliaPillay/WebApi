using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ToDoResponseDto
    {

        public required string Name { get; set; }
        public bool IsCompleted { get; set; }
        public required string PriorityLevel { get; set; }
        public DateOnly DateCreated { get; set; }
        public DateOnly DateDue { get; set; }

    }
}
