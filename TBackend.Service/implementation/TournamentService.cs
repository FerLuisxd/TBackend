using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;
using System;


namespace TBackend.Service.implementation
{
    public class TournamentService : ITournamentService
    {

        private ITournamentRepository tournamentRepository;
        private IModeService modeService;
        private IMatchService matchService;
        private IStatisticsService statdisticsService;
        private IPlayerService playerService;
        public TournamentService(ITournamentRepository tournamentRepository, IModeService modeService, IMatchService matchService,
        IStatisticsService statdisticsService,
        IPlayerService playerService)
        {
            this.matchService = matchService;
            this.tournamentRepository = tournamentRepository;
            this.modeService = modeService;
            this.statdisticsService = statdisticsService;
            this.playerService = playerService;
        }

        public bool CanGenerate(int tournamentId)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            return tournamentRepository.Delete(id);
        }

        public void Fase(List<Team> teams, Tournament tournament, int fase)
        {
            List<Match> matches;//= modeService.GenerateMatchesMode1(teams);
            switch (tournament.ModeId)
            {
                case 1:
                    {
                        matches = modeService.GenerateMatchesMode1(teams);
                        break;
                    }
                default:
                    {
                        matches = modeService.GenerateMatchesMode1(teams);
                        break;
                    }
            }

            Team winner;
            List<Team> aux;
            List<Team> winteam = new List<Team>();
            if (matches.Count >= 1)
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    aux = new List<Team> { matches[i].Team1, matches[i].Team2 };
                    winner = TrueResults(aux);
                    winteam.Add(winner);
                    if (winner.Id == matches[i].Team1.Id)
                    {
                        matches[i].Winner = true;
                    }
                    else
                    {
                        matches[i].Winner = false;
                    }
                    matches[i].Fase = fase;

                }
                for (int i = 0; i < matches.Count; i++)
                {

                    matchService.Save(matches[i]);

                    if (matches[i].Fase == 2)
                    {
                        if (matches[i].Winner) tournament.Winner = matches[i].Team1.Name;
                        else tournament.Winner = matches[i].Team2.Name;
                        tournamentRepository.Update(tournament);
                    }
                    var random = new Random();
                    var team1Count = playerService.getPlayersFromTeamId(matches[i].Team1.Id);
                    for (int j = 0; j < team1Count.Count; j++)
                    {
                        Statistics statistics = new Statistics();
                        statistics.MatchId = matches[i].Id;
                        statistics.PlayerId = team1Count[j].Id;
                        statistics.Assists = random.Next(10, 40);
                        statistics.Deaths = random.Next(2, 15);
                        statistics.Assists = random.Next(10, 40);
                        statistics.Damage = random.Next(5000, 13000);
                        statdisticsService.Save(statistics);
                    } // numero de jugadores
                    var team2Count = playerService.getPlayersFromTeamId(matches[i].Team2.Id);
                    for (int j = 0; j < team2Count.Count; j++)
                    {
                        Statistics statistics = new Statistics();
                        statistics.MatchId = matches[i].Id;
                        statistics.PlayerId = team2Count[j].Id;
                        statistics.Assists = random.Next(10, 40);
                        statistics.Deaths = random.Next(2, 15);
                        statistics.Assists = random.Next(10, 40);
                        statistics.Damage = random.Next(5000, 13000);
                        statdisticsService.Save(statistics);
                    } // numero de jugadores
                    //matches[i].Id;
                }

                fase++;
                if (winteam.Count == 1)
                {
                    return;
                }
                else { Fase(winteam, tournament, fase); }

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

        public bool Save(Tournament entity)
        {
            if (tournamentRepository.FindHost(entity.PlayerId).Count < 1)
                return tournamentRepository.Save(entity);
            else return false;
        }

        public Team TrueResults(List<Team> equipos)
        {
            throw new NotImplementedException();
        }

        public bool Update(Tournament entity)
        {
            if (tournamentRepository.FindHost(entity.PlayerId).Count < 1)
                if (entity.Date < DateTime.Now.AddDays(-1))
                    return tournamentRepository.Update(entity);
                else return false;
            else return false;
        }
    }
}