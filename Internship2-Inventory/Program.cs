using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Internship2_Inventory
{
   public class Program
    {
         static void Main(string[] args)
        {
           
            var Computers = new List<Computer>();
            var Phones = new List<MobilePhones>();
            var Vehicles = new List<Vehicles>();
            Computers = InitializationMethodComputers();
            Phones = InitializationMobiles();
            Vehicles = InitializationMethodVehicles();


           




        }

        public static List<Computer> InitializationMethodComputers()
        {
            var listOfComputers = new List<Computer>();

            var computer1 = new Computer("Windows 10", false, true,
                "Windows 10 Home\nIntel® Core™ i7 - 6700HQ processor 2.60 GHz 15.6", new DateTime(2015, 10, 5), 12,
                1321, "Acer");
            var computer2 = new Computer("Linux", false, true,
                "Linux \nIntel® Core™ i5 - 6720HQ processor 1.60 GHz 15.6", new DateTime(2014, 12, 10), 24,
                4361, "HP");
            var computer3 = new Computer("Chrome OS", true, true,
                "Chrome OS Intel® Celeron® N3350 processor Dual-core 1.10 GHz", new DateTime(2013, 12, 17), 24,
                4361, "HP");
            listOfComputers.Add(computer1);
            listOfComputers.Add(computer2);
            listOfComputers.Add(computer3);
            return listOfComputers;

        }
        public static List<MobilePhones> InitializationMobiles()
        {
            var listOfMobiles = new List<MobilePhones>();

            var mobile1 = new MobilePhones(091654234, "John Wick", true, "Bestseller", new DateTime(2012, 03, 29), 12,
                1234.54m, "Huawei");
            var mobile2 = new MobilePhones(0995432176, "Christopher Ashton", true, "new one",
                new DateTime(2016, 12, 01), 24, 3456.99m, "Samsung");
            var mobile3 = new MobilePhones(0915432765,"Jure Juric",true,"best display",new DateTime(2017,09,01),36,2345.5m,"Sony" );
            listOfMobiles.Add(mobile1);
            listOfMobiles.Add(mobile2);
            listOfMobiles.Add(mobile3);
            return listOfMobiles;

        }
        public static List<Vehicles> InitializationMethodVehicles()
        {
            var listOfVehicles= new List<Vehicles>();

            var vehicle1 = new Vehicles(new DateTime(2020,12,30),90000,"good",new DateTime(2014,12,03),180,23456.67m,"Opel");
            var vehicle2 = new Vehicles(new DateTime(2021,10,01),40123.34,"blue",new DateTime(2016,09,09),144,45678.65m,"BMW");
            var vehicle3 = new Vehicles(new DateTime(2019,01,01),2300,"black",new DateTime(2018,10,05),120,34566.79m,"Ford");
            listOfVehicles.Add(vehicle1);
            listOfVehicles.Add(vehicle2);
            listOfVehicles.Add(vehicle3);
            return listOfVehicles;

        }

        public enum PhoneManufacturer
        {
            Huawei = 0,
            Samsung =1,
            Sony=2          
        }
        public enum ComputerManufacturer
        {
            Acer=0,
            HP=1,
            Lenovo=2
        }
        public enum VehicleManufacturer
        {
            BMW=0,
            Opel=1,
            Ford=2
        }
    }
   
}
