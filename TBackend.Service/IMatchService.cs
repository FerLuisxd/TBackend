using TBackend.Entity;
using System.Collections.Generic;
using TBackend.Repository.dto;

namespace TBackend.Service
{

    public interface IMatchService : IService<Match>
    {
        int GenerateMatches1(List<Match> Match);
        IEnumerable<MatchDto> getMatchesTournamentId(int id);
        MatchDto getOneMatch(int id);
        IEnumerable<MatchDto> getAllMaches();
    }
}