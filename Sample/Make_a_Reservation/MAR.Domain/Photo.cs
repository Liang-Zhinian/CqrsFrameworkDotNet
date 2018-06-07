using System;
using CqrsFramework.Extensions.Domain;

namespace MAR.Domain
{
    public class Photo
    {
        //public string Title { get; set; }
        public string Url { get; set; }
        //public string FileName { get; set; }

        public Photo(string url)
        {
            Url = url;
        }
    }
}
