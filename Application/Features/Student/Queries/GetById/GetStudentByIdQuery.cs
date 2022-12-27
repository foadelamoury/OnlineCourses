using Application.Features.Student.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Student.Queries.GetById
{
    public class GetStudentByIdQuery : IRequest<StudentDTO>
  {
    public long Id { get; set; }
  }
  public class Handler : IRequestHandler<GetStudentByIdQuery, StudentDTO>
  {
    private readonly IApplicationDbContext _context;
    public Handler(IApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<StudentDTO> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
      var country = await _context.Countries.Where(x => x.Id == request.Id).Select(x => new StudentDTO
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
