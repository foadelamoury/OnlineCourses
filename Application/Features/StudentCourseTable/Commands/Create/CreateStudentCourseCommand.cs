using Application.Features.StudentCourseTable.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.StudentCourseTable.Commands.Create
{
    public class CreateStudentCourseCommand : StudentCourseDTO, IRequest<long>
    {
        
		public CreateStudentCourseCommand()
        { }


        public CreateStudentCourseCommand(StudentCourseDTO dto)
        {
            Id = dto.Id;
            StudentId = dto.StudentId;
            CourseId = dto.CourseId;

        }
        public class Handler : IRequestHandler<CreateStudentCourseCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {

                _context = context;
            }
            public async Task<long> Handle(CreateStudentCourseCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.StudentCourse entity = new Domain.Entities.StudentCourse
                {
                    Id = request.Id,
                    StudentId = request.StudentId,
                    CourseId = request.CourseId

                };


                await _context.StudentCourses.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);




                return entity.Id;
            }

        }
    }
}