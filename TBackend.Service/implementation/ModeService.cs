using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;
using System;
namespace TBackend.Service.implementation
{
    public class ModeService : IModeService
    {

        private IModeRepository modeRepository;
        private IMatchService matchService;
        public ModeService(IModeRepository modeRepository, IMatchService matchService)
        {
            this.modeRepository = modeRepository;
            this.matchService = matchService;
        }

        public bool Delete(int id)
        {
            return modeRepository.Delete(id);
        }
        public List<Team> randomTeams(List<Team> equipos)
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
            return equipos;

        }
        public int GenerateMatchesMode1(List<Team> equipos, int fase)
        {
            List<Match> matches = new List<Match>();
            // List<Team> teams;
            if (equipos.Count > 2)
            {
                equipos = this.randomTeams(equipos);
            }
            else
            {
                equipos = new List<Team>();
            }
            //List<Match> matches //
            //Console.WriteLine("");
            Match match = new Match();
            for (int i = 0; i < equipos.Count; i += 2)
            {
                int index = i;//random.Next(equipos.Count);
                int index2 = i + 1;//random.Next(equipos.Count);
                match = new Match();
                match.Team1Id = equipos[index].Id;
                match.Team1 = equipos[index];
                match.Team2 = equipos[index2];
                match.Team2Id = equipos[index2].Id;
                match.TournamentId = equipos[index].TournamentId.GetValueOrDefault();
                matches.Add(match);
                //}
            }
            //return matches;

            Team winner;
            List<Team> aux;
            List<Team> winteam = new List<Team>();


            if (matches.Count >= 1)
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    aux = new List<Team> { matches[i].Team1, matches[i].Team2 };
                    winner = this.TrueResults(aux);
                    winteam.Add(winner);
                    if (winner.Id == matches[i].Team1.Id)
                    {
                        matches[i].WinnerId = matches[i].Team1.Id;
                    }
                    else
                    {
                        matches[i].WinnerId = matches[i].Team2.Id;
                    }
                    matches[i].Fase = fase;
                    matchService.Save(matches[i]);

                }
                matchService.GenerateMatches1(matches);

            }
            fase++;
            if (winteam.Count == 1)
            {
                return winteam[0].Id;
            }
            else { GenerateMatchesMode1(winteam, fase); }
            return 0;
        }

        public Team TrueResults(List<Team> equipos)
        {
            var random = new Random();
            int index = random.Next(equipos.Count);
            Team winner = equipos[index];
            return winner;
        }

        public int GenerateMatchesMode2(List<Team> equipos)
        {
            return 0;

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

        public int GenerateMatchesMode2(List<Team> equipos, int fase)
        {
            throw new NotImplementedException();
        }
    }
}