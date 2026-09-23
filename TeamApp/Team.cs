namespace TeamApp
{
    public class Team
    {
        public string Name;
        public List<Player> Players;

        public Team(string name, List<Player> players) {
            Name = name;
            Players = players;
        }
    }
}