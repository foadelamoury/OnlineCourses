using Application.Features.Country.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Country.Queries.GetById
{
    public class GetCountryById : IRequest<CountryDTO>
    {
        public int Id { get; set; }
    }
    public class Handler : IRequestHandler<GetCountryById, CountryDTO>
    {
        private readonly IApplicationDbContext _context;
        public Handler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CountryDTO> Handle(GetCountryById request, CancellationToken cancellationToken)
        {
            var country = await _context.Countries.Where(x => x.Id == request.Id).Select(x => new CountryDTO
            {
                Id = x.Id,
                Name = x.Name,
                SortIndex = x.SortIndex,
                Focus = x.Focus,
                Active = x.Active
            }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return country;
        }
    }
}
