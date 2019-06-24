using TBackend.Entity;
using TBackend.Repository.dto;
using System.Collections.Generic;
namespace TBackend.Service
{

    public interface ITeamService : IService<Team>
    {
        IEnumerable<TeamDto> GetAllTeams();
        TeamDto getTeam(int id);
    }
}