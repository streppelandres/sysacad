using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Schedule.Commands.UpdateScheduleCommand
{
    public class UpdateScheduleCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; } // TODO Type
        public string EndTime { get; set; } // TODO Type
    }

    public class UpdateScheduleCommandHanlder : IRequestHandler<UpdateScheduleCommand, ResponseWrapper<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Schedule> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateScheduleCommandHanlder(IRepositoryAsync<Domain.Entities.Schedule> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<int>> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = await _repositoryAsync.GetByIdAsync(request.Id);
            if (schedule == null) throw new ApiException($"Schedule id {request.Id} not found");

            schedule.DayOfWeek = request.DayOfWeek;
            schedule.StartTime = request.StartTime;
            schedule.EndTime = request.EndTime;

            await _repositoryAsync.UpdateAsync(schedule);

            return new ResponseWrapper<int>(schedule.Id);
        }
    }
}
