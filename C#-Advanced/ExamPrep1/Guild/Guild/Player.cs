using System.Text;

namespace Guild
{
    public class Player
    {
        public string Name { get; private set; }
        public string Class { get; private set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        public Player(string name, string clas)
        {
            Name = name;
            Class = clas;
            Rank = "Trial";
            Description = "n/a";
        }
        public override string ToString()
        {
            StringBuilder myStringToReturn = new StringBuilder();
            myStringToReturn.AppendLine($"Player {this.Name}: {this.Class}");
            myStringToReturn.AppendLine($"Rank: {this.Rank}");
            myStringToReturn.AppendLine($"Description: {this.Description}");
            return myStringToReturn.ToString().TrimEnd();
        }
    }
}
