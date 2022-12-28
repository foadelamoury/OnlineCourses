using Application.Common.Interfaces;
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
            NameA = dto.NameA;
            NameE = dto.NameE;
            Id = dto.Id;

        }
        public class Handler : IRequestHandler<CreateStudentCommand, long>
        {
            private readonly IApplicationDbContext _context;
            private readonly IFileUploadHelper _uploadHelper;

            public Handler(IApplicationDbContext context, IFileUploadHelper uploadHelper)
            {

                _context = context;
                _uploadHelper = uploadHelper;
            }
            public async Task<long> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Student entity = new Domain.Entities.Student
                {
                    Id = request.Id,

                    NameA = request.NameA,
                    NameE = request.NameE,
                    PhotoName = request.photoFile?.FileName


                };

                if (request.photoFile != null)
                    await _uploadHelper.Upload(request.photoFile, entity.Id.ToString(), "Governer", "Resume");

                await _context.Students.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);


                return entity.Id;
            }

        }
    }
}

