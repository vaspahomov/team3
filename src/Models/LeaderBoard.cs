using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace thegame.Models
{
    public class LeaderBoard
    {
        private List<LeaderBoardRecord> ReadLeaderTable(string filename = "leaderboard.txt")
        {
            string stringContent = "";
            if (File.Exists(filename))
                stringContent = File.ReadAllText(filename);
            var result = JsonConvert.DeserializeObject<List<LeaderBoardRecord>>(stringContent);
            if (result == null)
                return new List<LeaderBoardRecord>();
            return result
                .OrderByDescending(a => a.Score)
                .ToList();
        }

        public List<LeaderBoardRecord> GetTopSessions(int count = 5, string filename = "leaderboard.txt")
        {
            return ReadLeaderTable(filename)
                .OrderByDescending(a => a.Score)
                .Take(count)
                .ToList();
        }

        public void SaveNewResult(LeaderBoardRecord newRecord, string filename = "leaderboard.txt")
        {
            var oldTable = ReadLeaderTable(filename);
            oldTable.Add(newRecord);
            var result = JsonConvert.SerializeObject(oldTable);
            File.WriteAllText(filename, result);
        }

        public void ClearAllResults(string filename)
        {
            File.WriteAllText(filename, "");
        }
    }
}