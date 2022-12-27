using Application.Features.StudentCourseTable.Commands.Create;
using Application.Features.StudentCourseTable.Commands.Update;
using Application.Features.StudentCourseTable.Models;
using Application.Features.StudentCourseTable.Queries.GetAll;
using Application.Features.StudentCourseTable.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Administration1.Controllers;

public class StudentCourseController : Controller
{
    #region CTOR

    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IMediator _mediator;


    public StudentCourseController(IWebHostEnvironment webHostEnvironment, IMediator mediator)
    {
        _webHostEnvironment = webHostEnvironment;
        _mediator = mediator;
    }


    #endregion

    #region Index
    public async Task<IActionResult> Index()
    {
        IEnumerable<StudentCourseDTO> Countries = await _mediator.Send(new GeAllStudentCoursesQuery());
        return View(Countries);
    }


    #endregion

    #region Create
    public ActionResult Create()
    {
        return PartialView("Form", new StudentCourseDTO { Active = true, CreateDate = DateTime.Now });
    }
    #endregion

    #region Edit
    public async Task<IActionResult> Edit(int id)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        StudentCourseDTO countryDTO = await _mediator.Send(new GetStudentCourseById() { Id = id });
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.


        return PartialView("Form", countryDTO);
    }
    #endregion

    #region Form
    [HttpPost]
    public async Task<IActionResult> Form(StudentCourseDTO model)
    {
        if (model.Id > 0)
        {
            var command = new UpdateStudentCourseCommand(model);
            await _mediator.Send(command);

            //return View("form", command.Id);



        }

        else
        {
            var command = new CreateStudentCourseCommand(model);
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
    //        int res = await _mediator.Send(new DeleteStudentCourseCommand() { Id = id });
    //    }
    //    catch
    //    { throw; }
    //    return null;
    //}
    //#endregion

    //#region Detail
    //public async Task<IActionResult> Details(int id)
    //{
    //    var eventDTO = await _mediator.Send(new GetStudentCourseByIdQuery() { Id = id });
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
    //            var entity = await _mediator.Send(new GetStudentCourseByIdQuery() { Id = (int)item });

    //            await _mediator.Send(new UpdateStudentCourseCommand(entity));
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