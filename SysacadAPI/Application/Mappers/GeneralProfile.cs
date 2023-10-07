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
        }
    }
}
