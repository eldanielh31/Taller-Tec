using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions;
using API.Models;
using API.Database;

namespace API.Controllers;

[ApiController]
[Route("appointments")]

public class AppointmentController : ControllerBase{
    private readonly ILogger<AppointmentController> _logger;
    public AppointmentController(ILogger<AppointmentController> logger)
    {
        _logger = logger;
    }

    //GET Sentences

    //GET api
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(TallerDB.Instance.GetAppointments);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var a = TallerDB.Instance.GetAppointment(id);
        if(a != null)
        {
            return Ok(a);
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult Post()
    {
        Appointment a = new Appointment();
        a.setId(TallerDB.Instance.GetAppointmentsSize());
        TallerDB.Instance.addAppointment(a);
        return Ok();
    }
}