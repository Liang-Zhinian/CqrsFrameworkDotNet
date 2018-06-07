using System;
namespace MAR.Domain.Models.Employees
{
    public class Job
    {
        public string Title { get; set; }

        public Job(string title)
        {
            Title = title;
        }
    }
}
