using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.City.Commands.Delete
{
    public class DeleteCityCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class Handler : IRequestHandler<DeleteCityCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public Handler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Cities.Where(a => a.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

                if (entity is null)
                    throw new DirectoryNotFoundException($"City Not Found With {request.Id}");

                _context.Cities.Remove(entity);
                int result = await _context.SaveChangesAsync(cancellationToken);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

