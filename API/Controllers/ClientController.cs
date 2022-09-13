using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Database;

namespace API.Controllers;

[ApiController]
[Route("clients")]

public class ClientController : ControllerBase{
    private readonly ILogger<ClientController> _logger;
    public ClientController(ILogger<ClientController> logger)
    {
        _logger = logger;
    }

    //GET Sentences

    //GET api
    [HttpGet]
    public ActionResult Get()
    {
        Client[] c = TallerDB.GetInstance().GetClients();
        if(c != null)
            return Ok(c);
        return NotFound();
    }

    [HttpGet("id/{id}")]
    public ActionResult Get(int id)
    {
        var c = TallerDB.GetInstance().GetClient(id);
        if(c != null)
            return Ok(c);
        return NotFound();
    }
    [HttpGet("email/{email}")]
    public ActionResult Get(string email)
    {
        var c = TallerDB.GetInstance().GetClient(email);
        if(c != null)
            return Ok(c);
        return NotFound();
    }

    [HttpPost]
    public ActionResult Post()
    {
        Client c = new Client();
        c.setId(new Random().Next());
        TallerDB.GetInstance().addClient(c);
        return Ok();
    }

    [HttpPost("new")]
    public ActionResult Post([FromBody] Client c)
    {
        if(TallerDB.GetInstance().FindClientById(c.idNumber) != null)
            return BadRequest();
        TallerDB.GetInstance().addClient(c);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var c = TallerDB.GetInstance().FindClientById(id);
        if(c != null)
        {
            TallerDB.GetInstance().DeleteClient(id);
            return Ok();
        }
        return NotFound();
    }

}