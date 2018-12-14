using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Internship2_Inventory
{
    public class Inventory
    {
        public Guid SerialNumber { get; set; }
        public string Description { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int MonthsOfWarranty { get; set; }
        public decimal PurchasePrice { get; set; }
        public Manufacturer  NameOfManufacturer { get; set; }

        public Inventory(string description, DateTime dateOfPurchase, int monthsOfWarranty, decimal purchasePrice, Manufacturer manufacturer)
        {
            SerialNumber = Guid.NewGuid();
            Description = description;
            DateOfPurchase = dateOfPurchase;
            MonthsOfWarranty = monthsOfWarranty;
            PurchasePrice = purchasePrice;
            NameOfManufacturer = manufacturer;
        }
    }

    public enum Manufacturer
    {
        Samsung =0,
        Huawei = 1,
        Sony= 2,
        BMW = 3,
        Opel = 4,
        Ford = 5,
        Acer = 6,
        HP = 7,
        Lenovo = 8
    }

   
    
}
