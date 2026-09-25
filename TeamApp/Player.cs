namespace TeamApp
{
    public class Player
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Idnp { get; set; }
        public DateTime Birthday { get; set; }

        public Player(string name, string position, string idnp, DateTime birthday, Guid id) {
            Name = name;
            Position = position;
            Idnp = idnp;
            Birthday = birthday;
            Id = id;
        }
    }
}