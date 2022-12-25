using Application.Features.Country.Commands.Update;
using Application.Features.Country.Models;
using Application.Features.Courses.Models;
using Application.Features.CoursesCategory.Models;
using Application.Interfaces;
using MediatR;
using System.Xml.Linq;

namespace Application.Features.Courses.Commands.Update
{
    public class UpdateCourseCommand : CourseDTO, IRequest<int>
    {
        public UpdateCourseCommand()
        { }


        public UpdateCourseCommand(CourseDTO dto)
        {
            Id = dto.Id;

            Name = dto.Name;
            CreditHours= dto.CreditHours;

            CourseCategoryId = dto.CourseCategoryId;



    }
        public class Handler : IRequestHandler<UpdateCourseCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {

                _context = context;
            }
            public async Task<int> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Course entity = new Domain.Entities.Course
                {
                 Id = request.Id,

                Name = request.Name,
                CreditHours = request.CreditHours,

                CourseCategoryId = request.CourseCategoryId

            };


                _context.Courses.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);




                return entity.Id;
            }

        }
    }

}