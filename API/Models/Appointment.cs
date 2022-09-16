namespace API.Models;

public class Appointment
{
    public int idAppointment{get;set;}
    public string service{get;set;}
    public string store{get;set;}
    public int plate{get;set;}
    public int idClient{get;set;}
    public string clientName{get;set;}
    public string clientLastName{get;set;}
    public int idEmployee{get;set;}
    public string employeeName{get;set;}
    public string employeeLastName{get;set;}

    public void setId(int newId)
    {
        this.idAppointment = newId;
    }
}