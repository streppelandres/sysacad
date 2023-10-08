using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Schedule.Queries.GetScheduleById
{
    public class GetScheduleByIdQuery : IRequest<ResponseWrapper<ScheduleDto>>
    {
        public int Id { get; set; }
    }

    public class GetScheduleByIdQueryHandler : IRequestHandler<GetScheduleByIdQuery, ResponseWrapper<ScheduleDto>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Schedule> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetScheduleByIdQueryHandler(IRepositoryAsync<Domain.Entities.Schedule> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<ScheduleDto>> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            var schedule = await _repositoryAsync.GetByIdAsync(request.Id);
            if (schedule == null) throw new ApiException($"Schedule id {request.Id} not found");
            var scheduleDto = _mapper.Map<ScheduleDto>(schedule);
            return new ResponseWrapper<ScheduleDto>(scheduleDto);
        }
    }
}
