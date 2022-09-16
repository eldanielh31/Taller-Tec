using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Database;
using Microsoft.AspNetCore.Cors;
using API.Email;

namespace API.Controllers;

[ApiController]
[Route("employees")]

public class EmployeeController : ControllerBase{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IEmailSender _emailSender;
    public EmployeeController(ILogger<EmployeeController> logger, IEmailSender emailSender)
    {
        _emailSender = emailSender;
        _logger = logger;
    }

    //GET Sentences

    //GET api
    [HttpGet]
    [EnableCors]
    public ActionResult Get()
    {
        Employee[] e = TallerDB.GetInstance().GetEmployees();
        if(e != null)
            return Ok(e);
        return NotFound();
    }

    [HttpGet("email/{email}")]
    [EnableCors]
    public ActionResult Get(string email)
    {
        var e = TallerDB.GetInstance().GetEmployee(email);
        if(e != null)
            return Ok(TallerDB.GetInstance().GetEmployee(email));
        return NotFound();
    }

    [HttpGet("id/{id}")]
    [EnableCors]
    public ActionResult Get(int id)
    {
        var e = TallerDB.GetInstance().GetEmployee(id);
        if(e != null)
            return Ok(TallerDB.GetInstance().GetEmployee(id));
        return NotFound();
    }

    [HttpPost]
    [EnableCors]
    public ActionResult Post()
    {
        Employee e = new Employee();
        e.setId(new Random().Next());
        TallerDB.GetInstance().addEmployee(e);
        return Ok();
    }

    [HttpPost("new")]
    [EnableCors]
    public ActionResult Post([FromBody] Employee e)
    {
        //Añade el empleado
        if(TallerDB.GetInstance().FindEmployeeById(e.idNumber) != null)
            return NoContent();
        TallerDB.GetInstance().addEmployee(e);
        
        return Ok(e);
    }
    
    [HttpDelete("id/{id}")]
    [EnableCors]
    public ActionResult Delete(int id)
    {
        var e = TallerDB.GetInstance().FindEmployeeById(id);
        if(e != null)
        {
            TallerDB.GetInstance().DeleteEmployee(id);
            return Ok();
        }
        return NotFound();
    }
}