using System;
namespace Business.Domain.Entities
{
    public class Owner
    {
        public Owner()
        {
        }

        /// 
        public string ContactName { get; set; }

        /// Studio contact email address
        public string ContactEmail { get; set; }
    }
}
