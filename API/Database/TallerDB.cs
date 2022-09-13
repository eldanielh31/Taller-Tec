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
            updateArrays();
        }

        private void updateArrays()
        {
            this.employees = JSONManager.ReadJSON<Employee[]>(employeeTable);
            this.employeesSize = this.employees.Length;
            
            this.clients = JSONManager.ReadJSON<Client[]>(clientTable);
            this.clientsSize = this.clients.Length;
            
            this.apps = JSONManager.ReadJSON<Appointment[]>(appointmentTable);
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
            updateArrays();
        }
        public void addClient(Client newClient)
        {
            JSONManager.AddToJSON<Client>(newClient,clientTable);
            updateArrays();
        }
        public void addAppointment(Appointment newApp)
        {
            JSONManager.AddToJSON<Appointment>(newApp,appointmentTable);
            updateArrays();
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
                case ("a" or "appointment"):
                    return apps.FirstOrDefault(c => c.idAppointment.Equals(id));
                case ("e" or "employee"):
                    return apps.FirstOrDefault(c => c.idEmployee.Equals(id));
                case ("c" or "client"):
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
            updateArrays();
        }
        public void DeleteClient(int id)
        {
            Client[] newClientList = clients.Where(c => c.idNumber != id).ToArray();
            this.clients = newClientList;
            JSONManager.OverrideJSON<Client>(newClientList,clientTable);
            updateArrays();
        }
        public void DeleteAppointment(int id)
        {
            Appointment[] newAppList = apps.Where(a => a.idAppointment != id).ToArray();
            this.apps = newAppList;
            JSONManager.OverrideJSON<Appointment>(newAppList,appointmentTable);
            updateArrays();
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