using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;
using System.Linq;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        
        public IActionResult Index(int id )
        {

            if (jobData.Find(id) != null) 
            
            { Job singleJob = jobData.Find(id);

                JobViewModel jobViewModel = new JobViewModel()
                {
                    Name = singleJob.Name,
                    CoreCompetency = singleJob.CoreCompetency,
                    Employer = singleJob.Employer,
                    Location = singleJob.Location,
                    PositionType = singleJob.PositionType
                };
                
                    return View(jobViewModel);
            };
            
               
            
            // TODO #1 - get the Job with the given ID and pass it into the view

            return View();
        
        }


        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        { if(ModelState.IsValid)
            {
                Job newJob = new Job
                {
                    Name = newJobViewModel.Name,
                    CoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetencyID),
                    Employer = jobData.Employers.Find(newJobViewModel.EmployerID),
                    Location = jobData.Locations.Find(newJobViewModel.LocationID),
                    PositionType = jobData.PositionTypes.Find(newJobViewModel.PositionTypeID)
                };
                jobData.Jobs.Add(newJob);
                
                return Redirect("Index");
                
            }
            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.

            return View(newJobViewModel);
        }
    }
}
