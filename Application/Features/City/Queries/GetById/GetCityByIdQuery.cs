using Application.Features.City.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.City.Queries.GetById
{
    public class GetCityByIdQuery : IRequest<CityDTO>
    {
        public int Id { get; set; }
    }
    public class Handler : IRequestHandler<GetCityByIdQuery, CityDTO>
    {
        private readonly IApplicationDbContext _context;
        public Handler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CityDTO> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var obj = await _context.Cities.Where(x => x.Id == request.Id).Select(x => new CityDTO
            {
                Id = x.Id,
                Name = x.Name,
                CountryId = x.CountryId,
                SortIndex = x.SortIndex,
                Focus = x.Focus,
                Active = x.Active
            }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return obj;
        }
    }
}
