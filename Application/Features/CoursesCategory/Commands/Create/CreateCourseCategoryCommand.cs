using Application.Features.Courses.Commands.Create;
using Application.Features.Courses.Models;
using Application.Features.CoursesCategory.Models;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Xml.Linq;

namespace Application.Features.CoursesCategory.Commands.Create
{
    public class CreateCourseCategoryCommand : CourseCategoryDTO, IRequest<int>
    {
        public CreateCourseCategoryCommand()
        { }


        public CreateCourseCategoryCommand(CourseCategoryDTO dto)
        {
            Name = dto.Name;
            Id = dto.Id;


        }
        public class Handler : IRequestHandler<CreateCourseCategoryCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {

                _context = context;
            }
            public async Task<int> Handle(CreateCourseCategoryCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.CourseCategory entity = new Domain.Entities.CourseCategory
                {
                    Id = request.Id,

                    Name = request.Name,


                };


                await _context.CourseCategories.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);




                return entity.Id;
            }

        }
    }
}

