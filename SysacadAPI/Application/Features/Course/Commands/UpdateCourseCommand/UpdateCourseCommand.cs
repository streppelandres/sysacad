using Application.DTOs;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Course.Commands.UpdateCourseCommand
{
    public class UpdateCourseCommand : IRequest<ResponseWrapper<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
        public short MaxStudents { get; set; }
        public string ClassRoom { get; set; }
        public List<ScheduleDto> Schedules { get; set; }
    }

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, ResponseWrapper<int>>
    {
        public Task<ResponseWrapper<int>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
