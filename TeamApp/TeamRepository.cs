using System.Text;

namespace TeamApp;

public class TeamRepository
{
    private byte[] _masterKey;
    public readonly List<Team> Teams;

    public TeamRepository(byte[] masterKey, List<Team> teams) {
        _masterKey = masterKey;
        Teams = teams;
    }

    public void CreateTeam(string name, Action<Team> updateTeamSelection) {
        Guid id = Guid.NewGuid();

        string teamDirectory = Path.Combine("data", "teams", id.ToString());
        Directory.CreateDirectory(teamDirectory);

        using (FileStream fs = new FileStream(Path.Combine(teamDirectory, "team.meta"), FileMode.Create,
                   FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(fs)) {
            (byte[] nonce, byte[] ciphertext, byte[] tag) =
                SecureHandler.Encrypt(_masterKey, Encoding.UTF8.GetBytes(name));
            writer.Write(nonce);

            writer.Write(ciphertext.Length);
            writer.Write(ciphertext);

            writer.Write(tag);

            writer.Flush();
            writer.Close();
        }

        Directory.CreateDirectory(Path.Combine(teamDirectory, "players"));

        // Update in-memory list
        Team newTeam = new Team(name, new List<Player>(), id);
        Teams.Add(newTeam);

        updateTeamSelection(newTeam);
    }

    public void CreatePlayer(string name, string position, string idnp, DateTime birthday, Team team,
        Action<Player> updatePlayersList) {
        Guid id = Guid.NewGuid();

        string playersDirectory = Path.Combine("data", "teams", team.Id.ToString(), "players");

        using (FileStream fs = new FileStream(Path.Combine(playersDirectory, id + ".player"), FileMode.Create,
                   FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(fs)) {
            using MemoryStream data = new MemoryStream();
            using BinaryWriter dataWriter = new BinaryWriter(data);

            dataWriter.Write(name);
            dataWriter.Write(position);
            dataWriter.Write(idnp);
            dataWriter.Write(birthday.ToBinary());

            dataWriter.Flush();
            byte[] plaintext = data.ToArray();

            (byte[] nonce, byte[] ciphertext, byte[] tag) = SecureHandler.Encrypt(_masterKey, plaintext);
            writer.Write(nonce);

            writer.Write(ciphertext.Length);
            writer.Write(ciphertext);

            writer.Write(tag);

            writer.Flush();
            writer.Close();
        }

        // Update in-memory list
        Player newPlayer = new Player(name, position, idnp, birthday, id);
        team.Players.Add(newPlayer);

        updatePlayersList(newPlayer);
    }
}