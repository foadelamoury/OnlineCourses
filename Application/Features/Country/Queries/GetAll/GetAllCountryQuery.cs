using Application.Features.Country.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Country.Queries.GetAll
{
    public class GetAllCityQuery : IRequest<IEnumerable<CountryDTO>>
    {
        public class Handler : IRequestHandler<GetAllCityQuery, IEnumerable<CountryDTO>>
        {

            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<CountryDTO>> Handle(GetAllCityQuery request, CancellationToken cancellationToken)
            {
                var countries = await _context.Countries.Select(x =>
                      new CountryDTO
                      {
                          Id = x.Id,
                          Name = x.Name,
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
