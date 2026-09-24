namespace TeamApp
{
    public class Team
    {
        public string Name;
        public List<Player> Players;
        public Guid Id;

        public Team(string name, List<Player> players, Guid id) {
            Name = name;
            Players = players;
            Id = id;
        }
    }
}