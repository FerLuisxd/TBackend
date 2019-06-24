using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;
using System;
namespace TBackend.Service.implementation
{
    public class ModeService : IModeService
    {

        private IModeRepository modeRepository;
        private IMatchService matchRepository;
        public ModeService(IModeRepository modeRepository, IMatchService matchRepository) //Temporal debe ser Repository
        {
            this.modeRepository = modeRepository;
            this.matchRepository = matchRepository;
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
        public string GenerateMatchesMode1(List<Team> equipos, int fase, int TournamentId)
        {
            List<Match> matches = new List<Match>();
            // List<Team> teams;
            if (equipos.Count >= 2)
            {
                equipos = this.randomTeams(equipos);
            }
            // else
            // {
            //     equipos = new List<Team>();
            // }
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
                match.TournamentId = TournamentId;
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
                    matchRepository.Save(matches[i]); // MAL !!
                    Console.WriteLine("Guardo!");
                    Console.WriteLine(i);

                }
                matchRepository.GenerateMatches1(matches);

            }
            fase++;
            Console.WriteLine("WIN TEAM!");
            Console.WriteLine(winteam.Count);
            if(winteam.Count >1) { GenerateMatchesMode1(winteam, fase,TournamentId); }
            return winteam[0].Name;
        }

        public Team TrueResults(List<Team> equipos)
        {
            var random = new Random();
            int index = random.Next(equipos.Count);
            Team winner = equipos[index];
            return winner;
        }

public string GenerateMatchesMode2(List<Team> equipos, int fase, int TournamentId) 
        {
            List<Match> matches = new List<Match>();

            if (equipos.Count>=2)
            {
                equipos = this.randomTeams(equipos);
            }

            Match match = new Match();

            for (int i = 0; i < equipos.Count; i ++)
            {
                for (int j = i+1; j < equipos.Count; j ++)
                {
                    if (j < equipos.Count)
                    {
                        match = new Match();
                        match.Team1Id = equipos[i].Id;
                        match.Team1 = equipos[i];
                        match.Team2Id = equipos[j].Id;
                        match.Team2 = equipos[j];
                        match.TournamentId = TournamentId;
                        match.Fase = fase;

                        matches.Add(match);
                    }
                }
            }
            List<int> points = new List<int>();
            for (int i = 0; i < equipos.Count; i++)
            {
                int x = new int();
                x = 0;
                points.Add(x);
            }
            Team winner;
            int iwinner = 0;
            List<Team> aux;
            List<Team> winteam = new List<Team>();

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
                matchRepository.Save(matches[i]);
                Console.WriteLine("GuardoModo2!");
                Console.WriteLine(i);
            }
            matchRepository.GenerateMatches1(matches);
            //Verificando el ganador
            for (int i = 0; i < equipos.Count; i++)
            {
                for (int j = 0; j < winteam.Count; j++)
                {
                    if (equipos[i] == winteam[j])
                    {
                        points[i]++;
                    }
                }
            }

            int mayor = 0;
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i]>mayor)
                {
                    mayor=points[i];
                    iwinner = i;
                    Console.WriteLine(iwinner);
                }
            }
            return equipos[iwinner].Name;
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