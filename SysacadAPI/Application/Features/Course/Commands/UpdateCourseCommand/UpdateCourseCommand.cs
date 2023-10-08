using Application.Exceptions;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Course.Commands.UpdateCourseCommand
{
    public class UpdateCourseCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
        public short MaxStudents { get; set; }
        public string ClassRoom { get; set; }
        public string Division { get; set; }
        public short Quarter { get; set; } // TODO Type
    }

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, ResponseWrapper<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Course> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateCourseCommandHandler(IRepositoryAsync<Domain.Entities.Course> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<int>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _repositoryAsync.GetByIdAsync(request.Id);
            if (course == null) throw new ApiException($"Course id {request.Id} not found");

            var registeredCourse = await _repositoryAsync.FirstOrDefaultAsync(new CourseWithCodeSpecification(request.Code));
            if (registeredCourse != null && registeredCourse.Id != request.Id) throw new ApiException($"Course code {request.Code} already registered");

            course.Name = request.Name;
            course.Description = request.Description;
            course.Code = request.Code;
            course.MaxStudents = request.MaxStudents;
            course.ClassRoom = request.ClassRoom;
            course.Division = request.Division;

            await _repositoryAsync.UpdateAsync(course);

            return new ResponseWrapper<int>(course.Id);
        }
    }
}
