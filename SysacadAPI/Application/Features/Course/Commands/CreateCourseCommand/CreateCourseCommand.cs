using Application.Exceptions;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Course.Commands.CreateCourseCommand
{
    public class CreateCourseCommand : IRequest<ResponseWrapper<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
        public short MaxStudents { get; set; }
        public string ClassRoom { get; set;  }
        public string Division { get; set; }
        public short Quarter { get; set; } // TODO Type
    }

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, ResponseWrapper<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Course> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateCourseCommandHandler(IRepositoryAsync<Domain.Entities.Course> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<int>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var registeredCode = await _repositoryAsync.FirstOrDefaultAsync(new CourseWithCodeSpecification(request.Code));
            if (registeredCode != null) throw new ApiException($"Course code {request.Code} already registered");

            var mappedCourse = _mapper.Map<Domain.Entities.Course>(request);
            var data = await _repositoryAsync.AddAsync(mappedCourse);
            return new ResponseWrapper<int>(data.Id);
        }
    }
}
