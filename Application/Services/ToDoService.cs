using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Models.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ToDoService : IToDoRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;
        // Constructor Where we do dependency injection
        public ToDoService(ApplicationDbContext context, IMapper mapper)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));

            _mapper = mapper;
        }

        public async Task<IEnumerable<ToDoResponseDto>> GetAllAsync()
        {
            var todos = await _context.ToDos.ToListAsync();
            return _mapper.Map<IEnumerable<ToDoResponseDto>>(todos);
        }
        public async Task<ToDoResponseDto> UpdateAsync(ToDoUpdateDto updateToDoDto, int id)
        {
            var existingToDo = await _context.ToDos.FindAsync(id);
            if (existingToDo == null)
            {
                return null;
            }



            _mapper.Map(updateToDoDto, existingToDo);
            await _context.SaveChangesAsync();
            return _mapper.Map<ToDoResponseDto>(existingToDo);

        }
        public async Task<ToDoResponseDto> AddAsync(ToDoCreateDto createToDoDto)
        {


            if (createToDoDto == null)
            {
                throw new ArgumentNullException(nameof(createToDoDto));
            }

            var toDo = _mapper.Map<ToDo>(createToDoDto);
            toDo.DateCreated = DateOnly.FromDateTime(DateTime.UtcNow);

            await _context.ToDos.AddAsync(toDo);
            await _context.SaveChangesAsync();
            return _mapper.Map<ToDoResponseDto>(toDo);


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


