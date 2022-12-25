using Application.Features.Student.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.StudentCourseTable.Commands.Update
{
    public class UpdateStudentCommand : StudentDTO, IRequest<int>
  {
    public UpdateStudentCommand()
    { }


    public UpdateStudentCommand(StudentDTO dto)
    {
      Name = dto.Name;
      Id = dto.Id;

    }
    public class Handler : IRequestHandler<UpdateStudentCommand, int>
    {
      private readonly IApplicationDbContext _context;
      public Handler(IApplicationDbContext context)
      {

        _context = context;
      }
      public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
      {
        Domain.Entities.Country entity = new Domain.Entities.Country
        {
          Id = request.Id,

          Name = request.Name

        };


        await _context.Countries.AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);




        return entity.Id;
      }

    }
  }
}