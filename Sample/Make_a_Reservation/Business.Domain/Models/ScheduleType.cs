﻿using System;
namespace Business.Domain.Models
{
    //public class ScheduleTypeTable
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    public string Label { get; set; }
    //}

    public enum ScheduleType
    {
        All = 0,
        DropIn,
        Enrollment,
        Appointment,
        Resource,
        Media,
        Arrival
    }
}