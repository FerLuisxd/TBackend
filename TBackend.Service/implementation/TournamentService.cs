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
        public TournamentService(ITournamentRepository tournamentRepository, IModeService modeService)
        {
            this.tournamentRepository = tournamentRepository;
            this.modeService = modeService;
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
                        matches= modeService.GenerateMatchesMode1(teams);
                        break;
                    }
                default:
                    {
                        matches =modeService.GenerateMatchesMode1(teams);
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
                    aux = new List<Team> { matches[i].Team1Id, matches[i].Team2Id };
                    winner = TrueResults(aux);
                    winteam.Add(winner);
                    if (winner.Id == matches[i].TeamId1.Id)
                    {
                        matches[i].Winner = true;
                    }
                    else
                    {
                        matches[i].Winner = false;
                    }
                    matches[i].Fase = fase;

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