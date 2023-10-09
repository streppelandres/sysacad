using Application.Exceptions;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Course.Queries.GetAllCoursesByStudentIdQuery
{
    public class GetAllCoursesByStudentIdQuery : IRequest<ResponseWrapper<ICollection<GetAllCoursesByStudentIdResponse>>>
    {
        public int StudentId { get; set; }
    }

    public class GetAllCoursesByStudentIdQueryHanlder : IRequestHandler<GetAllCoursesByStudentIdQuery, ResponseWrapper<ICollection<GetAllCoursesByStudentIdResponse>>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Course> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllCoursesByStudentIdQueryHanlder(IRepositoryAsync<Domain.Entities.Course> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<ICollection<GetAllCoursesByStudentIdResponse>>> Handle(GetAllCoursesByStudentIdQuery request, CancellationToken cancellationToken)
        {
            var courses = await _repositoryAsync.ListAsync(new CourseByStudentIdSpecification(request.StudentId));
            if(!courses.Any()) throw new ApiException($"Courses not found with the StudentId: {request.StudentId}");
            var coursesDtos = _mapper.Map<ICollection<GetAllCoursesByStudentIdResponse>>(courses);
            return new ResponseWrapper<ICollection<GetAllCoursesByStudentIdResponse>>(coursesDtos);
        }
    }
}
