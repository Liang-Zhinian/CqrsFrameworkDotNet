using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Business.Infra.Data.Constants
{
    public static class DataBaseServer
    {
        public static readonly string SqlServer = "SqlServer";
        public static readonly string MySql = "MySql";
    }

    public class DbConstants
    {
        public static string Schema = "book2";

        public static string KeyType = "uniqueidentifier";
        public static string String10 = "NVarchar(10)";
        public static string String36 = "NVarchar(36)";
        public static string String255 = "NVarchar(255)";
        public static string String1000 = "NVarchar(1000)";
        public static string String2000 = "NVarchar(2000)";
        public static string String4000 = "NVarchar(4000)";

        public static string SiteTable { get; set; }

        public static string AddressTable { get; set; }
        public static string ContactTable { get; set; }
        public static string BrandingTable { get; private set; }
        public static string ImageTable { get; private set; }

        public static string TenantTable { get; private set; }
        public static string TenantAddressTable { get; private set; }
        public static string TenantContactTable { get; private set; }

        public static string LocationTable { get; private set; }
        public static string LocationAddressTable { get; private set; }
        public static string LocationContactTable { get; private set; }
        public static string LocationImageTable { get; private set; }

        public static string StaffTable { get; private set; }
        public static string StaffAddressTable { get; private set; }
        public static string StaffContactTable { get; private set; }
        public static string StaffLoginLocationTable { get; private set; }
        public static string StaffLoginCredentialTable { get; private set; }

        public static string TimeZoneTable { get; set; }
        public static string RegionTable { get; set; }

        public static string ResourceTable { get; set; }
        public static string ResourceLocationTable { get; set; }
        public static string ResourceStatusTable { get; set; }
        public static string ResourceTypeTable { get; set; }

        public static string ScheduleTypeTable { get; set; }
        public static string ScheduleTable { get; set; }
        public static string ScheduleLayoutTable { get; set; }
        public static string ScheduleLayoutTimeSlotTable { get; set; }

        public static string ServiceTable { get; set; }
        public static string ServiceCategoryTable { get; set; }


        static DbConstants()
        {
            SiteTable = "Site";
            ContactTable = "Contact";
            AddressTable = "Address";
            BrandingTable = "Branding";
            ImageTable = "Image";

            TenantTable = "Tenant";
            TenantAddressTable = "TenantAddress";
            TenantContactTable = "TenantContact";

            LocationTable = "Location";
            LocationAddressTable = "LocationAddress";
            LocationContactTable = "LocationContact";
            LocationImageTable = "LocationImage";

            StaffTable = "Staff";
            StaffAddressTable = "StaffAddress";
            StaffContactTable = "StaffContact";
            StaffLoginLocationTable = "StaffLoginLocation";
            StaffLoginCredentialTable = "StaffLoginCredential";

            TimeZoneTable = "TimeZone";
            RegionTable = "Region";

            ResourceTable = "Resource";
            ResourceLocationTable = "ResourceLocation";
            ResourceStatusTable = "ResourceStatus";
            ResourceTypeTable = "ResourceType";

            ScheduleTypeTable = "ScheduleType";
            ScheduleTable = "Schedule";
            ScheduleLayoutTable = "ScheduleLayout";
            ScheduleLayoutTimeSlotTable = "ScheduleLayoutTimeSlot";

            ServiceTable = "Service";
            ServiceCategoryTable = "ServiceCategory";


            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string provider = config["DataProvider"];

            if (provider.Equals(DataBaseServer.SqlServer, StringComparison.InvariantCultureIgnoreCase))
            {
                KeyType = "uniqueidentifier";
                String10 = "NVarchar(10)";
                String36 = "NVarchar(36)";
                String255 = "NVarchar(255)";
                String1000 = "NVarchar(1000)";
                String2000 = "NVarchar(2000)";
                String4000 = "NVarchar(4000)";
            }
            else if (provider.Equals(DataBaseServer.MySql, StringComparison.InvariantCultureIgnoreCase))
            {
                KeyType = "char(36)";
                String10 = "varchar(10)";
                String36 = "varchar(36)";
                String255 = "varchar(255)";
                String1000 = "varchar(1000)";
                String2000 = "varchar(2000)";
                String4000 = "varchar(4000)";
            }
            else
            {
                KeyType = "uniqueidentifier";
                String10 = "NVarchar(10)";
                String36 = "NVarchar(36)";
                String255 = "NVarchar(255)";
                String1000 = "NVarchar(1000)";
                String2000 = "NVarchar(2000)";
                String4000 = "NVarchar(4000)";
            }

        }
    }
}
