using Application.Features.Country.Commands.Create;
using Application.Features.Courses.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Courses.Commands.Create
{
    public class CreateCourseCommand : CourseDTO, IRequest<long>
    {
        public CreateCourseCommand()
        { }


        public CreateCourseCommand(CourseDTO dto)
        {
            NameA = dto.NameA;NameE = dto.NameE;
            Id = dto.Id;
            CreditHours = dto.CreditHours;

            CourseCategoryId = dto.CourseCategoryId;

        }
        public class Handler : IRequestHandler<CreateCourseCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {

                _context = context;
            }
            public async Task<long> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Course entity = new Domain.Entities.Course
                {
                    Id = request.Id,

                    NameA = request.NameA,NameE = request.NameE,
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

