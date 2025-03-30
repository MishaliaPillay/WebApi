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
        Task<ToDoUpdateDto> UpdateAsync(ToDoUpdateDto updateToDoDto, int id);
        Task<ToDoCreateDto> AddAsync(ToDoCreateDto createToDoDto);
        //true is 204 - no content , successfully deleted
        //false is 404 - item wasn't found 
        Task<bool> DeleteAsync(int id);
    }
}
