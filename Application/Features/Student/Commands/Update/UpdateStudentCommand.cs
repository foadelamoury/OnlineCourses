using Application.Features.Student.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Student.Commands.Update
{
    public class UpdateStudentCommand : StudentDTO, IRequest<long>
    {
        public UpdateStudentCommand()
        { }


        public UpdateStudentCommand(StudentDTO dto)
        {
            NameA = dto.NameA;
            NameE = dto.NameE;
            Id = dto.Id;

        }
        public class Handler : IRequestHandler<UpdateStudentCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {

                _context = context;
            }
            public async Task<long> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Student entity = new Domain.Entities.Student
                {
                    Id = request.Id,

                    NameA = request.NameA,
                    NameE = request.NameE,
                    PhotoName = request.photoFile?.FileName  

                };


                await _context.Students.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);




                return entity.Id;
            }

        }
    }
}