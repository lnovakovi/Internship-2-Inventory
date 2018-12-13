using System;
using System.Collections.Generic;
using System.Text;

namespace Internship2_Inventory
{
    public class Vehicles: Inventory
    {
        public DateTime ExpirationDateOfRegistration { get; set; }
        public double Mileage { get; set; }

        public Vehicles(DateTime expirationDateOfRegistration, double mileage, string description, DateTime dateOfPurchase, int monthsOfWarranty, decimal purchasePrice, string manufacturer)
            : base(description, dateOfPurchase, monthsOfWarranty, purchasePrice, manufacturer)
        {
            ExpirationDateOfRegistration = expirationDateOfRegistration;
            Mileage = mileage;
        }
    }
}
