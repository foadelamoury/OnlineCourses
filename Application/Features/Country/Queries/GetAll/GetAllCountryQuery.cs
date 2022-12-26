using Application.Features.Country.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Country.Queries.GetAll
{
    public class GetAllCountryQuery : IRequest<IEnumerable<CountryDTO>>
    {
        public GetAllCountryQuery()
        {
        }

        public class Handler : IRequestHandler<GetAllCountryQuery, IEnumerable<CountryDTO>>
        {

            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<CountryDTO>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
            {
                var countries = await _context.Countries.Select(x =>
                      new CountryDTO
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
