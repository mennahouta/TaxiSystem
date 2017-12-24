﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Data;

namespace Taxi_Management_System
{
    public static class AdminGlobals
    {
        public static Dictionary<string, Admin> AdminMap = new Dictionary<string, Admin>();
        public static List<Trip> AllTrips = new List<Trip>();
    }

    public class Admin
    {
        public string AdminUsername;
        public string AdminPassword;

        public void FillAdminMap()
        {
            //Awad
            //StreamReader Stream = new StreamReader(@"C:\Users\Menna\Source\Repos\TaxiSystem\Taxi Management System\Text Files\Admin.txt");

            //mohie
            StreamReader Stream = new StreamReader(@"C:\Users\Menna\Source\Repos\TaxiSystem\Taxi Management System\Text Files\Admin.txt");

            //StreamReader Stream = new StreamReader("Admin.txt");

            char[] Delimeters = { ' ', ',', '.', ':', '\t' };
            string Line = Stream.ReadLine();

            while (!string.IsNullOrWhiteSpace(Line))
            {
                Admin TempAdmin = new Admin();
                string[] Words = Line.Split(Delimeters);

                TempAdmin.AdminUsername = Words[0];
                TempAdmin.AdminPassword = Words[1];

                AdminGlobals.AdminMap[TempAdmin.AdminUsername] = TempAdmin;

                Line = Stream.ReadLine();
            }

            Stream.Close();
        }

        public void SendTripData(Trip Trip)
        {
            AdminGlobals.AllTrips.Add(Trip);
        }

        public void viewtrips()
        {
            int num_trips;
            num_trips = AdminGlobals.AllTrips.Count;
            DataTable Trips = new DataTable();
            Trips.Columns.Add("Client Name");
            Trips.Columns.Add("Driver Name");
            Trips.Columns.Add("From");
            Trips.Columns.Add("To");
            Trips.Columns.Add("Date");

            DataRow NewTrip;
            for (int i = 0; i < num_trips; i++)
            {
                NewTrip = Trips.NewRow();
                NewTrip["Client Name"] = AdminGlobals.AllTrips[i].ClientName;
                NewTrip["Driver Name"] = AdminGlobals.AllTrips[i].DriverName;
                NewTrip["From"] = AdminGlobals.AllTrips[i].From;
                NewTrip["To"] = AdminGlobals.AllTrips[i].To;
                NewTrip["Date"] = AdminGlobals.AllTrips[i].Date;
                Trips.Rows.Add(NewTrip);
            }
            //DGV.DataSource = Trips;


        }
        public void AddNewDriver(string uname, string password, string name, string driverid, string carplatenumber, string salary, string status)
        {
            Driver tempdriver = new Driver();
            tempdriver.DriverUsername = uname;
            tempdriver.DriverPassword = password;
            tempdriver.DriverName = name;
            tempdriver.DriverID = driverid;
            tempdriver.CarID = carplatenumber;
            tempdriver.Salary = salary;
            tempdriver.Status = status;
            DriverGlobals.DriverMap[uname] = tempdriver;
            DriverGlobals.NewDrivers[uname] = tempdriver;
        }

        public void AddNewCar(string PlateNumber, string Color, string Year, string Model)
        {
            Car TempCar = new Car();
            TempCar.PlateNumber = PlateNumber;
            TempCar.Color = Color;
            TempCar.Year = Year;
            TempCar.Model = Model;
            CarGlobals.CarMap[PlateNumber] = TempCar;
            CarGlobals.NewCars[PlateNumber] = TempCar;
        }
    }
}