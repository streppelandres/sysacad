using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Student.Commands.EnrollStudentCourseCommand
{
    public class EnrollStudentCourseCommand : IRequest<ResponseWrapper<int>>
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }

    public class EnrollStudentCourseCommandHandler : IRequestHandler<EnrollStudentCourseCommand, ResponseWrapper<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Student> _studentRepositoryAsync;
        private readonly IRepositoryAsync<Domain.Entities.Course> _courseRepositoryAsync;
        private readonly IMapper _mapper;

        public EnrollStudentCourseCommandHandler(IRepositoryAsync<Domain.Entities.Student> studentRepositoryAsync,
            IRepositoryAsync<Domain.Entities.Course> courseRepositoryAsync,
            IMapper mapper)
        {
            _studentRepositoryAsync = studentRepositoryAsync;
            _courseRepositoryAsync = courseRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<int>> Handle(EnrollStudentCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepositoryAsync.GetByIdAsync(request.CourseId);
            
            if (course == null) throw new ApiException($"Course {request.CourseId} not found");
            if (course.Students.Count() >= course.MaxStudents)
                throw new ApiException("Course is full, no more vacancies allowed");
            if (!(course.Status.ToLower() == "new" || course.Status.ToLower() == "in progress"))
                throw new ApiException($"Course not avalible, {course.Status}");

            var student = await _studentRepositoryAsync.GetByIdAsync(request.StudentId);

            if (student == null) throw new ApiException($"Student {request.StudentId} not found");
            if (course.Students.Any(s => s.Id == student.Id))
                throw new ApiException($"Student {student.Id} is already registered in {course.Name}");

            student.Courses.Add(course);
            course.Students.Add(student);

            await _studentRepositoryAsync.UpdateAsync(student);
            await _courseRepositoryAsync.UpdateAsync(course);

            return new ResponseWrapper<int> { Message=$"Student {student.Id} registered in {course.Name} sucessfully" };
        }
    }
}
