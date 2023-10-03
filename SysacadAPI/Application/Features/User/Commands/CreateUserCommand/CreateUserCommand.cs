using Application.Wrappers;
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
        public async Task<ResponseWrapper<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
