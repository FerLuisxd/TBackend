using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;
using System;
namespace TBackend.Service.implementation
{
    public class ModeService : IModeService
    {

        private IModeRepository modeRepository;
        public ModeService(IModeRepository modeRepository)
        {
            this.modeRepository=modeRepository;
        }
        
        public bool Delete(int id)
        {
            return modeRepository.Delete(id);
        }

        public List<Match> GenerateMatchesMode1(List<Team> equipos)
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
                                       //if (index != index2)
                                       //{
                    match = new Match();
                    match.Team1 = equipos[index];
                    match.Team2 = equipos[index2];
                    matches.Add(match);
                    //}
                }

                return matches;
            }
            else
            {
                List<Match> matches0 = new List<Match>();
                return matches0;
            }
                
            
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