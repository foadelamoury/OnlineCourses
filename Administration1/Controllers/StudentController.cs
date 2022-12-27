using Application.Features.Student.Commands.Create;
using Application.Features.Student.Commands.Update;
using Application.Features.Student.Models;
using Application.Features.Student.Queries.GetAll;
using Application.Features.Student.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        IEnumerable<StudentDTO> Countries = await _mediator.Send(new GetAllStudentsQuery());
        return View(Countries);
    }


    #endregion

    #region Create
    public ActionResult Create()
    {
        return PartialView("Form", new StudentDTO { Active = true, CreateDate = DateTime.Now });
    }
    #endregion

    #region Edit
    public async Task<IActionResult> Edit(int id)
    {
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
            var command = new UpdateStudentCommand(model);
            await _mediator.Send(command);

            //return View("form", command.Id);



        }

        else
        {
            var command = new CreateStudentCommand(model);
            await _mediator.Send(command);


        }
        return RedirectToAction("Index");

    }

    #endregion


    #region Delete



    //public async Task<JsonResult> Delete(int id)
    //{
    //    //string response = "OK";

    //    try
    //    {
    //        int res = await _mediator.Send(new DeleteStudentCommand() { Id = id });
    //    }
    //    catch
    //    { throw; }
    //    return null;
    //}
    //#endregion

    //#region Detail
    //public async Task<IActionResult> Details(int id)
    //{
    //    var eventDTO = await _mediator.Send(new GetStudentByIdQuery() { Id = id });
    //    return View(eventDTO);
    //}
    #endregion

    #region Activate

    //public async Task<JsonResult> Activate(long[] Ids)
    //{
    //    try
    //    {
    //        foreach (var item in Ids)
    //        {
    //            var entity = await _mediator.Send(new GetStudentByIdQuery() { Id = (int)item });

    //            await _mediator.Send(new UpdateStudentCommand(entity));
    //        }
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //    return null;
    //}
    #endregion
}