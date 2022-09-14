namespace API.Models;
public class Employee
{
    public int idNumber{get; set;}
    public int identification{get; set;}
    public string name{get; set;}
    public string lastName{get; set;}
    public int cellphoneNumber{get; set;}
    public string joiningDate {get; set;}
    public string birthDate {get; set;}
    public int age{get; set;}
    public string role{get; set;}
    public string branch{get; set;}
    public string email{get; set;}
    public string address{get; set;}
    public string username{get; set;}
    public string password{get; set;}

    public Employee()
    {
        this.idNumber = 0;
        this.identification = 0;
        this.name = "";
        this.lastName = "";
        this.cellphoneNumber = 0;
        this.joiningDate = new DateTime(1720,1,1).ToString();
        this.birthDate = new DateTime(1720,1,1).ToString();
        this.age = 0;
        this.role = "";
        this.branch = "";
        this.email = "";
        this.address = "";
        this.username = "";
        this.password = "";
    }

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
    public void setBranch(string newBranch)
    {
        this.branch = newBranch;
    }
    public void setRole(string newRole)
    {
        this.role = newRole;
    }
    public void setEmail(string newEmail)
    {
        this.email = newEmail;
    }
    public void setAddress(string newAddress)
    {
        this.address = newAddress;
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