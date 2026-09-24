namespace TeamApp
{
    public class Player
    {
        public string Name, Position;
        public string Idnp;
        public DateTime BirthDate;
        public Guid Id;

        public Player(string name, string position, string idnp, DateTime birthDate, Guid id) {
            Name = name;
            Position = position;
            Idnp = idnp;
            BirthDate = birthDate;
            Id = id;
        }
    }
}