﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Business.Infra.Data.Context;

namespace Business.Infra.Data.Seeders
{
    public class TimeZoneSeeder
    {
        public TimeZoneSeeder()
        {
            
        }

        public void SeedIt(){
            //BusinessDbContext context = new BusinessDbContext();
            //ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();

            //int i = 1;
            //List<Business.Domain.Models.TimeZone> tzList = new List<Business.Domain.Models.TimeZone>();
            //foreach (TimeZoneInfo timeZone in timeZones)
            //{
            //    tzList.Add(new Business.Domain.Models.TimeZone(){
            //        Id=i++,
            //        DisplayName = timeZone.DisplayName,
            //        StandardName = timeZone.StandardName
            //    });
            //}
            //context.TimeZones.AddRange(tzList);
            //context.SaveChanges();
        }
    }
}
