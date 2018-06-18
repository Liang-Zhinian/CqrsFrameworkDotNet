using System;
using CqrsFramework.Domain;

namespace Business.Domain.Models.ValueObjects
{
    public class Image: ValueObject<Image>
    {
        public string ImageUrl { get; set; }
    }
}
