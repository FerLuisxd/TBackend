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
        public TournamentService(ITournamentRepository tournamentRepository)
        //  IModeService modeService, IMatchService matchService,
        // IStatisticsService statdisticsService,
        // IPlayerService playerService)
        // 
        {
            this.tournamentRepository = tournamentRepository;
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
        
        public int generateMatches(int tournamentId, int fase){
            TournamentDto tournament = this.GetOneTournament(tournamentId);
            switch (tournament.ModeId)
            {
                case 1:
                    {
                        return modeService.GenerateMatchesMode1(tournament.Teams.ToList());
                        break;
                    }
                case 2:
                    {
                        return modeService.GenerateMatchesMode2(tournament.Teams.ToList());
                        break;
                    }
                default:
                    {
                        return modeService.GenerateMatchesMode1(tournament.Teams.ToList());
                        break;
                    }
            }
        }
        public void Handler(int tournamentId)//Solo tournamentId
        {
            int winner;
            if(this.CanGenerate(tournamentId)){
            winner = this.generateMatches(tournamentId, 1);
            Tournament aux = this.Get(tournamentId);
            aux.WinnerId = winner;
            this.Update(aux);
            }
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
            if (tournamentRepository.FindHost(entity.PlayerId).Count < 1)
                if (entity.Date < DateTime.Now.AddDays(-1))
                    return tournamentRepository.Update(entity);
                else return false;
            else return false;
        }

        public TournamentDto GetOneTournament(int id)
        {
            return tournamentRepository.getOneTournament(id);
        }
    }
}