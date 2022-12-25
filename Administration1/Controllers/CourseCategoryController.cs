using Microsoft.AspNetCore.Mvc;

public class CourseCategoryController : Controller
{
  #region CTOR

  private readonly IWebHostEnvironment _webHostEnvironment;
  private readonly IStringLocalizer<Application.Common.Resources.SharedResource> _stringLocalizer;
  private readonly SessionHandler _sessionHandler;
  private readonly IFileUploadHelper _fileUploadHelper;
  //Fluent validator
  private readonly IValidator<CreateEventCommand> _createValidator;
  private readonly IValidator<UpdateEventCommand> _updateValidator;

  public EventsController(IWebHostEnvironment webHostEnvironment, IFileUploadHelper fileUploadHelper,
  IStringLocalizer<Application.Common.Resources.SharedResource> stringLocalizer, SessionHandler sessionHandler
, IValidator<UpdateEventCommand> updateValidator, IValidator<CreateEventCommand> createValidator)
  {
    _webHostEnvironment = webHostEnvironment;
    _stringLocalizer = stringLocalizer;
    _sessionHandler = sessionHandler;
    _fileUploadHelper = fileUploadHelper;
    _updateValidator = updateValidator;
    _createValidator = createValidator;
    //Fluent validator

  }
  #endregion

  #region Index
  [Authorize(Policy = "Events.List")]
  public async Task<IActionResult> Index()
  {
    EventSearch EventSearchModel = _sessionHandler.Load<EventSearch>("EventSearch", new EventSearch() { Status = 1 });
    IEnumerable<EventDTO> EventDTOList = await Mediator.Send(new GetByFilterDTO(EventSearchModel));
    return View(EventDTOList.OrderByDescending(p => p.CreateDate));
  }


  #endregion

  #region Create
  [Authorize(Policy = "Events.Create")]
  public async Task<IActionResult> Create()
  {
    ViewBag.EventCategory = new SelectList(await Mediator.Send(new GetLookupValuesQuery() { LookupName = "EventCategory" }), "Id", "Name");
    ViewBag.Sector = new SelectList(await Mediator.Send(new GetLookupValuesQuery() { LookupName = "Sector" }), "Id", "Name");
    ViewBag.Entity = new SelectList(await Mediator.Send(new GetEntitiesQuery()), "Id", "Name");
    ViewBag.PhotoLibraryAlbum = new SelectList(await Mediator.Send(new GetPhotoLibraryAlbumListQuery()), "Id", "NameA");
    ViewBag.VideoLibrary = new SelectList(await Mediator.Send(new GetVideoLibraryListQuery()), "Id", "NameA");
    return PartialView("Form", new EventFormObject { Active = true, StartDate = DateTime.Now, EndDate = DateTime.Now });
  }
  #endregion

  #region Edit
  public async Task<IActionResult> Edit(int id)
  {
    EventFormObject eventDTO = await Mediator.Send(new GetFormByIdEventQuery() { Id = id });

    ViewBag.EventCategory = new SelectList(await Mediator.Send(new GetLookupValuesQuery() { LookupName = "EventCategory" }), "Id", "Name");
    ViewBag.Sector = new SelectList(await Mediator.Send(new GetLookupValuesQuery() { LookupName = "Sector" }), "Id", "Name");
    ViewBag.PhotoLibraryAlbum = new SelectList(await Mediator.Send(new GetPhotoLibraryAlbumListQuery()), "Id", "NameA");
    ViewBag.VideoLibrary = new SelectList(await Mediator.Send(new GetVideoLibraryListQuery()), "Id", "NameA");
    ViewBag.Entity = new SelectList(await Mediator.Send(new GetEntitiesQuery()), "Id", "Name");
    eventDTO.UrlA = !string.IsNullOrEmpty(eventDTO.UrlA) ? ("http://" + eventDTO.UrlA) : eventDTO.UrlA;
    eventDTO.UrlE = !string.IsNullOrEmpty(eventDTO.UrlE) ? ("http://" + eventDTO.UrlE) : eventDTO.UrlE;
    return PartialView("Form", eventDTO);
  }
  #endregion

  #region Form
  [HttpPost]
  public async Task<IActionResult> Form(EventFormObject model, IFormFile PhotoA, IFormFile AttachmentA)
  {
    model.PhotoFileA = PhotoA;
    //model.PhotoE = model.PhotoFileE != null ? model.PhotoFileE.FileName : model.PhotoE;
    model.AttachmentFileA = AttachmentA;
    //model.CoverE = model.CoverFileE != null ? model.CoverFileE.FileName : model.CoverE;

    if (model.Id > 0)
    {
      var command = new UpdateEventCommand(model);
      //Fluent validator

      ValidationResult result = await _updateValidator.ValidateAsync(command);

      if (model.EndDate < model.StartDate)
        ModelState.AddModelError("", "Invalid Date Range");
      if (!result.IsValid)
      {
        ViewBag.errorResults = result.Errors[0].ErrorMessage;
        ViewBag.EventCategory = new SelectList(await Mediator.Send(new GetLookupValuesQuery() { LookupName = "EventCategory" }), "Id", "Name");
        ViewBag.Sector = new SelectList(await Mediator.Send(new GetLookupValuesQuery() { LookupName = "Sector" }), "Id", "Name");
        ViewBag.PhotoLibraryAlbum = new SelectList(await Mediator.Send(new GetPhotoLibraryAlbumListQuery()), "Id", "NameA");
        ViewBag.VideoLibrary = new SelectList(await Mediator.Send(new GetVideoLibraryListQuery()), "Id", "NameA");
        ViewBag.Entity = new SelectList(await Mediator.Send(new GetEntitiesQuery()), "Id", "Name");
        model.UrlA = !string.IsNullOrEmpty(model.UrlA) ? ("http://" + model.UrlA) : model.UrlA;
        model.UrlE = !string.IsNullOrEmpty(model.UrlE) ? ("http://" + model.UrlE) : model.UrlE;
        return View("form", command);

      }

      model.EntityId = model.EntityId != 0 ? model.EntityId : 10;
      await Mediator.Send(new UpdateEventCommand(model));
    }
    else
    {
      var command = new CreateEventCommand(model);
      //Fluent validator

      ValidationResult result = await _createValidator.ValidateAsync(command);
      if (!result.IsValid)
      {
        ViewBag.errorResults = result.Errors[0].ErrorMessage;
        ViewBag.EventCategory = new SelectList(await Mediator.Send(new GetLookupValuesQuery() { LookupName = "EventCategory" }), "Id", "Name");
        ViewBag.Sector = new SelectList(await Mediator.Send(new GetLookupValuesQuery() { LookupName = "Sector" }), "Id", "Name");
        ViewBag.PhotoLibraryAlbum = new SelectList(await Mediator.Send(new GetPhotoLibraryAlbumListQuery()), "Id", "NameA");
        ViewBag.VideoLibrary = new SelectList(await Mediator.Send(new GetVideoLibraryListQuery()), "Id", "NameA");
        ViewBag.Entity = new SelectList(await Mediator.Send(new GetEntitiesQuery()), "Id", "Name");
        model.UrlA = !string.IsNullOrEmpty(model.UrlA) ? ("http://" + model.UrlA) : model.UrlA;
        model.UrlE = !string.IsNullOrEmpty(model.UrlE) ? ("http://" + model.UrlE) : model.UrlE;
        return View("form", model);

      }
      if (model.EndDate < model.StartDate)
        ModelState.AddModelError("", "Invalid Date Range");

      model.EntityId = model.EntityId != 0 ? model.EntityId : 10;
      await Mediator.Send(command);
      return View("form", command);
    }
    return RedirectToAction("Index");
  }
  #endregion


  #region Delete

  public async Task<JsonResult> CheckDeletePermission(int id)
  {
    bool ret = true;
    var Events = await Mediator.Send(new GetEventByIdQuery() { Id = id });
    if (Events == null)
      ret = false;
    return Json(ret);
  }

  public async Task<JsonResult> Delete(int id)
  {
    string response = "OK";

    try
    {
      int res = await Mediator.Send(new DeleteEventCommand() { Id = id });
      if (res != 1)
        response = _stringLocalizer["DeleteDenied"];
    }
    catch
    {
      response = _stringLocalizer["DeleteDenied"];
    }
    return Json(response);
  }
  #endregion

  #region Detail
  public async Task<IActionResult> Details(int id)
  {
    var eventDTO = await Mediator.Send(new GetEventByIdQuery() { Id = id });
    return View(eventDTO);
  }
  #endregion
  public async Task<JsonResult> Activate(long[] Ids)
  {
    try
    {
      foreach (var item in Ids)
      {
        var entity = await Mediator.Send(new GetAllCitiesQuery() { Id = (int)item });

        entity.Active = !entity.Active;
        await Mediator.Send(new UpdateCityCommand(entity));
        // var model = _unitOfWork.news.Get(item).Result;
        //_unitOfWork.news.Update(Entity);
      }
      return Json("Success");
    }
    catch
    {
      return Json("Error");
    }
  }




}