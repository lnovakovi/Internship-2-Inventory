using System;
using System.Collections.Generic;
using System.Text;

namespace Internship2_Inventory
{
    public class Computer : TechnologicalEquipment
    {
        public string OS { get; set; }
        public bool Transferable { get; set; }

        public Computer(string oS, bool transferable, bool batteryIncluded, string description, DateTime dateOfPurchase, int monthsOfWarranty, decimal purchasePrice, string manufacturer)
            : base(batteryIncluded, description, dateOfPurchase, monthsOfWarranty, purchasePrice, manufacturer)
        {
            OS = oS;
            Transferable = transferable;
        }
    }
}
