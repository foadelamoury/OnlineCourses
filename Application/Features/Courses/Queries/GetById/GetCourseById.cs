using Application.Features.Courses.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Courses.Queries.GetById
{
    public class GetCourseById : IRequest<CourseDTO>
  {
    public int Id { get; set; }
  }
  public class Handler : IRequestHandler<GetCourseById, CourseDTO>
  {
    private readonly IApplicationDbContext _context;
    public Handler(IApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<CourseDTO> Handle(GetCourseById request, CancellationToken cancellationToken)
    {
      var country = await _context.Countries.Where(x => x.Id == request.Id).Select(x => new CourseDTO
      {
        Id = x.Id,
       NameA = x.NameA,NameE = x.NameE,
        SortIndex = x.SortIndex,
        Focus = x.Focus,
        Active = x.Active
      }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

      return country;
    }
  }
}
