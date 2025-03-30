using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Models.Entities;

namespace Application.Interfaces
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDoResponseDto>> GetAllAsync();
        Task<IEnumerable<ToDoUpdateDto>> UpdateAsync(ToDo toDo, int id);
        Task<IEnumerable<ToDoCreateDto>> AddAsync(ToDo toDo);
        //true is 204 - no content , successfully deleted
        //false is 404 - item wasn't found 
        Task<bool> DeleteAsync(int id);
    }
}
