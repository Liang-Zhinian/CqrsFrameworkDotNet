using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Registration.Infra.Data.Context;

namespace Business.Api.Code
{
    public class DataSeeder
    {
        public DataSeeder()
        {
        }

        public static void SeedTimeZones(Book2DbContext context)
        {
            if (!context.TimeZones.Any())
            {
                ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
                int i = 1;
                List<Registration.Domain.ReadModel.TimeZone> tzList = new List<Registration.Domain.ReadModel.TimeZone>();
                foreach (TimeZoneInfo timeZone in timeZones)
                {
                    tzList.Add(new Registration.Domain.ReadModel.TimeZone()
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
