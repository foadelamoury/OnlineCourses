using Application.Features.Country.Commands.Update;
using Application.Features.Country.Models;
using Application.Features.Courses.Models;
using Application.Features.CoursesCategory.Models;
using Application.Interfaces;
using MediatR;
using System.Xml.Linq;

namespace Application.Features.Courses.Commands.Update
{
    public class UpdateCourseCommand : CourseDTO, IRequest<long>
    {
        public UpdateCourseCommand()
        { }


        public UpdateCourseCommand(CourseDTO dto)
        {
            Id = dto.Id;

            NameA = dto.NameA;NameE = dto.NameE;
            CreditHours= dto.CreditHours;

            CourseCategoryId = dto.CourseCategoryId;



    }
        public class Handler : IRequestHandler<UpdateCourseCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {

                _context = context;
            }
            public async Task<long> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Course entity = new Domain.Entities.Course
                {
                 Id = request.Id,

                NameA = request.NameA,
                NameE = request.NameE,
                CreditHours = request.CreditHours,

                CourseCategoryId = request.CourseCategoryId

            };


                _context.Courses.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);




                return (long)entity.Id;
            }

        }
    }

}