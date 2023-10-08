using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Schedule.Commands.DeleteScheduleCommand
{
    public class DeleteScheduleCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, ResponseWrapper<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Schedule> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteScheduleCommandHandler(IRepositoryAsync<Domain.Entities.Schedule> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = await _repositoryAsync.GetByIdAsync(request.Id);
            if (schedule == null) throw new ApiException($"Schedule id {request.Id} not found");

            await _repositoryAsync.DeleteAsync(schedule);

            return new ResponseWrapper<int>(schedule.Id);
        }
    }


}
