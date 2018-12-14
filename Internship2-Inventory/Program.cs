using System;
using System.Collections.Generic;
using System.Linq;
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
            var Technological = new List<TechnologicalEquipment>();
        
            Computers = InitializationMethodComputers();
            Phones = InitializationMobiles();
            Vehicles = InitializationMethodVehicles();
            foreach (var item in Computers)
            {
                Technological.Add(item);
            }
            foreach (var item in Phones)
            {
                Technological.Add(item);
            }
            Console.WriteLine("Choose an option:\n" +
                              "1) Print all the details of invetory\n" +
                              "2) Print computers whose warranty expires in year you enter\n" +
                              "3) Print how many technological equipment has battery included\n" +
                              "4) Print mobile phones with manufacturer's name you enter\n" +
                              "5) Print computers with OS you enter\n" +
                              "6) Print owners of mobile phones whose warranty expires in year you enter\n" +
                              "7) Print all the vehicles whose registration expires in next month\n" +
                              "8) Print prices for both categories");
            

            var enterInput = false;
            int output;
            do
            {
                Console.WriteLine("Enter number:");
                var choiceMade = Console.ReadLine();
                enterInput = int.TryParse(choiceMade, out output);
                if (!enterInput )
                {
                    Console.WriteLine("Wrong type.");
                }              
            } while (!enterInput || output < 1 || output> 8);

            switch (output)
            {
                case 1:
                    var success = false;
                    Guid result;
                    Console.WriteLine("Enter serial number:");            
                    do
                    {
                        var input = Console.ReadLine();
                        success = Guid.TryParse(input, out result);
                        if (!success)
                        {
                            Console.WriteLine("Wrong type.");
                        }
                    } while (!success);               
                    CheckingInvetory(result,Computers,Vehicles,Phones);
                    break;
                case 2:
                    var newInput = "";
                    var result1 = 0;
                    Console.WriteLine("Enter year: ");
                    do
                    {
                        newInput = Console.ReadLine();
                        success = int.TryParse(newInput, out result1);
                        if (!success)
                        {
                            Console.WriteLine("Wrong type.");
                        }
                    } while (!success);                   
                    PrintComputersWhoseWarrantyExpireInFollowingYear(result1,Computers);
                    break;
                case 3:
                    Console.WriteLine("Number of Tech Equipment with included battery: " + CountTechnologicalEquipmentWithBatteryIncluded(Technological));
                    break;
                case 4:
                    Console.WriteLine("Enter phone's manufacturer: ");
                    var strInput = Console.ReadLine();
                    PrintMobilePhonesWithCertainName(strInput,Phones);
                    break;
                case 5:
                    Console.WriteLine("Enter OS: ");
                    strInput = Console.ReadLine();
                    PrintComputersWithCertainOS(strInput,Computers);
                    break;
                case 6:
                    Console.WriteLine("Enter year: ");
                    do
                    {
                        newInput = Console.ReadLine();
                        success = int.TryParse(newInput, out result1);
                        if (!success)
                        {
                            Console.WriteLine("Wrong type.");
                        }
                    } while (!success);
                    PrintCurrentOwnersWhoseWarrantyExpireInFollowingYear(result1,Phones);
                    break;
                case 7:
                    PrintVehiclesWhoseRegistrationExpiresInNextMonth(Vehicles);
                    break;
                case 8:
                    PrintPrices(Vehicles,Technological);
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
                                      item.MonthsOfWarranty + "  Purchase price:" + item.PurchasePrice + "Name of manufacturer: " + item.NameOfManufacturer);
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
                                      item.MonthsOfWarranty + "  Purchase price:" + item.PurchasePrice + "Name of manufacturer: " + item.NameOfManufacturer);
                }
            }
            foreach (var item in phoneList)
            {
                if (SerialNumber == item.SerialNumber)
                {
                    br += 1;
                    Console.WriteLine("Serial number: " + item.SerialNumber + " Name and surname:"+ item.NameSurname + "Phone number: 0" +item.PhoneNumber
                                      + " Date of purchase: " + item.DateOfPurchase +
                                      "  Description: " + item.Description + "  Months of Warranty: " +
                                      item.MonthsOfWarranty + "  Purchase price:" + item.PurchasePrice + "Name of manufacturer: " + item.NameOfManufacturer);
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
                                      item.MonthsOfWarranty + "  Purchase price:" + item.PurchasePrice + " Name of Manufacturer:" + item.NameOfManufacturer);
                }

            }

            if (br == 0)
            {
                Console.WriteLine("No computer with warranty that is expires this year");
            }
                
            }

        public static int CountTechnologicalEquipmentWithBatteryIncluded(List<TechnologicalEquipment> techs)
        {
            int br = 0;
            foreach (var item in techs)
            {
                if (item.BatteryIncluded)
                    br += 1;
            }
            return br;
        }

        public static void PrintCurrentOwnersWhoseWarrantyExpireInFollowingYear(int year, List<MobilePhones> phoneList)
        {

            var br = 0;
            foreach (var item in phoneList)
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
                    Console.WriteLine("Name and surname: " + item.NameSurname + " Number: 0" + item.PhoneNumber);
                }
            }
            if (br == 0)
            {
                Console.WriteLine("No mobile phones with warranty that expires this year");
            }
        }

        public static void PrintMobilePhonesWithCertainName(string input,List<MobilePhones> phoneList)
        {
            var br = 0;
            input = input.ToUpper();
            input = input.Replace(" ", "");
            if (Enum.TryParse<Manufacturer>(input, out Manufacturer result))
            {
                var search = result;
                foreach (var item in phoneList)
                {
                    if (search == item.NameOfManufacturer)
                    {
                        br += 1;
                        Console.WriteLine("Serial number: " + item.SerialNumber + "  Name and surname: " + item.NameSurname + "  Phone number:" +
                                          item.PhoneNumber + "  Name of manufacturer:" + item.NameOfManufacturer + "  Purchase price:" + item.PurchasePrice + "  Date of purchase:" +
                                          item.DateOfPurchase);
                    }
                }
            }
            else
            {
                Console.WriteLine("Inventory does not have that type of mobile phone");
            }
            
        }
        public static void PrintComputersWithCertainOS(string input, List<Computer> computerList)
        {
            var br = 0;
            input = input.ToUpper();
            input = input.Replace(" ", ""); 
            if (Enum.TryParse<OperatingSystem>(input, out OperatingSystem result))
            {
                var search = result;
                foreach (var item in computerList)
                {
                    if (search == item.OS)
                    {
                        br += 1;
                        Console.WriteLine("Serial number: " + item.SerialNumber + "  Name of manufacturer:" + item.NameOfManufacturer + 
                                           "  OS: "+ item.OS + "  Transferable:" + item.Transferable  + "Purchase price:" + item.PurchasePrice + "  Date of purchase:" +
                                          item.DateOfPurchase);
                    }
                }
            }
            else
            {               
                Console.WriteLine("Inventory does not have that computer with that OS");
            }

        }

        public static void PrintVehiclesWhoseRegistrationExpiresInNextMonth(List<Vehicles> vehicleList)
        {
            var now = DateTime.Now;
            foreach (var item in vehicleList)
            {
                var timeDiff = item.ExpirationDateOfRegistration - now; 
                if ( timeDiff.TotalDays > 0 && timeDiff.TotalDays <= 30) // if registration has not expired(negative number) and total days less than 30 (approximately month) 
                {
                    Console.WriteLine("Serial number: "+item.SerialNumber + "  Expiration date: " +item.ExpirationDateOfRegistration +
                                      "  Name of manufacturer: " +item.NameOfManufacturer + "  Mileage:"
                                      +item.Mileage );
                }
            }
        }

        public static void PrintPrices(List<Vehicles> vehicleList, List<TechnologicalEquipment> techs)
        {
            var currentPrice = 0m;
            var _20percentOfOriginal = 0m;          
            var _10percentOfOriginal = 0m;
            var mileage = 0;
            foreach (var item in vehicleList)
            {
                _20percentOfOriginal = item.PurchasePrice * 0.2m;
                _10percentOfOriginal = item.PurchasePrice * 0.1m;
                if (item.Mileage > 20000)
                {
                    mileage = (int) item.Mileage / 20000;
                    currentPrice = item.PurchasePrice - (decimal)(mileage) * _10percentOfOriginal;
                    Console.WriteLine(currentPrice);
                    if (currentPrice < _20percentOfOriginal)
                    {
                        currentPrice = _20percentOfOriginal;
                        currentPrice = Math.Round(currentPrice, 2);
                    }
                }
                else
                {
                    currentPrice = item.PurchasePrice;
                }
                Console.WriteLine(" Name of manufacturer: " + item.NameOfManufacturer + 
                                  "   Purchase price:"  + item.PurchasePrice + 
                                  " Current price: "+ currentPrice + "  Diff: " + (item.PurchasePrice-currentPrice));
            }
            var _30percentOfOriginal = 0m;
            var _5percentOfOriginal = 0m;
            var now = DateTime.Now;           
            foreach (var item in techs)
            {
               
                _30percentOfOriginal = item.PurchasePrice * 0.3m;
                _5percentOfOriginal = item.PurchasePrice * 0.05m;
                var diffTime = now - item.DateOfPurchase;
                var totalMonth = (int)(diffTime.TotalDays / 30);
                if (totalMonth > 1)
                {
                    currentPrice = item.PurchasePrice - ((decimal)totalMonth * _5percentOfOriginal);
                    if (currentPrice < _30percentOfOriginal)
                    {
                        currentPrice = _30percentOfOriginal;
                        currentPrice = Math.Round(currentPrice, 2);
                    }
                }
                    
                Console.WriteLine(" Name of manufacturer: " + item.NameOfManufacturer +
                                  "  Purchase price: " +item.PurchasePrice + "  Current price: "+ currentPrice 
                                  + "  Difference: " + (item.PurchasePrice - currentPrice));
                 
            }
        }
        public static List<Computer> InitializationMethodComputers()
        {
            var listOfComputers = new List<Computer>();
            var computer1 = new Computer(OperatingSystem.WINDOWS, false, true,
                "Windows 10 Home\nIntel® Core™ i7 - 6700HQ processor 2.60 GHz 15.6", new DateTime(2015, 10, 5), 12,
                1321, Manufacturer.ACER);
            var computer2 = new Computer(OperatingSystem.LINUX, false, true,
                "Linux \nIntel® Core™ i5 - 6720HQ processor 1.60 GHz 15.6", new DateTime(2017, 12, 10), 24,
                4361, Manufacturer.HP);
            var computer3 = new Computer(OperatingSystem.CHROMEOS, true, true,
                "Intel® Celeron® N3350 processor Dual-core 1.10 GHz", new DateTime(2017, 12, 17), 24,
                4361, Manufacturer.LENOVO);
            var computer4 = new Computer(OperatingSystem.WINDOWS, true, true,
                "Intel® Celeron® N3350 processor Dual-core 1.10 GHz", new DateTime(2016, 08, 11), 36,
                4789, Manufacturer.LENOVO);
            listOfComputers.Add(computer1);
            listOfComputers.Add(computer2); 
            listOfComputers.Add(computer3);
            listOfComputers.Add(computer4);
            return listOfComputers;

        }
       
        public static List<MobilePhones> InitializationMobiles()
        {
            var listOfMobiles = new List<MobilePhones>();
            var mobile1 = new MobilePhones(091654234, "John Wick", true, "Bestseller", new DateTime(2018, 03, 29), 36,
                1234.54m, Manufacturer.HUAWEI);
            var mobile2 = new MobilePhones(0995432176, "Christopher Ashton", true, "new one",
                new DateTime(2016, 12, 01), 24, 3456.99m, Manufacturer.SAMSUNG);
            var mobile3 = new MobilePhones(0915432765,"Jure Juric",true,"best display",new DateTime(2017,09,01),36,2345.5m,Manufacturer.SONY);
            var mobile4 = new MobilePhones(0915432765, "Ante Antic", true, "bblue", new DateTime(2015, 08, 01), 36, 2345.5m, Manufacturer.HUAWEI);
            listOfMobiles.Add(mobile1);
            listOfMobiles.Add(mobile2);
            listOfMobiles.Add(mobile3);
            listOfMobiles.Add(mobile4);
            return listOfMobiles;

        }
        public static List<Vehicles> InitializationMethodVehicles()
        {
            var listOfVehicles= new List<Vehicles>();
            var vehicle1 = new Vehicles(new DateTime(2020,12,30),9000,"good",new DateTime(2014,12,03),180,234456.67m,Manufacturer.BMW);
            var vehicle2 = new Vehicles(new DateTime(2021,10,01),40123.34,"blue",new DateTime(2016,09,09),144,45678.65m,Manufacturer.OPEL);
            var vehicle3 = new Vehicles(new DateTime(2019,01,01),23000,"black",new DateTime(2018,10,05),120,34566.79m,Manufacturer.FORD);
            var vehicle4 = new Vehicles(new DateTime(2018, 01, 01), 23000, "black", new DateTime(2017, 10, 06), 120, 34566.79m, Manufacturer.OPEL);
            listOfVehicles.Add(vehicle1);
            listOfVehicles.Add(vehicle2);
            listOfVehicles.Add(vehicle3);
            listOfVehicles.Add(vehicle4);
            return listOfVehicles;

        }

       
    }
   
}
