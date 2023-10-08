using Application.Exceptions;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Student.Commands.RegisterStudentCommand
{
    public class RegisterStudentCommand : IRequest<ResponseWrapper<int>>
    {
        public int UserId { get; set; }
    }

    public class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommand, ResponseWrapper<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Student> _studentRepositoryAsync;
        private readonly IRepositoryAsync<Domain.Entities.User> _userRepositoryAsync;
        private readonly IMapper _mapper;

        public RegisterStudentCommandHandler(IRepositoryAsync<Domain.Entities.Student> studentRepositoryAsync,
            IRepositoryAsync<Domain.Entities.User> userRepositoryAsync, IMapper mapper)
        {
            _studentRepositoryAsync = studentRepositoryAsync;
            _userRepositoryAsync = userRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<int>> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            var existedUser = await _userRepositoryAsync.FirstOrDefaultAsync(new UserWithIdSpecification(request.UserId));
            if (existedUser == null) throw new ApiException($"User {request.UserId} not found");

            var registeredStudent = await _studentRepositoryAsync.FirstOrDefaultAsync(new StudentRegisteredUserSpecification(request.UserId));
            if (registeredStudent != null) throw new ApiException($"Student already registered with user id {request.UserId}");

            // TODO: Email service

            var mappedStudent = _mapper.Map<Domain.Entities.Student>(request);
            var data = await _studentRepositoryAsync.AddAsync(mappedStudent);
            return new ResponseWrapper<int>(data.Id, "Student registered correctly");
        }
    }
}
