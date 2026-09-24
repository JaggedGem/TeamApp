namespace TeamApp
{
    public class Player
    {
        public string Name, Position;
        public int IDNP;
        public DateTime BirthDate;

        public Player(string name, string position, int idnp, DateTime birthDate) {
            Name = name;
            Position = position;
            IDNP = idnp;
            BirthDate = birthDate;
        }
    }
}