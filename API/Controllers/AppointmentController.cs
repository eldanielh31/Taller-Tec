using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors]
    public ActionResult Get()
    {
        Appointment[] a = TallerDB.GetInstance().GetAppointments();
        if(a != null)
            return Ok(a);
        return NotFound();
    }

    [HttpGet("{searchBy}/{id}")]
    [EnableCors]
    public ActionResult Get(string searchBy, int id)
    {
        var a = TallerDB.GetInstance().GetAppointment(searchBy,id);
        if(a != null)
            return Ok(a);
        return NotFound();
    }

    [HttpPost("new")]
    [EnableCors]
    public ActionResult Post([FromBody] Appointment newAppointment)
    {
        newAppointment.setId(TallerDB.GetInstance().GetAppointmentsSize());
        TallerDB.GetInstance().addAppointment(newAppointment);
        return Ok();
    }
    
    [HttpDelete("id/{id}")]
    [EnableCors]
    public ActionResult Delete(int id)
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