using Application.Features.CoursesCategory.Queries.GetAll;
using Application.Features.CoursesCategory.Commands.Create;
using Application.Features.CoursesCategory.Commands.Update;
using Application.Features.CoursesCategory.Models;
using Application.Features.CoursesCategory.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Administration1.Controllers;

public class CourseCategoryCategoryController : Controller
{
    #region CTOR

    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IMediator _mediator;


    public CourseCategoryCategoryController(IWebHostEnvironment webHostEnvironment, IMediator mediator)
    {
        _webHostEnvironment = webHostEnvironment;
        _mediator = mediator;
    }


    #endregion

    #region Index
    public async Task<IActionResult> Index()
    {
        IEnumerable<CourseCategoryDTO> Countries = await _mediator.Send(new GetAllCourseCategoriesQuery());
        return View(Countries);
    }


    #endregion

    #region Create
    public ActionResult Create()
    {
        return PartialView("Form", new CourseCategoryDTO { Active = true, CreateDate = DateTime.Now });
    }
    #endregion

    #region Edit
    public async Task<IActionResult> Edit(int id)
    {
        CourseCategoryDTO courseCategoryDTO = await _mediator.Send(new GetCourseCategoryByIdQuery() { Id = id });


        return PartialView("Form", courseCategoryDTO);
    }
    #endregion

    #region Form
    [HttpPost]
    public async Task<IActionResult> Form(CourseCategoryDTO model)
    {
        if (model.Id > 0)
        {
            var command = new UpdateCourseCategoryCommand(model);
            await _mediator.Send(command);

            //return View("form", command.Id);



        }

        else
        {
            var command = new CreateCourseCategoryCommand(model);
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
    //        int res = await _mediator.Send(new DeleteCourseCategoryCommand() { Id = id });
    //    }
    //    catch
    //    { throw; }
    //    return null;
    //}
    //#endregion

    //#region Detail
    //public async Task<IActionResult> Details(int id)
    //{
    //    var eventDTO = await _mediator.Send(new GetCourseCategoryByIdQuery() { Id = id });
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
    //            var entity = await _mediator.Send(new GetCourseCategoryByIdQuery() { Id = (int)item });

    //            await _mediator.Send(new UpdateCourseCategoryCommand(entity));
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