using Application.Features.Country.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Application.Features.Country.Queries.GetAll
{
    public class GetAllCountryQuery : IRequest<List<CountryDTO>>
    {
        public int parentId { get; set; }
        public GetAllCountryQuery()
        {
            
        }

        public class Handler : IRequestHandler<GetAllCountryQuery, List<CountryDTO>>
        {

            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }
#pragma warning disable CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
            public async Task<List<CountryDTO>?> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
            {
                if (request.parentId == 0 || request.parentId == 1)
                {
                    var countries = await _context.Countries.Where(x => x.ParentId.Equals(request.parentId)).Select(x =>
                  new CountryDTO
                  {
                      Id = x.Id,
                      NameA = x.NameA,
                      NameE = x.NameE,
                      SortIndex = x.SortIndex,
                      Focus = x.Focus,
                      Active = x.Active

                  }
                    ).ToListAsync();
                    return countries;
                }
                else
                {
                    var countries = await _context.Countries.Where(x => x.ParentId.Equals(request.parentId)).Select(x =>
                  new CountryDTO
                  {
                      Id = x.Id,
                      NameA = x.NameA,
                      NameE = x.NameE,
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

}
