using Application.Features.Country.Models;
using Application.Features.Country.Queries.GetAll;
using Application.Features.Student.Commands.Create;
using Application.Features.Student.Commands.Delete;
using Application.Features.Student.Commands.Update;
using Application.Features.Student.Models;
using Application.Features.Student.Queries.GetAll;
using Application.Features.Student.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Administration1.Controllers;

public class StudentController : Controller
{
    #region CTOR

    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IMediator _mediator;


    public StudentController(IWebHostEnvironment webHostEnvironment, IMediator mediator)
    {
        _webHostEnvironment = webHostEnvironment;
        _mediator = mediator;
    }


    #endregion

    #region Index
    public async Task<IActionResult> Index()
    {
        IEnumerable<StudentDTO> Students = await _mediator.Send(new GetAllStudentsQuery());
        return View(Students);
    }


    #endregion

    #region Create
    public ActionResult Create()
    {
        ViewBag.Countries =  _mediator.Send(new GetAllCountryQuery() { parentId = 0 });

        ViewBag.Cities =  _mediator.Send(new GetAllCountryQuery() { parentId = 1 });
        return PartialView("Form", new StudentDTO { Active = true, CreateDate = DateTime.Now });
    }
    #endregion

    #region Edit
    public async Task<IActionResult> Edit(long id)
    {
        ViewBag.Countries = await _mediator.Send(new GetAllCountryQuery() { parentId = 0 });

        ViewBag.Cities = await _mediator.Send(new GetAllCountryQuery() { parentId = 1 });


        StudentDTO studentDTO = await _mediator.Send(new GetStudentByIdQuery() { Id = id });

        


        return PartialView("Form", studentDTO);
    }
    #endregion

    #region Form
    [HttpPost]
    public async Task<IActionResult> Form(StudentDTO model)
    {
        if (model.Id > 0)
        {
            ViewBag.Countries = await _mediator.Send(new GetAllCountryQuery() { parentId = 0 });

            ViewBag.Cities = await _mediator.Send(new GetAllCountryQuery() { parentId = 1 });
            var command = new UpdateStudentCommand(model);
            await _mediator.Send(command);

            return View("form", command);



        }

        else
        {
            ViewBag.Countries = await _mediator.Send(new GetAllCountryQuery() { parentId = 0 });

            ViewBag.Cities = await _mediator.Send(new GetAllCountryQuery() { parentId = 1 });
            var command = new CreateStudentCommand(model);
            await _mediator.Send(command);
            return RedirectToAction("Index");


        }

    }

    #endregion

    #region Details
    public async Task<IActionResult> Details(int id)
    {
        var eventDTO = await _mediator.Send(new GetStudentByIdQuery() { Id = id });
        return View(eventDTO);
    }
    #endregion


    #region Delete



    public async Task<int> Delete(int id)
    {
        int res = 0;
        try
        {
            res = await _mediator.Send(new DeleteStudentCommand() { Id = id });
        }
        catch
        { throw; }
        return 1;
    }
    #endregion



    #region Activate

    public async Task<int> Activate(long[] Ids)
    {
        try
        {
            foreach (var item in Ids)
            {
                var entity = await _mediator.Send(new GetStudentByIdQuery() { Id = (int)item });
                if (entity.Active == true) entity.Active = false;
                else if (entity.Active == false) entity.Active = true;

                await _mediator.Send(new UpdateStudentCommand(entity));
            }
        }
        catch
        {
            throw;
        }
        return 1;
    }
    #endregion
}