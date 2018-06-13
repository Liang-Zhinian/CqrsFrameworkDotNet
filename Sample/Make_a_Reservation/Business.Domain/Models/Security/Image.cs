using System;
using CqrsFramework.Domain;

namespace Business.Domain.Models.Security
{
    public class Image : BaseObject
    {
        public string ImageUrl { get; set; }
    }
}
