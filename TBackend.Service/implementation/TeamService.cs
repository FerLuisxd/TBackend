using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;
using System.Web;

namespace TBackend.Service.implementation
{
    public class TeamService : ITeamService
    {

        private ITeamRepository teamRepository;
        private ITournamentService tournamentService;
        public TeamService(ITeamRepository teamRepository, ITournamentService tournamentService)
        {
            this.teamRepository=teamRepository;
            this.tournamentService= new TournamentService();
            //this.tournamentService = HttpContext.RequestServices.GetService(typeof(ISomeService));
        }
        
        public bool Delete(int id)
        {
            return teamRepository.Delete(id);
        }

        public Team Get(int id)
        {
            return teamRepository.Get(id);
        }

        public IEnumerable<Team> GetAll()
        {
           return teamRepository.GetAll();
        }

        public bool Save(Team entity)
        {
            if (entity.TournamentId != null)
            {
                Tournament tournament = tournamentService.Get(entity.TournamentId.GetValueOrDefault());
                tournament.NTeams = tournament.NTeams+1;
                tournamentService.Update(tournament);
            }
            return teamRepository.Save(entity);
        }

        public bool Update(Team entity)
        {
            if (entity.TournamentId != null)
            {
                Tournament tournament = tournamentService.Get(entity.TournamentId.GetValueOrDefault());
                tournament.NTeams = tournament.NTeams+1;
                tournamentService.Update(tournament);
            }
            return teamRepository.Update(entity);
        }
    }
}