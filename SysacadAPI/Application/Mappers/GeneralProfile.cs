using Application.DTOs;
using Application.Features.Course.Commands.CreateCourseCommand;
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
            CreateMap<ScheduleDto, Schedule>();
                //.ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.StartTime)))
                //.ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.EndTime)));
            CreateMap<CreateCourseCommand, Course>()
                .ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules));
        }
    }
}
