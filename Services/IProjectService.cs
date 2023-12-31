﻿using MVPStudio_Creative_Agency.Models;
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

        Task<Project> AddNewProject(Project project);

        Task<bool> DeleteProjectAsync(int id);

        Task UpdateProjectTeam(int id, int teamId);

        Task UpdateProjectProgress(int projectId, int progressAmount);

    }
}
