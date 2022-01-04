using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechTalk.SpecFlow.CommonModels;

namespace API.Controllers
{
    public class ProjectControllers
    {
        public IResult AddProject(Project project)
        {
            if (project == null)
            {
                return NotFound();
            }
            ProjectManager projectManager  = new();
            var addProject = projectManager.Add(project);
            if (addProject.isSucess)
            {
                return Ok();
            }
            return ValidationProblem();
        }
    }
}