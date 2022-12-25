using Application.Features.CoursesCategory.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.CoursesCategory.Commands.Update
{
    public class UpdateCourseCategoryCommand : CourseCategoryDTO, IRequest<int>
  {
    public UpdateCourseCategoryCommand()
    { }


    public UpdateCourseCategoryCommand(CourseCategoryDTO dto)
    {
      Id = dto.Id;

      Name = dto.Name;
      



    }
    public class Handler : IRequestHandler<UpdateCourseCategoryCommand, int>
    {
      private readonly IApplicationDbContext _context;
      public Handler(IApplicationDbContext context)
      {

        _context = context;
      }
      public async Task<int> Handle(UpdateCourseCategoryCommand request, CancellationToken cancellationToken)
      {
        Domain.Entities.Course entity = new Domain.Entities.Course
        {
          Id = request.Id,

          Name = request.Name
        

        };


        _context.Courses.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);




        return entity.Id;
      }

    }
  }

}