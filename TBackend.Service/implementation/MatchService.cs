using System;
using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;
using TBackend.Repository.dto;

namespace TBackend.Service.implementation
{
    public class MatchService : IMatchService
    {

        private IMatchRepository matchRepository;
        private IPlayerRepository playerRepository;
        private IStatisticsRepository statdisticsRepository;
        public MatchService(IMatchRepository matchRepository,IPlayerRepository playerRepository, IStatisticsRepository statdisticsRepository)
        {
            this.playerRepository=playerRepository;
            this.matchRepository=matchRepository;
            this.statdisticsRepository= statdisticsRepository;
        }
        
        public bool Delete(int id)
        {
            return matchRepository.Delete(id);
        }

        public int GenerateMatches1(List<Match> matches)
        {
                for (int i = 0; i < matches.Count; i++)
                {

                    var random = new Random();
                    var team1Count = playerRepository.getPlayersFromTeamId(matches[i].Team1.Id);
                    for (int j = 0; j < team1Count.Count; j++)
                    {
                        Statistics statistics = new Statistics();
                        statistics.MatchId = matches[i].Id;
                        statistics.PlayerId = team1Count[j].Id;
                        statistics.Assists = random.Next(10, 40);
                        statistics.Deaths = random.Next(2, 15);
                        statistics.Kills= random.Next(0,30);
                        statistics.Assists = random.Next(10, 40);
                        statistics.Damage = random.Next(5000, 13000);
                        statdisticsRepository.Save(statistics);
                    } // numero de jugadores
                    var team2Count = playerRepository.getPlayersFromTeamId(matches[i].Team2.Id);
                    for (int j = 0; j < team2Count.Count; j++)
                    {
                        Statistics statistics = new Statistics();
                        statistics.MatchId = matches[i].Id;
                        statistics.PlayerId = team2Count[j].Id;
                        statistics.Assists = random.Next(10, 40);
                        statistics.Deaths = random.Next(2, 15);
                        statistics.Kills= random.Next(0,30);
                        statistics.Assists = random.Next(10, 40);
                        statistics.Damage = random.Next(5000, 13000);
                        statdisticsRepository.Save(statistics);
                    } // numero de jugadores
                }
                return 0;
        }

        public Match Get(int id)
        {
            return matchRepository.Get(id);
        }

        public IEnumerable<Match> GetAll()
        {
           return matchRepository.GetAll();
        }

        public IEnumerable<MatchDto> getAllMaches()
        {
            return matchRepository.getMatches();
        }

        public IEnumerable<MatchDto> getMatchesTournamentId(int id)
        {
            return matchRepository.getMatchesTournamentId(id);
        }

        public MatchDto getOneMatch(int id)
        {
            return matchRepository.getMatch(id);
        }

        public bool Save(Match entity)
        {
            return matchRepository.Save(entity);
        }

        public bool Update(Match entity)
        {
            return matchRepository.Update(entity);
        }
        public IEnumerable<MatchDto> getMatchesTeamId(int id){
            return matchRepository.getMatchesTeamId(id);
        }
    }
}