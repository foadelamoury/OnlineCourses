using Application.Features.Country.Commands.Create;
using Application.Features.Courses.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Courses.Commands.Create
{
    public class CreateCourseCommand : CourseDTO, IRequest<int>
    {
        public CreateCourseCommand()
        { }


        public CreateCourseCommand(CourseDTO dto)
        {
            Name = dto.Name;
            Id = dto.Id;
            CreditHours = dto.CreditHours;

            CourseCategoryId = dto.CourseCategoryId;

        }
        public class Handler : IRequestHandler<CreateCourseCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {

                _context = context;
            }
            public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Course entity = new Domain.Entities.Course
                {
                    Id = request.Id,

                    Name = request.Name,
                    CreditHours = request.CreditHours,

                    CourseCategoryId = request.CourseCategoryId,

                };


                await _context.Courses.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);




                return entity.Id;
            }

        }
    }
}

