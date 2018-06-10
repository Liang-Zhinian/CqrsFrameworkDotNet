using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MAR.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MAR.Api.Code
{
    public class DataSeeder
    {
        public DataSeeder()
        {
        }

        public static void SeedTimeZones(MARContext context)
        {
            if (!context.TimeZones.Any())
            {
                ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
                int i = 1;
                List<Infra.Data.Models.TimeZone> tzList = new List<Infra.Data.Models.TimeZone>();
                foreach (TimeZoneInfo timeZone in timeZones)
                {
                    tzList.Add(new Infra.Data.Models.TimeZone()
                    {
                        Id = i++,
                        DisplayName = timeZone.DisplayName,
                        StandardName = timeZone.StandardName
                    });
                }
                context.TimeZones.AddRange(tzList);
                context.SaveChanges();
            }
        }
    }
}
