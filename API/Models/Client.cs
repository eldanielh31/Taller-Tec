namespace API.Models;

public class Client
{
    public long idNumber{get; set;}
    public string name{get; set;}
    public string lastName{get; set;}
    public string secondLastName{get; set;}
    public int cellphoneNumber{get; set;}
    public string email{get; set;}
    public string location{get; set;}
    public string username{get; set;}
    public string password{get; set;}

    public void setId(int newId)
    {
        this.idNumber = newId;
    }
    public void setName(string newName)
    {
        this.name = newName;
    }
    public void setLastName(string newLast)
    {
        this.lastName = newLast;
    }
    public void setSLastName(string newSecond)
    {
        this.secondLastName = newSecond;
    }
    public void setCPNumber(int newCP)
    {
        this.cellphoneNumber = newCP;
    }
    public void setEmail(string newEmail)
    {
        this.email = newEmail;
    }
    public void setLocation(string newLocation)
    {
        this.location = newLocation;
    }
    public void setUser(string newUser)
    {
        this.username = newUser;
    }
    public void setPassword(string newPassword)
    {
        this.password = newPassword;
    }
}