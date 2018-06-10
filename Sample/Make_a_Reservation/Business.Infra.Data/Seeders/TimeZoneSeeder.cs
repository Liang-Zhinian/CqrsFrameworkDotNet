using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MAR.Infra.Data.Context;

namespace MAR.Infra.Data.Seeders
{
    public class TimeZoneSeeder
    {
        public TimeZoneSeeder()
        {
            
        }

        public void SeedIt(){
            MARContext context = new MARContext();
            ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();

            int i = 1;
            List<Models.TimeZone> tzList = new List<Models.TimeZone>();
            foreach (TimeZoneInfo timeZone in timeZones)
            {
                tzList.Add(new Models.TimeZone(){
                    Id=i++,
                    DisplayName = timeZone.DisplayName,
                    StandardName = timeZone.StandardName
                });
            }
            context.TimeZones.AddRange(tzList);
            context.SaveChanges();
        }
    }
}
