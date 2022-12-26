using Application.Features.Student.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Student.Commands.Create
{
    public class CreateStudentCommand : StudentDTO, IRequest<int>
  {
    public CreateStudentCommand()
    { }


    public CreateStudentCommand(StudentDTO dto)
    {
      NameA = dto.NameA;NameE = dto.NameE;
      Id = dto.Id;

    }
    public class Handler : IRequestHandler<CreateStudentCommand, int>
    {
      private readonly IApplicationDbContext _context;
      public Handler(IApplicationDbContext context)
      {

        _context = context;
      }
      public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
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

