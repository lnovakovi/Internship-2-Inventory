﻿using System;
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
            Console.WriteLine("Izaberi opciju:\n" +
                              "1) Ispis svih detalja\n" +
                              "2) Ispis računala kojima ističe garancija\n" +
                              "3) Ispis koliko komada tehnološke opreme ima baterije\n" +
                              "4) Ispis svih mobitela\n" +
                              "5) Ispis računala s odabranim OS\n" +
                              "6) Ispis svih vozila kojim registracija ističe u idućih mjesec dana");
            var choice = 0;
            do
            {
               Console.WriteLine("Unesite broj:");
               choice = int.Parse((Console.ReadLine()));
            } while (choice < 1 || choice > 6);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter serial number:");
                    var input = Guid.Parse(Console.ReadLine());
                    CheckingInvetory(input,Computers,Vehicles,Phones);
                    break;
                case 2:
                    Console.WriteLine("Enter year: ");
                    var newInput = int.Parse(Console.ReadLine());
                    PrintComputersWhoseWarrantyExpireInFollowingYear(newInput,Computers);
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                    
                                   
            }

           




        }

        public static void CheckingInvetory(Guid SerialNumber, List<Computer> computerList,List<Vehicles> vehicleList,List<MobilePhones> phoneList)
        {
            var br = 0;
            foreach (var item in computerList)
            {
                if (SerialNumber == item.SerialNumber)
                {
                    br += 1;
                    Console.WriteLine("Serial number: " + item.SerialNumber + " OS: " + item.OS + " Transferable: " + item.Transferable + 
                                      "  Battery Included: " + item.BatteryIncluded + " Date of purchase: " + item.DateOfPurchase +
                                      "  Description: " + item.Description + "  Months of Warranty: " +
                                      item.MonthsOfWarranty + "  Purchase price:" + item.PurchasePrice  );
                }
            }
            foreach (var item in vehicleList)
            {
                if (SerialNumber == item.SerialNumber)
                {
                    br += 1;
                    Console.WriteLine("Serial number: " + item.SerialNumber + "  Mileage: "+item.Mileage+ "Expiration date of registration: "+ item.ExpirationDateOfRegistration
                                       + " Date of purchase: " + item.DateOfPurchase +
                                      "  Description: " + item.Description + "  Months of Warranty: " +
                                      item.MonthsOfWarranty + "  Purchase price:" + item.PurchasePrice);
                }
            }
            foreach (var item in phoneList)
            {
                if (SerialNumber == item.SerialNumber)
                {
                    br += 1;
                    Console.WriteLine("Serial number: " + item.SerialNumber + " Name and surname:"+ item.NameSurname + "Phone number: " +item.PhoneNumber
                                      + " Date of purchase: " + item.DateOfPurchase +
                                      "  Description: " + item.Description + "  Months of Warranty: " +
                                      item.MonthsOfWarranty + "  Purchase price:" + item.PurchasePrice);
                }
            }

            if (br == 0)
            {
                Console.WriteLine("No item with that serial number");
            }
        }

        public static void PrintComputersWhoseWarrantyExpireInFollowingYear(int year,List<Computer> computerList)
        {
            var br = 0;
            foreach (var item in computerList)
            {
                var yearsOfWarranty = item.MonthsOfWarranty / 12;
                var newYear = item.DateOfPurchase.Year + yearsOfWarranty;
                var monthsLeft = item.MonthsOfWarranty - yearsOfWarranty * 12;
                var months = item.DateOfPurchase.Month + monthsLeft;
                if (months > 12)
                {
                    var m = months - 12;
                    newYear += 1;
                }
                
                if (newYear == year)
                {
                    br += 1;
                    Console.WriteLine("Serial number: " + item.SerialNumber + " OS: " + item.OS + " Transferable: " + item.Transferable +
                                      "  Battery Included: " + item.BatteryIncluded + " Date of purchase: " + item.DateOfPurchase +
                                      "  Description: " + item.Description + "  Months of Warranty: " +
                                      item.MonthsOfWarranty + "  Purchase price:" + item.PurchasePrice);
                }

            }

            if (br == 0)
            {
                Console.WriteLine("No computer with warranty that is expiring this year");
            }
                
            }
        
        public static List<Computer> InitializationMethodComputers()
        {
            var listOfComputers = new List<Computer>();

            var computer1 = new Computer("Windows 10", false, true,
                "Windows 10 Home\nIntel® Core™ i7 - 6700HQ processor 2.60 GHz 15.6", new DateTime(2015, 10, 5), 12,
                1321, "Acer");
            var computer2 = new Computer("Linux", false, true,
                "Linux \nIntel® Core™ i5 - 6720HQ processor 1.60 GHz 15.6", new DateTime(2017, 12, 10), 24,
                4361, "HP");
            var computer3 = new Computer("Chrome OS", true, true,
                "Chrome OS Intel® Celeron® N3350 processor Dual-core 1.10 GHz", new DateTime(2017, 12, 17), 24,
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
