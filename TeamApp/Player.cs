using System;

namespace TeamApp
{
    public class Player
    {
        public string name, post;
        public int idnp;
        public DateTime birthDate;
        
        public Player(string name, string post, int idnp,  DateTime birthDate)
        {
            this.name = name;
            this.post = post;
            this.idnp = idnp;
            this.birthDate = birthDate;
        }
    }
}