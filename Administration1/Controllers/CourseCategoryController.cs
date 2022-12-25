using Application.Features.CoursesCategory.Commands.Delete;
using Application.Features.CoursesCategory.Commands.Update;
using Application.Features.CoursesCategory.Models;
using Application.Features.CoursesCategory.Queries.GetAll;
using Application.Features.CoursesCategory.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class CourseCategoryController : Controller
{
    #region CTOR

    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IMediator _mediator;


    public CourseCategoryController(IWebHostEnvironment webHostEnvironment, IMediator mediator)
    {
        _webHostEnvironment = webHostEnvironment;
        _mediator = mediator;
    }


    #endregion

    #region Index
    public async Task<IActionResult> Index()
    {
        IEnumerable<CourseCategoryDTO> Countries = (IEnumerable<CourseCategoryDTO>)await _mediator.Send(new GetAllCourseCategoriesQuery());
        return View(Countries);
    }


    #endregion

    #region Create
    public async Task<IActionResult> Create()
    {
        return PartialView("Form", new CourseCategoryObjectDTO());
    }
    #endregion

    #region Edit
    public async Task<IActionResult> Edit(int id)
    {
        CourseCategoryDTO CourseCategoryDTO = await _mediator.Send(new GetCourseCategoryByIdQuery() { Id = id });

        return PartialView("Form", CourseCategoryDTO);
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



    public async Task<JsonResult> Delete(int id)
    {
        string response = "OK";

        try
        {
            int res = await _mediator.Send(new DeleteCourseCategoryCommand() { Id = id });
        }
        catch (Exception ex)
        { throw; }
        return null;
    }
    #endregion

    #region Detail
    public async Task<IActionResult> Details(int id)
    {
        var eventDTO = await _mediator.Send(new GetCourseCategoryByIdQuery() { Id = id });
        return View(eventDTO);
    }
    #endregion

    #region Activate

    public async Task<JsonResult> Activate(long[] Ids)
    {
        try
        {
            foreach (var item in Ids)
            {
                var entity = await _mediator.Send(new GetCourseCategoryByIdQuery() { Id = (int)item });

                await _mediator.Send(new UpdateCourseCategoryCommand(entity));
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        return null;
    }
    #endregion




}