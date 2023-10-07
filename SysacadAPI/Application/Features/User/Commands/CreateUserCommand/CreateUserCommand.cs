﻿using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<ResponseWrapper<int>>
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long DocumentNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public bool HasToChangePassword { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseWrapper<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.User> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IRepositoryAsync<Domain.Entities.User> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var mappedUser = _mapper.Map<Domain.Entities.User>(request);
            var data = await _repositoryAsync.AddAsync(mappedUser);
            return new ResponseWrapper<int>(data.Id);
        }
    }
}
