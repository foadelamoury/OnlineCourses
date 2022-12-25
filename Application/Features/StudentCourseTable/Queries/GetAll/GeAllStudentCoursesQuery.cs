using Application.Features.StudentCourseTable.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.StudentCourseTable.Queries.GetAll
{
    public class GeAllStudentCoursesQuery : IRequest<IEnumerable<StudentCourseDTO>>
  {
    public class Handler : IRequestHandler<GeAllStudentCoursesQuery, IEnumerable<StudentCourseDTO>>
    {

      private readonly IApplicationDbContext _context;
      public Handler(IApplicationDbContext context)
      {
        _context = context;
      }
      public async Task<IEnumerable<StudentCourseDTO>> Handle(GeAllStudentCoursesQuery request, CancellationToken cancellationToken)
      {
        var countries = await _context.StudentCourses.Select(x =>
              new StudentCourseDTO
              {
                Id = x.Id,
                CourseId = x.CourseId,
                StudentId = x.StudentId,
                SortIndex = x.SortIndex,
                Focus = x.Focus,
                Active = x.Active

              }
          ).ToListAsync();

        return countries;
      }
    }
  }

}