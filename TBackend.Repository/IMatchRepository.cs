using TBackend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBackend.Repository.dto;

namespace TBackend.Repository
{
    public interface IMatchRepository: IRepository<Match>
    {
         List<Match> FindAllMatches(int id);
        int ReturnTournamentId(int match_id);    
        IEnumerable<MatchDto> getMatchesTournamentId(int id);
        IEnumerable<MatchDto> getMatchesTeamId(int id);
        IEnumerable<MatchDto> getMatches();
        MatchDto getMatch(int id);
    }
}