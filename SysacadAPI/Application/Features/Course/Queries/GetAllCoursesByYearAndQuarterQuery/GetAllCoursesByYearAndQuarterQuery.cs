using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Course.Queries.GetAllCoursesByYearAndQuarterQuery
{
    public class GetAllCoursesByYearAndQuarterQuery : IRequest<ResponseWrapper<ICollection<CourseDto>>>
    {
        public string Year { get; set; }
        public short Quarter { get; set; }
    }

    public class GetAllCoursesByYearAndQuarterQueryHandler : IRequestHandler<GetAllCoursesByYearAndQuarterQuery, ResponseWrapper<ICollection<CourseDto>>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Course> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllCoursesByYearAndQuarterQueryHandler(IRepositoryAsync<Domain.Entities.Course> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<ICollection<CourseDto>>> Handle(GetAllCoursesByYearAndQuarterQuery request, CancellationToken cancellationToken)
        {
            var courses = await _repositoryAsync.ListAsync(new CourseByYearAndQuarterSpecification(request.Year, request.Quarter));
            if (!courses.Any()) throw new ApiException($"Courses not found with the Year: {request.Year} and the Quarter: {request.Quarter}");
            var coursesDtos = _mapper.Map<ICollection<CourseDto>>(courses);
            return new ResponseWrapper<ICollection<CourseDto>>(coursesDtos);
        }
    }
}
