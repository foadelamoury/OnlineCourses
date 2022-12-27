using Application.Features.Courses.Commands.Create;
using Application.Features.Courses.Commands.Update;
using Application.Features.Courses.Models;
using Application.Features.Courses.Queries.GetAll;
using Application.Features.Courses.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace Administration1.Controllers;

public class CourseController : Controller
{
    #region CTOR

    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IMediator _mediator;


    public CourseController(IWebHostEnvironment webHostEnvironment, IMediator mediator)
    {
        _webHostEnvironment = webHostEnvironment;
        _mediator = mediator;
    }


    #endregion

    #region Index
    public async Task<IActionResult> Index()
    {
        IEnumerable<CourseDTO> Course = await _mediator.Send(new GetAllCoursesQuery());
        return View(Course);
    }


    #endregion

    #region Create
    public ActionResult Create()
    {
        return PartialView("Form", new CourseDTO { Active = true, CreateDate = DateTime.Now });
    }
    #endregion

    #region Edit
    public async Task<IActionResult> Edit(long id)
    {
        CourseDTO courseDTO = await _mediator.Send(new GetCourseByIdQuery() { Id = id });


        return PartialView("Form", courseDTO);
    }
    #endregion

    #region Form
    [HttpPost]
    public async Task<IActionResult> Form(CourseDTO model)
    {
        if (model.Id > 0)
        {
            var command = new UpdateCourseCommand(model);
            await _mediator.Send(command);
            return View("form", command);




        }

        else
        {
            var command = new CreateCourseCommand(model);
            await _mediator.Send(command);
            return RedirectToAction("Index");


        }

    }

    #endregion


    #region Delete



    //public async Task<JsonResult> Delete(int id)
    //{
    //    //string response = "OK";

    //    try
    //    {
    //        int res = await _mediator.Send(new DeleteCourseCommand() { Id = id });
    //    }
    //    catch
    //    { throw; }
    //    return null;
    //}
    #endregion

    #region Details
    public async Task<IActionResult> Details(int id)
    {
        var eventDTO = await _mediator.Send(new GetCourseByIdQuery() { Id = id });
        return View(eventDTO);
    }
    #endregion

    #region Activate

    public async Task<int> Activate(long[] Ids)
    {
        try
        {
            foreach (var item in Ids)
            {
                var entity = await _mediator.Send(new GetCourseByIdQuery() { Id = (int)item });

                entity.Active = !entity.Active;
                await _mediator.Send(new UpdateCourseCommand(entity));
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