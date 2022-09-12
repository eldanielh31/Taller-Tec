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
        return Ok(TallerDB.GetInstance().GetAppointments);
    }

    [HttpGet("{idType}/{id}")]
    public IActionResult Get(string idType, int id)
    {
        var a = TallerDB.GetInstance().GetAppointment(idType,id);
        if(a != null)
        {
            return Ok(a);
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult Post([FromBody] Appointment newAppointment)
    {
        newAppointment.setId(TallerDB.GetInstance().GetAppointmentsSize());
        TallerDB.GetInstance().addAppointment(newAppointment);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var a = TallerDB.GetInstance().FindAppointmentById(id);
        if(a != null)
        {
            TallerDB.GetInstance().DeleteAppointment(id);
            return Ok();
        }
        return NotFound();
    }
}