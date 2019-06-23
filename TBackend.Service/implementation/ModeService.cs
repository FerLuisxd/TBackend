using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;
using System;
namespace TBackend.Service.implementation
{
    public class ModeService : IModeService
    {

        private IModeRepository modeRepository;
        private IMatchRepository matchRepository;
        public ModeService(IModeRepository modeRepository, IMatchRepository matchRepository)
        {
            this.modeRepository=modeRepository;
            this.matchRepository=matchRepository;
        }
        
        public bool Delete(int id)
        {
            return modeRepository.Delete(id);
        }

        public int GenerateMatchesMode1(List<Team> equipos, int fase)
        {
            if (equipos.Count >= 2)
            {
                HashSet<int> randomNumbers = new HashSet<int>();
                int n = equipos.Count;
                int number = 0;
                var random = new Random();

                //var random = new Random();
                int m = n;
                while (n > 1)
                {
                    do
                    {
                        number = random.Next(m);
                    } while (randomNumbers.Contains(number));
                    n--;
                    randomNumbers.Add(number);
                    int k = number;
                    Team value = equipos[k];
                    equipos[k] = equipos[n];
                    equipos[n] = value;
                }//REORDENA LA LISTA DE EQUIPOS DE MANERA ALEATORIA

                List<Match> matches = new List<Match>();

                Match match = new Match();
                for (int i = 0; i < equipos.Count; i += 2)
                {
                    int index = i;//random.Next(equipos.Count);
                    int index2 = i + 1;//random.Next(equipos.Count);

                    match = new Match();
                    match.Team1 = equipos[index];
                    match.Team2 = equipos[index2];
                    matches.Add(match);
                    //}
                }
            }
            else
            {
                List<Match> matches = new List<Match>();
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
                        matches[i].WinnerId = matchRepository[i].Team1.Id;
                    }
                    else
                    {
                        matches[i].WinnerId = matchRepository[i].Team2.Id;
                    }
                    matches[i].Fase = fase;
                }
                for (int i = 0; i < matches.Count; i++)
                {

                    matchService.Save(matches[i]);

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
                }
                fase++;
                if (winteam.Count == 1)
                {
                    return winteam[0].Id;
                }
                else { GenerateMatchesMode1(winteam, fase); }
            }
        }

        public Team TrueResults(List<Team> equipos)
        {
            var random = new Random();
            int index = random.Next(equipos.Count());
            Team winner = equipos[index];
            return winner;
        }

        public int GenerateMatchesMode2(List<Team> equipos)
        {


        }

        public Mode Get(int id)
        {
            return modeRepository.Get(id);
        }

        public IEnumerable<Mode> GetAll()
        {
           return modeRepository.GetAll();
        }

        public bool Save(Mode entity)
        {
            return modeRepository.Save(entity);
        }

        public bool Update(Mode entity)
        {
            return modeRepository.Update(entity);
        }
    }
}