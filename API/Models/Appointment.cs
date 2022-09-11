namespace API.Models;

public class Appointment
{
    public int idAppointment{get;set;}
    public int idService{get;set;}
    public int idClient{get;set;}
    public int idEmployee{get;set;}
    public int price{get;set;}

    public void setId(int newId)
    {
        this.idAppointment = newId;
    }
}