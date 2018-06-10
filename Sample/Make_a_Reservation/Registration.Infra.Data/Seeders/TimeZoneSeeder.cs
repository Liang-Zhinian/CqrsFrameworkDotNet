using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Registration.Infra.Data.Context;

namespace Registration.Infra.Data.Seeders
{
    public class TimeZoneSeeder
    {
        public TimeZoneSeeder()
        {
            
        }

        public void SeedIt(){
            Book2DbContext context = new Book2DbContext();
            ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();

            int i = 1;
            List<Domain.ReadModel.TimeZone> tzList = new List<Domain.ReadModel.TimeZone>();
            foreach (TimeZoneInfo timeZone in timeZones)
            {
                tzList.Add(new Domain.ReadModel.TimeZone(){
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
