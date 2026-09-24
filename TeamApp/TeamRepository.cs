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
            writer.Write(nonce.Length);
            writer.Write(nonce);

            writer.Write(ciphertext.Length);
            writer.Write(ciphertext);

            writer.Write(tag.Length);
            writer.Write(tag);
        }

        Directory.CreateDirectory(Path.Combine(teamDirectory, "players"));

        // Update in-memory list
        Team newTeam = new Team(name, new List<Player>(), id);
        Teams.Add(newTeam);

        updateTeamSelection(newTeam);
    }
}