using Application.Features.Courses.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Courses.Queries.GetById
{
    public class GetCourseByIdQuery : IRequest<CourseDTO>
  {
    public int Id { get; set; }
  }
  public class Handler : IRequestHandler<GetCourseByIdQuery, CourseDTO>
  {
    private readonly IApplicationDbContext _context;
    public Handler(IApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<CourseDTO> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
#pragma warning disable CS8601 // Possible null reference assignment.
            var country = await _context.Countries.Where(x => x.Id == request.Id).Select(x => new CourseDTO
      {
        Id = x.Id,
       NameA = x.NameA,NameE = x.NameE,
        SortIndex = x.SortIndex,
        Focus = x.Focus,
        Active = x.Active
      }).FirstOrDefaultAsync(cancellationToken: cancellationToken);
#pragma warning restore CS8601 // Possible null reference assignment.

#pragma warning disable CS8603 // Possible null reference return.
            return country;
#pragma warning restore CS8603 // Possible null reference return.
        }
  }
}
