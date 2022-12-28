using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Student.Commands.Delete
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class Handler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public Handler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Courses.Where(a => a.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

                if (entity is null)
                    throw new DirectoryNotFoundException($"CourseCategory Not Found With {request.Id}");

                _context.Courses.Remove(entity);
                int result = await _context.SaveChangesAsync(cancellationToken);

                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
    }
}
