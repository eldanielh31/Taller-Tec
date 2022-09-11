using System;
using System.Collections.Generic;
using API.Models;

namespace API.Database{
    public class TallerDB{
        private static TallerDB instance;
        private static readonly object padlock = new object();

        private List<Employee> employees = new List<Employee>();
        private int employeesSize = 0;
        private List<Client> clients = new List<Client>();
        private int clientsSize = 0;
        private List<Appointment> apps = new List<Appointment>();
        private int appsSize = 0;

        //Constructor
        private TallerDB()
        {
            this.employees = new List<Employee>();
            this.employeesSize = 0;
            
            this.clients = new List<Client>();
            this.clientsSize = 0;
            
            this.apps = new List<Appointment>();
            this.appsSize = 0;
        }
        //Singleton instance
        public static TallerDB Instance
        {
            get
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
        }

        //Adders
        public void addEmployee(Employee newEmployee)
        {
            this.employees.Add(newEmployee);
            this.employeesSize += 1;
        }
        public void addClient(Client newClient)
        {
            this.clients.Add(newClient);
            this.clientsSize += 1;
        }
        public void addAppointment(Appointment newApp)
        {
            this.apps.Add(newApp);
            this.appsSize += 1;
        }
        
        //Getters (singular)
        public Employee GetEmployee(int id)
        {
            foreach (Employee e in employees)
            {
                if (e.idNumber == id)
                {
                    return e;
                }
            }
            return null;
        }
        public Client GetClient(int id)
        {
            foreach (Client c in clients)
            {
                if (c.idNumber == id)
                {
                    return c;
                }
            }
            return null;
        }
        public Appointment GetAppointment(int id)
        {
            foreach (Appointment a in apps)
            {
                if (a.idAppointment == id)
                {
                    return a;
                }
            }
            return null;
        }

        //Getters (multiple)
        public List<Employee> GetEmployees
        {
            get
            {
                return TallerDB.Instance.employees;
            }
        }
        public List<Client> GetClients
        {
            get
            {
                return TallerDB.Instance.clients;
            }
        }
        public List<Appointment> GetAppointments
        {
            get
            {
                return TallerDB.Instance.apps;
            }
        }

        //Find
        public Employee FindEmployeeById(int id)
        {
            return employees.Find(x => x.idNumber.Equals(id));
        }
        public Client FindClientById(int id)
        {
            return clients.Find(x => x.idNumber.Equals(id));
        }
        public Appointment FindAppointmentById(int id)
        {
            return apps.Find(x => x.idAppointment.Equals(id));
        }

        //Delete
        public void DeleteEmployee(int id)
        {
            employees.Remove(FindEmployeeById(id));
        }
        public void DeleteClient(int id)
        {
            clients.Remove(FindClientById(id));
        }
        public void DeleteAppointment(int id)
        {
            apps.Remove(FindAppointmentById(id));
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