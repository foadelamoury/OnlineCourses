using Application.Features.City.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.City.Commands.Create;
public class CreateCityCommand : CityDTO, IRequest<int>
{
    public CreateCityCommand()
    { }


    public CreateCityCommand(CityDTO dto)
    {
        Name = dto.Name;
        CountryId = dto.CountryId;
        Id = dto.Id;

    }
    public class Handler : IRequestHandler<CreateCityCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public Handler(IApplicationDbContext context)
        {

            _context = context;
        }
        public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.City entity = new Domain.Entities.City
            {
                Name = request.Name,
                CountryId = request.CountryId,
                Id = request.Id,


            };


            await _context.Cities.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);




            return entity.Id;
        }

    }
}

