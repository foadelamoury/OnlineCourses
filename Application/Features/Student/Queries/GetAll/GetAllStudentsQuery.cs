using Application.Features.Student.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Student.Queries.GetAll
{
    public class GetAllStudentsQuery : IRequest<IEnumerable<StudentDTO>>
  {
    public class Handler : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDTO>>
    {

      private readonly IApplicationDbContext _context;
      public Handler(IApplicationDbContext context)
      {
        _context = context;
      }
      public async Task<IEnumerable<StudentDTO>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
      {
        var countries = await _context.Countries.Select(x =>
              new StudentDTO
              {
                Id = x.Id,
               NameA = x.NameA,NameE = x.NameE,
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