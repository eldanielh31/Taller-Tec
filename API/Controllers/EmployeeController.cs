using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Database;

namespace API.Controllers;

[ApiController]
[Route("employees")]

public class EmployeeController : ControllerBase{
    private readonly ILogger<EmployeeController> _logger;
    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }

    //GET Sentences

    //GET api
    [HttpGet]
    public ActionResult Get()
    {
        Employee[] e = TallerDB.GetInstance().GetEmployees();
        if(e != null)
            return Ok(e);
        return NotFound();
    }

    [HttpGet("email/{email}")]
    public ActionResult Get(string email)
    {
        var e = TallerDB.GetInstance().GetEmployee(email);
        if(e != null)
            return Ok(TallerDB.GetInstance().GetEmployee(email));
        return NotFound();
    }

    [HttpGet("id/{id}")]
    public ActionResult Get(int id)
    {
        var e = TallerDB.GetInstance().GetEmployee(id);
        if(e != null)
            return Ok(TallerDB.GetInstance().GetEmployee(id));
        return NotFound();
    }

    [HttpPost]
    public ActionResult Post()
    {
        Employee e = new Employee();
        e.setId(new Random().Next());
        TallerDB.GetInstance().addEmployee(e);
        return Ok();
    }

    [HttpPost("new")]
    public ActionResult Post([FromBody] Employee e)
    {
        if(TallerDB.GetInstance().FindEmployeeById(e.idNumber) != null)
            return NoContent();
        TallerDB.GetInstance().addEmployee(e);
        return Ok(e);
    }
    
    [HttpDelete("id/{id}")]
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