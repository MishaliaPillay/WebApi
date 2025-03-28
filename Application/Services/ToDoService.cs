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
    }


}
