using System;
using System.Collections.Generic;
using API.Models;

namespace API.Database{
    public class TallerDB{
        private static TallerDB instance;
        private static readonly object padlock = new object();

        private Employee[] employees;
        private int employeesSize = 0;
        private Client[] clients;
        private int clientsSize = 0;
        private Appointment[] apps;
        private int appsSize = 0;

        private string employeeTable = "Database/Tables/employees.json";
        private string clientTable = "Database/Tables/clients.json";
        private string appointmentTable = "Database/Tables/appointments.json";

        //Constructor
        private TallerDB()
        {
            this.employees = JSONManager.ReadJSON<Employee[]>(employeeTable);
            //this.employees = new List<Employee>();
            this.employeesSize = this.employees.Length;
            
            this.clients = JSONManager.ReadJSON<Client[]>(clientTable);
            //this.clients = new List<Client>();
            this.clientsSize = this.clients.Length;
            
            this.apps = JSONManager.ReadJSON<Appointment[]>(appointmentTable);
            //this.apps = new List<Appointment>();
            this.appsSize = this.apps.Length;
        }
        //Singleton instance
        public static TallerDB GetInstance()
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new TallerDB();
                }
                return instance;
            }
        }

        //Adders
        public void addEmployee(Employee newEmployee)
        {
            //this.employees.Add(newEmployee);
            //this.employeesSize += 1;
            JSONManager.AddToJSON<Employee>(newEmployee,employeeTable);
        }
        public void addClient(Client newClient)
        {
            //this.clients.Add(newClient);
            //this.clientsSize += 1;
            JSONManager.AddToJSON<Client>(newClient,clientTable);
        }
        public void addAppointment(Appointment newApp)
        {
            //this.apps.Add(newApp);
            //this.appsSize += 1;
            JSONManager.AddToJSON<Appointment>(newApp,appointmentTable);
        }
        
        //Getters (singular)
        public Employee GetEmployee(int id)
        {
            return employees.FirstOrDefault(e => e.idNumber.Equals(id));
        }
        public Employee GetEmployee(string email)
        {
            return employees.FirstOrDefault(e => e.email.Equals(email));
        }
        public Client GetClient(int id)
        {
            return clients.FirstOrDefault(c => c.idNumber.Equals(id));
        }
        public Client GetClient(string email)
        {
            return clients.FirstOrDefault(c => c.email.Equals(email));
        }
        public Appointment GetAppointment(string type,int id)
        {
            switch(type)
            {
                case ("i"):
                    return apps.FirstOrDefault(c => c.idAppointment.Equals(id));
                case ("e"):
                    return apps.FirstOrDefault(c => c.idEmployee.Equals(id));
                case ("c"):
                    return apps.FirstOrDefault(c => c.idClient.Equals(id));
            }
            return null;
        }

        //Getters (multiple)
        public Employee[] GetEmployees()
        {
            return this.employees;   
        }
        public Client[] GetClients()
        {
            return this.clients;
        }
        public Appointment[] GetAppointments()
        {
            return this.apps;
        }

        //Find
        public Employee FindEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.idNumber.Equals(id));
        }
        public Client FindClientById(int id)
        {
            return clients.FirstOrDefault(c => c.idNumber.Equals(id));
        }
        public Appointment FindAppointmentById(int id)
        {
            return apps.FirstOrDefault(a => a.idAppointment.Equals(id));
        }

        //Delete
        public void DeleteEmployee(int id)
        {
            Employee[] newEmployeeList = employees.Where(e => e.idNumber != id).ToArray();
            this.employees = newEmployeeList;
            JSONManager.OverrideJSON<Employee>(newEmployeeList,employeeTable);
        }
        public void DeleteClient(int id)
        {
            Client[] newClientList = clients.Where(c => c.idNumber != id).ToArray();
            this.clients = newClientList;
            JSONManager.OverrideJSON<Client>(newClientList,clientTable);
        }
        public void DeleteAppointment(int id)
        {
            Appointment[] newAppList = apps.Where(a => a.idAppointment != id).ToArray();
            this.apps = newAppList;
            JSONManager.OverrideJSON<Appointment>(newAppList,appointmentTable);
        }

        //Size getters
        public int GetEmployeesSize()
        {
            return employeesSize;
        }
        public int GetClientsSize()
        {
            return clientsSize;
        }
        public int GetAppointmentsSize()
        {
            return appsSize;
        }
    }
}