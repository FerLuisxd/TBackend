using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;
using System;
using TBackend.Repository.dto;
using System.Linq;

namespace TBackend.Service.implementation
{
    public class TournamentService : ITournamentService
    {

        private ITournamentRepository tournamentRepository;
        private IModeService modeService;
        private IMatchService matchService;
        private IStatisticsService statdisticsService;
        private IPlayerService playerService;
        public TournamentService(ITournamentRepository tournamentRepository,
        IModeService modeService)
        {
            this.tournamentRepository = tournamentRepository;
            this.modeService= modeService;
        }

        public bool CanGenerate(int tournamentId)
        {
            return tournamentRepository.CanGenerate(tournamentId);
        }
        public bool Delete(int id)
        {
            return tournamentRepository.Delete(id);
        }

        public string generateMatches(int tournamentId, int fase)
        {
            var tournament = this.GetOneTournament(tournamentId);
            List<Team> teams = new List<Team>();
            for(int i= 0 ; i <  tournament.Teams.ToList().Count(); i++){
                Team team = new Team();
                team.Id = tournament.Teams.ToList()[i].Id;
                team.Name = tournament.Teams.ToList()[i].Name;
                team.NMembers = tournament.Teams.ToList()[i].NMembers;
                teams.Add(team);
            }
            switch (tournament.ModeId)
            {
                case 1:
                    {
                        Console.WriteLine("CASE 1");
                        return modeService.GenerateMatchesMode1( teams, fase,tournamentId);
                    }
                case 2:
                    {
                        return "";
                        return modeService.GenerateMatchesMode2(teams, fase,tournamentId);
                    }
                default:
                    {
                        Console.WriteLine("DEFAULT CASE");
                        return modeService.GenerateMatchesMode1(teams, fase,tournamentId);
                    }
            }
        }
        
        public bool Handler(int tournamentId)//Solo tournamentId
        {
            string winner;
            if (this.CanGenerate(tournamentId))
            {
                Console.WriteLine("PASE CAN GENERATE");
                winner = this.generateMatches(tournamentId, 1);//ESTA ACA
                Console.WriteLine("PASE GenerateMatches");
                Console.WriteLine(winner);  
                Tournament aux = this.Get(tournamentId);
                aux.Winner = winner.ToString();
                Console.WriteLine("WINNER");
                Console.WriteLine(winner.ToString());
                this.Update(aux);
                return true;
            }
            return false;
        }

        public Tournament Get(int id)
        {
            return tournamentRepository.Get(id);
        }

        public IEnumerable<Tournament> GetAll()
        {
            return tournamentRepository.GetAll();
        }

        public IEnumerable<TournamentDto> GetAllTournaments()
        {
            return tournamentRepository.GetAllTournaments();
        }

        public bool Save(Tournament entity)
        {
            if (tournamentRepository.FindHost(entity.PlayerId).Count < 1)//YA TIENE TORNEO
                return tournamentRepository.Save(entity);
            else return false;
        }

        public bool Update(Tournament entity)
        {
            var old = this.Get(entity.Id);
            if (old.PlayerId != entity.PlayerId){//PLAYER ANTIGUO 
                Console.WriteLine("DIFERNTE");
                if (tournamentRepository.FindHost(entity.PlayerId).Count < 1)//SI TIENE TORNEO
                    if (entity.Date > DateTime.Now.AddDays(-1))//))//24 HORAS ANTES MAXIMO PARA EDITAR
                        return tournamentRepository.Update(entity);
                    else return false;
                else return false;}
            else if (old.PlayerId == entity.PlayerId){//MISMO PLAYER ID
                Console.WriteLine("IGUAL");
                if (entity.Date > DateTime.Now.AddDays(-1))//24 HORAS ANTES MAXIMO PARA EDITAR
                    return tournamentRepository.Update(entity);
                else return false;
                }
            else return false;
        }

        public TournamentDto GetOneTournament(int id)
        {
            return tournamentRepository.getOneTournament(id);
        }
    }
}