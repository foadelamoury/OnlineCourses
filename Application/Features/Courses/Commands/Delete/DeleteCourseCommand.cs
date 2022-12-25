using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Courses.Commands.Delete
{
    public class DeleteCourseCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class Handler : IRequestHandler<DeleteCourseCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public Handler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Courses.Where(a => a.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

                if (entity is null)
                    throw new DirectoryNotFoundException($"Course Not Found With {request.Id}");

                _context.Courses.Remove(entity);
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

