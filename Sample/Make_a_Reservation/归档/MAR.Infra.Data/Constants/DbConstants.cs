using System;
namespace MAR.Infra.Data.Constants
{
    public class DbConstants
    {
        public static string BusinessTable { get; private set; }
        public static string BusinessAddressTable { get; private set; }
        public static string BusinessContactTable { get; private set; }
        public static string LocationTable { get; private set; }
        public static string LocationAddressTable { get; private set; }
        public static string LocationContactTable { get; private set; }
        public static string StaffTable { get; private set; }
        public static string StaffAddressTable { get; private set; }
        public static string StaffContactTable { get; private set; }
        public static string StaffLoginLocationTable { get; private set; }
        public static string StaffLoginCredentialTable { get; private set; }

        static DbConstants()
        {
            BusinessTable = "Business";
            BusinessAddressTable = "BusinessAddress";
            BusinessContactTable = "BusinessContact";
            LocationTable = "Location";
            LocationAddressTable = "LocationAddress";
            LocationContactTable = "LocationContact";
            StaffTable = "Staff";
            StaffAddressTable = "StaffAddress";
            StaffContactTable = "StaffContact";
            StaffLoginLocationTable = "StaffLoginLocation";
            StaffLoginCredentialTable = "StaffLoginCredential";
        }
    }
}
