using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using MediatR;


namespace Application.Features.Schedule.Queries.GetAllSchedulesByCourseId
{
    public class GetAllSchedulesByCourseIdQuery : IRequest<ResponseWrapper<ICollection<ScheduleDto>>>
    {
        public int CourseId { get; set; }
    }

    public class GetAllSchedulesByCourseQueryHanlder : IRequestHandler<GetAllSchedulesByCourseIdQuery, ResponseWrapper<ICollection<ScheduleDto>>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Schedule> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllSchedulesByCourseQueryHanlder(IRepositoryAsync<Domain.Entities.Schedule> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<ICollection<ScheduleDto>>> Handle(GetAllSchedulesByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var schedules = await _repositoryAsync.ListAsync(new ScheduleByCourseIdSpecification(request.CourseId));
            if (!schedules.Any()) new ApiException($"Schedules not found with the CourseId: {request.CourseId}");
            var schedulesDtos = _mapper.Map<ICollection<ScheduleDto>>(schedules);
            return new ResponseWrapper<ICollection<ScheduleDto>>(schedulesDtos);
        }
    }
}
