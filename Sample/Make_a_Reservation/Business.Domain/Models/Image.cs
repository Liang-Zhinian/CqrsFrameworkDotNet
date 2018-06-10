using System;
namespace Business.Domain.Models
{
    public class Image
    {
        public int ImageId { get; private set; }
        public string ImageUrl { get; private set; }

        public Image()
        {
        }

        public Image(int imageId, string imageUrl)
        {
            ImageId = imageId;
            ImageUrl = imageUrl;
        }
    }
}
