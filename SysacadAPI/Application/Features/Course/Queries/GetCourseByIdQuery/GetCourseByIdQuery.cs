using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;


namespace Application.Features.Course.Queries.GetCourseByIdQuery
{
    public class GetCourseByIdQuery : IRequest<ResponseWrapper<CourseDto>>
    {
        public int Id { get; set; }
    }

    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, ResponseWrapper<CourseDto>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Course> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetCourseByIdQueryHandler(IRepositoryAsync<Domain.Entities.Course> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _repositoryAsync.GetByIdAsync(request.Id);
            if (course == null) throw new ApiException($"Course {request.Id} not found");
            var courseDto = _mapper.Map<CourseDto>(course);
            return new ResponseWrapper<CourseDto>(courseDto);
        }
    }
}
