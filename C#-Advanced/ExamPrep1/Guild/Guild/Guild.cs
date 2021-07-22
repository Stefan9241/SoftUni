using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Guild
{
    public class Guild
    {
        private List<Player> players;
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count
        {
            get
            {
                return this.players.Count;
            }
        }
        public Guild(string name, int capacity)
        {
            this.players = new List<Player>();
            Name = name;
            Capacity = capacity;
        }

        public void AddPlayer(Player player)
        {
            if (Count + 1 <= Capacity && !players.Any(x => x.Name == player.Name))
            {
                players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            bool isExist = false;
            if (players.Exists(x => x.Name == name))
            {
                isExist = true;
                Player playerToRemove = players.Find(x => x.Name == name);
                players.Remove(playerToRemove);
            }
            return isExist;
        }

        public void PromotePlayer(string name)
        {
            Player playerToPromote = players.FirstOrDefault(x => x.Name == name && x.Rank == "Trial");
            if (playerToPromote != null)
            {
                playerToPromote.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player playerToDemote = players.FirstOrDefault(x => x.Name == name && x.Rank != "Trial");
            if (playerToDemote != null)
            {
                playerToDemote.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string clas)
        {
            var playersToRemove = new List<Player>(players.Where(x=> x.Class == clas));
            for (int i = 0; i < playersToRemove.Count; i++)
            {
                var curPlayer = playersToRemove[i];
                players.Remove(curPlayer);
            }
            Player[] arr = playersToRemove.ToArray();
            return  arr;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in players)
            {
                sb.AppendLine($"Player {player.Name}: {player.Class}");
                sb.AppendLine($"Rank: {player.Rank}");
                sb.AppendLine($"Description: {player.Description}");
            }

            return sb.ToString();
        }
    }
}
