using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Catalog.Api.Infrastructure.Constants
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

        public static string ServiceItemTable { get; set; }
        public static string ServiceCategoryTable { get; set; }


        static DbConstants()
        {
            ServiceItemTable = "ServiceItem";
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
