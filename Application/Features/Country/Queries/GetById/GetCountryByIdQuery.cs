using Application.Features.Country.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Country.Queries.GetById
{
    public class GetCountryByIdQuery : IRequest<CountryDTO?>
    {
        public long Id { get; set; }
    }
    public class Handler : IRequestHandler<GetCountryByIdQuery, CountryDTO?>
    {
        private readonly IApplicationDbContext _context;
        public Handler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CountryDTO?> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            var country = await _context.Countries.Where(x => x.Id == request.Id).Select(x => new CountryDTO
            {
                Id = x.Id,
                NameA = x.NameA,
                NameE = x.NameE,
                SortIndex = x.SortIndex,
                Focus = x.Focus,
                Active = x.Active
            }).FirstOrDefaultAsync(cancellationToken: cancellationToken);
#pragma warning restore CS8601 // Possible null reference assignment.

            return country;
        }
    }
}
