using System;
namespace Registration.Infra.Data.Constants
{
    public class DbConstants
    {
        public static string BrandingTable { get; private set; }
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
        public static string LocationImageTable { get; private set; }
        public static string TimeZoneTable { get; set; }
        public static string RegionTable { get; set; }

        static DbConstants()
        {
            BrandingTable = "BrandingView";
            TenantTable = "TenantView";
            TenantAddressTable = "TenantAddressView";
            TenantContactTable = "TenantContactView";
            LocationTable = "LocationView";
            LocationAddressTable = "LocationAddressView";
            LocationContactTable = "LocationContactView";
            LocationImageTable = "LocationImageView";
            StaffTable = "StaffView";
            StaffAddressTable = "StaffAddressView";
            StaffContactTable = "StaffContactView";
            StaffLoginLocationTable = "StaffLoginLocationView";
            StaffLoginCredentialTable = "StaffLoginCredentialView";
            TimeZoneTable = "TimeZoneView";
            RegionTable = "RegionView";
        }
    }
}
