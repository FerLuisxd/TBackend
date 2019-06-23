using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;
using System.Web;

namespace TBackend.Service.implementation
{
    public class TeamService : ITeamService
    {

        private ITeamRepository teamRepository;
        private ITournamentRepository tournamentRepository;
        public TeamService(ITeamRepository teamRepository, ITournamentRepository tournamentRepository)
        {
            this.teamRepository=teamRepository;
            this.tournamentRepository= tournamentRepository;
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
                Tournament tournament = tournamentRepository.Get(entity.TournamentId.GetValueOrDefault());
                tournament.NTeams = tournament.NTeams+1;
                tournamentRepository.Update(tournament);
            }
            return teamRepository.Save(entity);
        }

        public bool Update(Team entity)
        {
            Team old = teamRepository.Get(entity.Id);
            if(old.TournamentId != null){
                Tournament tournament = tournamentRepository.Get(entity.TournamentId.GetValueOrDefault());
                tournament.NTeams = tournament.NTeams-1;
                tournamentRepository.Update(tournament);
            }
            if (entity.TournamentId != null)
            {
                Tournament tournament = tournamentRepository.Get(entity.TournamentId.GetValueOrDefault());
                tournament.NTeams = tournament.NTeams+1;
                tournamentRepository.Update(tournament);
            }
            if(entity.NMembers>2){
                return teamRepository.Update(entity);
            }
            else return false;
        }
    }
}