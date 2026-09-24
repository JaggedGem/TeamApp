namespace TeamApp
{
    public class Player
    {
        public string Name, Position;
        public int Idnp;
        public DateTime BirthDate;
        public Guid Id;

        public Player(string name, string position, int idnp, DateTime birthDate, Guid id) {
            Name = name;
            Position = position;
            Idnp = idnp;
            BirthDate = birthDate;
            Id = id;
        }
    }
}