using Application.Features.City.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.City.Queries.GetAll;

public class GetAllCityQuery : IRequest<IEnumerable<CityDTO>>
{
    public class Handler : IRequestHandler<GetAllCityQuery, IEnumerable<CityDTO>>
    {

        private readonly IApplicationDbContext _context;
        public Handler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CityDTO>> Handle(GetAllCityQuery request, CancellationToken cancellationToken)
        {
            var cities = await _context.Cities.Select(x =>
                  new CityDTO
                  {
                      Id = x.Id,
                      Name = x.Name,
                      CountryId = x.CountryId,
                      SortIndex = x.SortIndex,
                      Focus = x.Focus,
                      Active = x.Active

                  }
              ).ToListAsync();

            return cities;
        }
    }
}


