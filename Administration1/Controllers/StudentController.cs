using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller
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
        IEnumerable<CountryDTO> Countries = await _mediator.Send(new GetAllCountryQuery());
        return View(Countries);
    }


    #endregion

    #region Create
    public async Task<IActionResult> Create()
    {
        return PartialView("Form", new CountryObjectDTO());
    }
    #endregion

    #region Edit
    public async Task<IActionResult> Edit(int id)
    {
        CountryDTO countryDTO = await _mediator.Send(new GetCountryByIdQuery() { Id = id });

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



    public async Task<JsonResult> Delete(int id)
    {
        string response = "OK";

        try
        {
            int res = await _mediator.Send(new DeleteCountryCommand() { Id = id });
        }
        catch (Exception ex)
        { throw; }
        return null;
    }
    #endregion

    #region Detail
    public async Task<IActionResult> Details(int id)
    {
        var eventDTO = await _mediator.Send(new GetCountryByIdQuery() { Id = id });
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
                var entity = await _mediator.Send(new GetCountryByIdQuery() { Id = (int)item });

                await _mediator.Send(new UpdateCountryCommand(entity));
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