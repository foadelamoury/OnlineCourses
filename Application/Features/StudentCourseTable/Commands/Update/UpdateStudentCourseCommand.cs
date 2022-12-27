using Application.Features.Student.Models;
using Application.Features.StudentCourseTable.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.StudentCourseTable.Commands.Update
{
    public class UpdateStudentCourseCommand : StudentCourseDTO, IRequest<int>
  {
    public UpdateStudentCourseCommand()
    { }


    public UpdateStudentCourseCommand(StudentCourseDTO dto)
    {
      Id = dto.Id;

    }
    public class Handler : IRequestHandler<UpdateStudentCourseCommand, int>
    {
      private readonly IApplicationDbContext _context;
      public Handler(IApplicationDbContext context)
      {

        _context = context;
      }
      public async Task<int> Handle(UpdateStudentCourseCommand request, CancellationToken cancellationToken)
      {
        Domain.Entities.StudentCourse entity = new Domain.Entities.StudentCourse
        {
          Id = request.Id,


        };


        await _context.StudentCourses.AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);




        return entity.Id;
      }

    }
  }
}