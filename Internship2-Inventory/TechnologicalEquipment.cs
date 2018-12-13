using System;
using System.Collections.Generic;
using System.Text;

namespace Internship2_Inventory
{
    public class TechnologicalEquipment : Inventory
    {
        public bool BatteryIncluded { get; set; }

        public TechnologicalEquipment(bool batteryIncluded, string description, DateTime dateOfPurchase, int monthsOfWarranty, decimal purchasePrice, string manufacturer)
            : base(description, dateOfPurchase, monthsOfWarranty, purchasePrice, manufacturer)
        {
            BatteryIncluded = batteryIncluded;
        }
    }
}
