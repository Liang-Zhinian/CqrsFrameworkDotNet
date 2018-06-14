﻿using System;
using System.Collections.Generic;

namespace Reservation.Localization.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public virtual Culture Culture { get; set; }
    }
}
