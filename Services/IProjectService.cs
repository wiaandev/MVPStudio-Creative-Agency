using MVPStudio_Creative_Agency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.Services
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjects(); //GET all Projects 
        Task<Project> GetSingleProject(int id);

        Task<List<Client>> RefreshDataAsync();

        Task<List<Project>> AddNewProject(Project project);
    }
}
