using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Application.Mappings
{
    public class ToDoMappingProfile : Profile

    {
        public ToDoMappingProfile()
        {


            CreateMap<ToDo, ToDoResponseDto>();
            CreateMap<ToDoCreateDto, ToDo>();
            CreateMap<ToDoUpdateDto, ToDo>();
        }
    }
}
