using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.StudentCourseTable.Commands.Delete
{
    public class DeleteStudentCourseCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class Handler : IRequestHandler<DeleteStudentCourseCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public Handler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteStudentCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Courses.Where(a => a.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

                if (entity is null)
                    throw new DirectoryNotFoundException($"StudentCourse Not Found With {request.Id}");

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
