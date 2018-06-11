﻿using System;
namespace Registration.Infra.Data.Constants
{
    public class DbConstants
    {
        public static string TenantTable { get; private set; }
        public static string TenantAddressTable { get; private set; }
        public static string TenantContactTable { get; private set; }
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
            TenantTable = "Tenant";
            TenantAddressTable = "TenantAddress";
            TenantContactTable = "TenantContact";
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