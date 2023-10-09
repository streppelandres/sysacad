using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Course.Queries.GetAllCoursesAvailablesForEnrollmentQuery
{
    public class GetAllCoursesAvailablesForEnrollmentQuery : IRequest<ResponseWrapper<ICollection<CourseDto>>>
    {
    }

    public class GetAllCoursesAvailablesForEnrollmentQueryHandler : IRequestHandler<GetAllCoursesAvailablesForEnrollmentQuery, ResponseWrapper<ICollection<CourseDto>>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Course> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllCoursesAvailablesForEnrollmentQueryHandler(IRepositoryAsync<Domain.Entities.Course> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<ICollection<CourseDto>>> Handle(GetAllCoursesAvailablesForEnrollmentQuery request, CancellationToken cancellationToken)
        {
            var courses = await _repositoryAsync.ListAsync(new CourseByWithAvailableSpaceSpecification());
            if (!courses.Any()) throw new ApiException($"Courses with avalible space not found");
            var coursesDtos = _mapper.Map<ICollection<CourseDto>>(courses);
            return new ResponseWrapper<ICollection<CourseDto>>(coursesDtos);
        }
    }
}
