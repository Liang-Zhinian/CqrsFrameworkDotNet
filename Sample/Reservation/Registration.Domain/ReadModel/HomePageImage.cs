using System;
namespace Registration.Domain.ReadModel
{
    public class HomePageImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public Guid CategoryId { get; set; }
        public ServiceCategory Category { get; set; }
        public Guid ParentCategoryId { get; set; }
        public ServiceCategory ParentCategory { get; set; }
        public int Version { get; set; }

        public HomePageImage()
        {
        }
    }
}
