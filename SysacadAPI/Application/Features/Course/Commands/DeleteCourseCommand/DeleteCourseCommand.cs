using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;


namespace Application.Features.Course.Commands.DeleteCourseCommand
{
    public class DeleteCourseCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, ResponseWrapper<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Course> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteCourseCommandHandler(IRepositoryAsync<Domain.Entities.Course> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _repositoryAsync.GetByIdAsync(request.Id);
            if (course == null) throw new ApiException($"Course id {request.Id} not found");

            await _repositoryAsync.DeleteAsync(course);

            return new ResponseWrapper<int>(course.Id);
        }
    }
}
