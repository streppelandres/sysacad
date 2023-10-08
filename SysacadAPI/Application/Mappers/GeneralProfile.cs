using Application.DTOs;
using Application.Features.Course.Commands.CreateCourseCommand;
using Application.Features.Course.Queries.GetAllCoursesByStudentIdQuery;
using Application.Features.Schedule.Commands.CreateScheduleCommand;
using Application.Features.User.Commands.CreateUserCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<CreateScheduleCommand, Schedule>();
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<Schedule, ScheduleDto>();
            CreateMap<Course, GetAllCoursesByStudentIdResponse>();
        }
    }
}
