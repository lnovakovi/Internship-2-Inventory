using System;
using System.Collections.Generic;
using System.Text;

namespace Internship2_Inventory
{
    public class MobilePhones : TechnologicalEquipment
    {
        public int PhoneNumber { get; set; }
        public string NameSurname { get; set; }

        public MobilePhones(int phoneNumber, string nameSurname, bool batteryIncluded, string description, DateTime dateOfPurchase, int monthsOfWarranty, decimal purchasePrice, string manufacturer)
            : base(batteryIncluded, description, dateOfPurchase, monthsOfWarranty, purchasePrice, manufacturer)
        {
            PhoneNumber = phoneNumber;
            NameSurname = nameSurname;
        }
    }
}
