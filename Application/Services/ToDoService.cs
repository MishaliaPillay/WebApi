using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ToDoService : IToDoRepository
    {
        private readonly ApplicationDbContext _context;

        // Constructor Where we do dependency injection
        public ToDoService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ToDo>> GetAllAsync()
        {
            var todos = await _context.ToDos.ToListAsync();
            return todos;
        }
        public async Task<ToDo> UpdateAsync(ToDo updatedToDo, int id)
        {
            var existingToDo = await _context.ToDos.FindAsync(id);
            if (existingToDo == null)
            {
                return null;
            }

            existingToDo.Name = updatedToDo.Name;
            existingToDo.PriorityLevel = updatedToDo.PriorityLevel;
            existingToDo.DateDue = updatedToDo.DateDue;
            existingToDo.DateCreated = updatedToDo.DateCreated;
            existingToDo.IsCompleted = updatedToDo.IsCompleted;

            await _context.SaveChangesAsync();
            return existingToDo;

        }
        public async Task<ToDo> AddAsync(ToDo toDo)
        {


            if (toDo == null)
            {
                throw new ArgumentNullException(nameof(toDo));
            }
            await _context.ToDos.AddAsync(toDo);
            await _context.SaveChangesAsync();
            return toDo;


        }
        public async Task<bool> DeleteAsync(int id)
        {
            var toDo = await _context.ToDos.Where(t => t.Id == id).FirstOrDefaultAsync();
            if (toDo == null)
            {
                return false;
            }
            _context.ToDos.Remove(toDo);
            await _context.SaveChangesAsync();
            return true;
        }
    }


}
