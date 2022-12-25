using Application.Features.City.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.City.Commands.Update;

public class UpdateCityCommand : CityDTO, IRequest<int>
{
    public UpdateCityCommand()
    { }


    public UpdateCityCommand(CityDTO dto)
    {
        Id = dto.Id;

        Name = dto.Name;
        CountryId = dto.CountryId;

    }
    public class Handler : IRequestHandler<UpdateCityCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public Handler(IApplicationDbContext context)
        {

            _context = context;
        }
        public async Task<int> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.City entity = new Domain.Entities.City
            {
                Name = request.Name,
                CountryId = request.CountryId,
                Id = request.Id,

            };


            _context.Cities.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);




            return entity.Id;
        }

    }
}

