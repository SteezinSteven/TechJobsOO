using TechJobs.Models;
using System.Collections.Generic;
using System;

namespace TechJobs.ViewModels
{
    public class  BaseViewModel
    {
        public JobFieldType Column { get; set; } = JobFieldType.All;

        public List<JobFieldType> Columns { get; set; }

        

        public string Title { get; set; } = "";

        public BaseViewModel()
        {
            Columns = new List<JobFieldType>();

            foreach (JobFieldType enumVal in Enum.GetValues(typeof(JobFieldType)))
            {
                Columns.Add(enumVal);
            }
        }

        
        
        
       
        
     }
}
