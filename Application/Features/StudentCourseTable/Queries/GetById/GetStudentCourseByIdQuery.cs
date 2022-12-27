using Application.Features.StudentCourseTable.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.StudentCourseTable.Queries.GetById
{
    public class GetStudentCourseByIdQuery : IRequest<StudentCourseDTO?>
    {
        public long Id { get; set; }
    }
    public class Handler : IRequestHandler<GetStudentCourseByIdQuery, StudentCourseDTO?>
    {
        private readonly IApplicationDbContext _context;
        public Handler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<StudentCourseDTO?> Handle(GetStudentCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await _context.StudentCourses.Where(x => x.Id == request.Id).Select(x => new StudentCourseDTO
            {
                Id = x.Id,
                StudentId = x.StudentId,
                CourseId = x.CourseId,
                SortIndex = x.SortIndex,
                Focus = x.Focus,
                Active = x.Active
            }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return country;
        }
    }
}
