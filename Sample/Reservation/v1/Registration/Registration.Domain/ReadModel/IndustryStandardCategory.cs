using System;
namespace Registration.Domain.ReadModel
{
    public class IndustryStandardCategory
    {
        public IndustryStandardCategory()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
        public virtual IndustryStandardCategory ParentCategory { get; set; }
    }
}
