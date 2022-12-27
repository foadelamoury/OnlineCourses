using Application.Features.CoursesCategory.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.CoursesCategory.Commands.Update
{
    public class UpdateCourseCategoryCommand : CourseCategoryDTO, IRequest<long>
    {
        public UpdateCourseCategoryCommand()
        { }


        public UpdateCourseCategoryCommand(CourseCategoryDTO dto)
        {
            Id = dto.Id;

            NameA = dto.NameA; NameE = dto.NameE;




        }
        public class Handler : IRequestHandler<UpdateCourseCategoryCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {

                _context = context;
            }
            public async Task<long> Handle(UpdateCourseCategoryCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Course entity = new Domain.Entities.Course
                {
                    Id = request.Id,

                    NameA = request.NameA,
                    NameE = request.NameE


                };


                _context.Courses.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);




                return entity.Id;
            }

        }
    }

}