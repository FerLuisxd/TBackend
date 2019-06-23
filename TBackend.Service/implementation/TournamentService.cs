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
        IModeService modeService)//, IMatchService matchService)
        // IStatisticsService statdisticsService,
        // IPlayerService playerService)
        // 
        {
            this.tournamentRepository = tournamentRepository;
            this.modeService= modeService;
            // this.matchService = matchService;

            // this.modeService = modeService;
            // this.statdisticsService = statdisticsService;
            // this.playerService = playerService;
        }

        public bool CanGenerate(int tournamentId)
        {
            return tournamentRepository.CanGenerate(tournamentId);
        }

        public bool Delete(int id)
        {
            return tournamentRepository.Delete(id);
        }

        public int generateMatches(int tournamentId, int fase)
        {
            TournamentDto tournament = this.GetOneTournament(tournamentId);
            List<Team> teams = tournament.Teams.ToList();
            // for(int i= 0 ; i <  tournament.Teams.ToList().Count(); i++){
            //     Team team = new Team();
            //     team.Id = tournament.Teams.ToList()[i].Id;
            //     team.Name = tournament.Teams.ToList()[i].Name;
            //     team.NMembers = tournament.Teams.ToList()[i].NMembers;
            //     teams.Add(team);
            // }
            switch (tournament.ModeId)
            {
                case 1:
                    {
                        Console.WriteLine("CASE 1");
                        return modeService.GenerateMatchesMode1( teams, fase);
                        break;
                    }
                case 2:
                    {
                        return modeService.GenerateMatchesMode2(teams, fase);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("DEFAULT CASE");
                        return modeService.GenerateMatchesMode1(teams, fase);
                        break;
                    }
            }
        }
        public bool Handler(int tournamentId)//Solo tournamentId
        {
            int winner;
            if (this.CanGenerate(tournamentId))
            {
                Console.WriteLine("PASE CAN GENERATE");
                winner = this.generateMatches(tournamentId, 1);//ESTA ACA
                Console.WriteLine("PASE GenerateMatches");
                Console.WriteLine(winner);
                Tournament aux = this.Get(tournamentId);
                aux.Winner = winner.ToString();
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
            if (tournamentRepository.FindHost(entity.PlayerId).Count < 1)
                return tournamentRepository.Save(entity);
            else return false;
        }

        public bool Update(Tournament entity)
        {
            var old = this.Get(entity.Id);
            if (old.PlayerId != entity.PlayerId){
                Console.WriteLine("DIFERNTE");
                if (tournamentRepository.FindHost(entity.PlayerId).Count < 1)
                    if (entity.Date > DateTime.Now.AddDays(-1))
                        return tournamentRepository.Update(entity);
                    else return false;
                else return false;}
            else if (old.PlayerId == entity.PlayerId){
                Console.WriteLine("IGUAL");
                if (entity.Date > DateTime.Now.AddDays(-1))
                    return tournamentRepository.Update(entity);
                else return false;}
            else return false;
        }

        public TournamentDto GetOneTournament(int id)
        {
            return tournamentRepository.getOneTournament(id);
        }
    }
}