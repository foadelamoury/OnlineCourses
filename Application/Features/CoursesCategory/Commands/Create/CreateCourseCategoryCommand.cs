using Application.Features.Courses.Commands.Create;
using Application.Features.Courses.Models;
using Application.Features.CoursesCategory.Models;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Xml.Linq;

namespace Application.Features.CoursesCategory.Commands.Create
{
    public class CreateCourseCategoryCommand : CourseCategoryDTO, IRequest<long>
    {
        public CreateCourseCategoryCommand()
        { }


        public CreateCourseCategoryCommand(CourseCategoryDTO dto)
        {
            NameA = dto.NameA;NameE = dto.NameE;
            Id = dto.Id;


        }
        public class Handler : IRequestHandler<CreateCourseCategoryCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {

                _context = context;
            }
            public async Task<long> Handle(CreateCourseCategoryCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.CourseCategory entity = new Domain.Entities.CourseCategory
                {
                    Id = request.Id,

                    NameA = request.NameA,NameE = request.NameE,


                };


                await _context.CourseCategories.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);




                return entity.Id;
            }

        }
    }
}

