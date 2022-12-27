using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Country.Commands.Delete
{
    public class DeleteCountryCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class Handler : IRequestHandler<DeleteCountryCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public Handler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Countries.Where(a => a.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

                if (entity is null)
                    throw new DirectoryNotFoundException($"Country Not Found With {request.Id}");

                _context.Countries.Remove(entity);
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

