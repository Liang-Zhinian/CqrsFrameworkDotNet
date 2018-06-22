﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Domain.Models
{
    public class ScheduleLayout
    {
        public Guid Id { get; private set; }
        public int TimeZoneId { get; set; }

        public Guid TenantId { get; private set; }

        public virtual TimeZone TimeZone { get; set; }

        public virtual ICollection<ScheduleLayoutTimeSlot> TimeSlots { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}