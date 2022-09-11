using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions;
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
    public IActionResult Get()
    {
        return Ok(TallerDB.Instance.GetEmployees);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var e = TallerDB.Instance.GetEmployee(id);
        if(e != null)
        {
            return Ok(TallerDB.Instance.GetEmployee(id));
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult Post()
    {
        Employee e = new Employee();
        e.setId(TallerDB.Instance.GetEmployeesSize());
        TallerDB.Instance.addEmployee(e);
        return Ok();
    }

    [HttpPost("{id}/{name}/{last}/{secondLast}/{role}/{username}/{password}")]
    public IActionResult Post(int id,string name, string last,
        string secondLast, string role, string username, string password)
    {
        if(TallerDB.Instance.FindEmployeeById(id) != null)
        {
            return NoContent();
        }
        Employee e = new Employee();
        e.setId(id);
        e.setName(name);
        e.setLastName(last);
        e.setSLastName(secondLast);
        e.setRole(role);
        e.setUser(username);
        e.setPassword(password);
        TallerDB.Instance.addEmployee(e);
        return Ok();
    }

}