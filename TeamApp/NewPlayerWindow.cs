namespace TeamApp;

public partial class NewPlayerWindow : Form
{
    public string NewPlayerName;
    public string NewPlayerPosition;
    public string NewPlayerIdnp;
    public DateTime NewPlayerBirthday;

    public NewPlayerWindow() {
        InitializeComponent();
    }

    private void addPlayerButton_Click(object sender, EventArgs e) {
        string name = nameInput.Text.Trim();
        string position = positionInput.Text.Trim();

        if (string.IsNullOrWhiteSpace(name)) {
            MessageBox.Show("Introdu numele jucătorului.");
            nameInput.Focus();

            return;
        }

        if (string.IsNullOrWhiteSpace(position)) {
            MessageBox.Show("Introdu poziția jucătorului.");
            positionInput.Focus();

            return;
        }

        if (idnpInput.Text.Length != 13 || !idnpInput.Text.All(char.IsDigit)) {
            MessageBox.Show("IDNP-ul trebuie să conțină exact 13 cifre.");
            idnpInput.Focus();

            return;
        }

        NewPlayerName = name;
        NewPlayerPosition = position;
        NewPlayerIdnp = idnpInput.Text;
        NewPlayerBirthday = birthdayInput.Value;

        DialogResult = DialogResult.OK;
        Close();
    }
}