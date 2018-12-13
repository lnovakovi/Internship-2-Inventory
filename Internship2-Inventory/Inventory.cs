﻿using System;
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
        public string NameOfManufacturer { get; set; }

        public Inventory(string description, DateTime dateOfPurchase, int monthsOfWarranty, decimal purchasePrice, string manufacturer)
        {
            SerialNumber = Guid.NewGuid();
            Description = description;
            DateOfPurchase = dateOfPurchase;
            MonthsOfWarranty = monthsOfWarranty;
            PurchasePrice = purchasePrice;
            NameOfManufacturer = manufacturer;
        }
    }

   
    
}
