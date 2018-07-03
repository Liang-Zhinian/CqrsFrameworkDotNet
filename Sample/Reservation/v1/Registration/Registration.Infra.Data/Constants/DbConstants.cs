using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Registration.Infra.Data.Constants
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
        public static string MediumBlob = "text";

        public static string HomePageImageTable { get; set; }

        public static string AddressTable { get; set; }
        public static string ContactTable { get; set; }
        public static string BrandingTable { get; private set; }
        public static string ImageTable { get; private set; }

        public static string SiteTable { get; private set; }
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

        public static string ServiceItemTable { get; set; }
        public static string ServiceCategoryTable { get; set; }


        static DbConstants()
        {
            HomePageImageTable = "V_HomePageImage";

            ContactTable = "V_Contact";
            AddressTable = "V_Address";
            BrandingTable = "V_Branding";
            ImageTable = "V_Image";

            TenantTable = "V_Tenant";
            SiteTable = "V_Site";

            LocationTable = "V_Location";
            LocationImageTable = "V_LocationImage";

            StaffTable = "V_Staff";
            StaffLoginLocationTable = "V_StaffLoginLocation";
            StaffLoginCredentialTable = "V_StaffLoginCredential";

            TimeZoneTable = "V_TimeZone";
            RegionTable = "V_Region";

            ResourceTable = "V_Resource";
            ResourceLocationTable = "V_ResourceLocation";
            ResourceStatusTable = "V_ResourceStatus";
            ResourceTypeTable = "V_ResourceType";

            ScheduleTypeTable = "V_ScheduleType";
            ScheduleTable = "V_Schedule";
            ScheduleLayoutTable = "V_ScheduleLayout";
            ScheduleLayoutTimeSlotTable = "V_ScheduleLayoutTimeSlot";

            ServiceItemTable = "V_ServiceItem";
            ServiceCategoryTable = "V_ServiceCategory";


            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string provider = config["DataProvider"];

            if (provider.Equals(DataBaseServer.SqlServer, StringComparison.InvariantCultureIgnoreCase))
            {
                KeyType = "uniqueidentifier";
                String10 = "NVarchar(10)";
                String36 = "nvarchar(36)";
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
                MediumBlob = "mediumtext";
            }
            else
            {
                KeyType = "uniqueidentifier";
                String10 = "NVarchar(10)";
                String255 = "NVarchar(255)";
                String1000 = "NVarchar(1000)";
                String2000 = "NVarchar(2000)";
                String4000 = "NVarchar(4000)";
            }

        }
    }
}
