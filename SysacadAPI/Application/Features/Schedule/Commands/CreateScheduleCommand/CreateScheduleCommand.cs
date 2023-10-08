using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Schedule.Commands.CreateScheduleCommand
{
    public class CreateScheduleCommand : IRequest<ResponseWrapper<int>>
    {
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; } // TODO Type
        public string EndTime { get; set; } // TODO Type
        public int CourseId { get; set; }
    }

    public class CreateScheduleCommandHanlder : IRequestHandler<CreateScheduleCommand, ResponseWrapper<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Schedule> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateScheduleCommandHanlder(IRepositoryAsync<Domain.Entities.Schedule> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<int>> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var mappedSchedule = _mapper.Map<Domain.Entities.Schedule>(request);
            var data = await _repositoryAsync.AddAsync(mappedSchedule);
            return new ResponseWrapper<int>(data.Id);
        }
    }
}
