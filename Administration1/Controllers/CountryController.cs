using Application.Features.Country.Commands.Create;
using Application.Features.Country.Commands.Delete;
using Application.Features.Country.Commands.Update;
using Application.Features.Country.Models;
using Application.Features.Country.Queries.GetAll;
using Application.Features.Country.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace Administration1.Controllers;

public class CountryController : Controller
{
    #region CTOR

    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IMediator _mediator;


    public CountryController(IWebHostEnvironment webHostEnvironment, IMediator mediator)
    {
        _webHostEnvironment = webHostEnvironment;
        _mediator = mediator;
    }


    #endregion

    #region Index
    public async Task<IActionResult> Index()
    {
        IEnumerable<CountryDTO?> Countries = await _mediator.Send(new GetAllCountryQuery());
        return View(Countries);
    }


    #endregion

    #region Create
    public ActionResult Create()
    {
        return PartialView("Form", new CountryDTO{ Active = true, CreateDate = DateTime.Now });
    }
    #endregion

    #region Edit
    public async Task<IActionResult> Edit(int id)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        CountryDTO countryDTO = await _mediator.Send(new GetCountryByIdQuery() { Id = id });
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.


        return PartialView("Form", countryDTO);
    }
    #endregion

    #region Form
    [HttpPost]
    public async Task<IActionResult> Form(CountryDTO model)
    {
        if (model.Id > 0)
        {
            var command = new UpdateCountryCommand(model);
            await _mediator.Send(command);

            //return View("form", command.Id);



        }

        else
        {
            var command = new CreateCountryCommand(model);
            await _mediator.Send(command);


        }
        return RedirectToAction("Index");

    }

    #endregion


    #region Delete



    //public async Task<JsonResult> Delete(int id)
    //{

    //      var id =   await _mediator.Send(new DeleteCountryCommand() { Id = id });
    //        return id;

    //}
    #endregion

    #region Detail
    public async Task<IActionResult> Details(int id)
    {
        var eventDTO = await _mediator.Send(new GetCountryByIdQuery() { Id = id });
        return View(eventDTO);
    }
    #endregion

    #region Activate

    //public async Task<JsonResult> Activate(long[] Ids)
    //{
    //    try
    //    {
    //        foreach (var item in Ids)
    //        {
    //            var entity = await _mediator.Send(new GetCountryByIdQuery() { Id = (int)item });

    //            await _mediator.Send(new UpdateCountryCommand(entity));
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
