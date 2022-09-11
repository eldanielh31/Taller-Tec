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
    public IActionResult Get()
    {
        return Ok(TallerDB.Instance.GetClients);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var c = TallerDB.Instance.GetClient(id);
        if(c != null)
        {
            return Ok(c);
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult Post()
    {
        Client c = new Client();
        c.setId(TallerDB.Instance.GetClientsSize());
        TallerDB.Instance.addClient(c);
        return Ok();
    }

    [HttpPost("{id}/{name}/{last}/{secondLast}/{email}/{username}/{password}")]
    public IActionResult Post(int id, string name, string last,
        string secondLast, string email, string username, string password)
    {
        if(TallerDB.Instance.FindClientById(id) != null)
        {
            return NotFound();
        }
        Client c = new Client();
        c.setId(id);
        c.setName(name);
        c.setLastName(last);
        c.setSLastName(secondLast);
        c.setEmail(email);
        c.setUser(username);
        c.setPassword(password);
        TallerDB.Instance.addClient(c);
        return Ok();
    }

}