using Application.Features.Country.Commands.Create;
using Application.Features.Country.Commands.Update;
using Application.Features.Country.Models;
using Application.Features.Country.Queries.GetAll;
using Application.Features.Country.Queries.GetById;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Administration1.Controllers;

public class CountryController : Controller
{
    #region CTOR

    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IMediator _mediator;
    private IValidator<CreateCountryCommand> _validator;
    private IValidator<UpdateCountryCommand> _validator2;



    public CountryController(IWebHostEnvironment webHostEnvironment, IMediator mediator, IValidator<CreateCountryCommand> validator, IValidator<UpdateCountryCommand> validator2)
    {
        _webHostEnvironment = webHostEnvironment;
        _mediator = mediator;
        _validator = validator;
        _validator2 = validator2;
    }


    #endregion





    #region Index
    public async Task<IActionResult> Index()
    {
        IEnumerable<CountryDTO?> Countries = await _mediator.Send(new GetAllCountryQuery() { parentId = 2 });
        return View(Countries);
    }


    #endregion



    #region Create
    public async Task<ActionResult> CreateAsync()
    {
        ViewBag.Countries = new SelectList(await _mediator.Send(new GetAllCountryQuery() { parentId = 0 }), "Id", "NameA");

        return PartialView("Form", new CountryDTO { Active = true, CreateDate = DateTime.Now });
    }
    #endregion



    #region Edit
    public async Task<IActionResult> Edit(long id)
    {
        ViewBag.Countries = new SelectList(await _mediator.Send(new GetAllCountryQuery() { parentId = 0 }), "Id", "NameA");

        CountryDTO? countryDTO = await _mediator.Send(new GetCountryByIdQuery() { Id = id });


        return PartialView("Form", countryDTO);
    }
    #endregion



    #region Form
    [HttpPost]
    public async Task<IActionResult> Form(CountryDTO model)
    {
        ViewBag.Countries = new SelectList(await _mediator.Send(new GetAllCountryQuery() { parentId = 0 }), "Id", "NameA");

        if (model.Id > 0)
        {
			var command = new UpdateCountryCommand(model);
            ValidationResult result = await _validator2.ValidateAsync(command);

            if (!ModelState.IsValid && !result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("form", command);


            }
            else
            {
                await _mediator.Send(command);
                return RedirectToAction("Index");

            }


        }

        else
        {
            var command = new CreateCountryCommand(model);
            ValidationResult result = await _validator.ValidateAsync(command);


            if (!ModelState.IsValid && !result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("form", command);

            }
            else
            {
                await _mediator.Send(command);
                return RedirectToAction("Index");

            }




        }

    }

    #endregion





    #region Delete



    //public async Task<JsonResult> Delete(int id)
    //{

    //      var id =   await _mediator.Send(new DeleteCountryCommand() { Id = id });
    //        return id;

    //}
    #endregion




    #region Details
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

#region To send Verification to the view
public static class Extensions
{
    public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
    {
        foreach (var error in result.Errors)
        {
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }
}
#endregion