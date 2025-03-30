﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Entities;

namespace Application.Interfaces
{
    public interface IToDoRepository
    {
        Task<List<ToDo>> GetAllAsync();
        Task<ToDo> UpdateAsync(ToDo toDo, int id);
        Task<ToDo> AddAsync(ToDo toDo);
        //true is 204 - no content , successfully deleted
        //false is 404 - item wasn't found 
        Task<bool> DeleteAsync(int id);
    }
}
