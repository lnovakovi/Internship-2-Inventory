using System;
using System.Collections.Generic;
using System.Text;

namespace Internship2_Inventory
{
    public class Computer : TechnologicalEquipment
    {
        public OperatingSystem OS { get; set; }
        public bool Transferable { get; set; }

        public Computer(OperatingSystem oS, bool transferable, bool batteryIncluded, string description, DateTime dateOfPurchase, int monthsOfWarranty, decimal purchasePrice, Manufacturer manufacturer)
            : base(batteryIncluded, description, dateOfPurchase, monthsOfWarranty, purchasePrice, manufacturer)
        {
            OS = oS;
            Transferable = transferable;
        }
    }

    public enum OperatingSystem
    {
        LINUX = 0,
        WINDOWS = 1,
        CHROMEOS =2
        
    }
}
