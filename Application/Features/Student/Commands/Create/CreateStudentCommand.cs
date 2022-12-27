using Application.Features.Student.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Student.Commands.Create
{
    public class CreateStudentCommand : StudentDTO, IRequest<long>
  {
    public CreateStudentCommand()
    { }


    public CreateStudentCommand(StudentDTO dto)
    {
      NameA = dto.NameA;NameE = dto.NameE;
      Id = dto.Id;

    }
    public class Handler : IRequestHandler<CreateStudentCommand, long>
    {
      private readonly IApplicationDbContext _context;
      public Handler(IApplicationDbContext context)
      {

        _context = context;
      }
      public async Task<long> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
      {
        Domain.Entities.Country entity = new Domain.Entities.Country
        {
          Id = request.Id,

          NameA = request.NameA,NameE = request.NameE

        };


        await _context.Countries.AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);




        return entity.Id;
      }

    }
  }
}

