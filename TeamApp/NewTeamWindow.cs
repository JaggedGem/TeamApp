namespace TeamApp;

public partial class NewTeamWindow : Form
{
    public string NewTeamName = string.Empty;

    public NewTeamWindow() {
        InitializeComponent();
    }

    private void cancelButton_Click(object sender, EventArgs e) {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void addTeamButton_Click(object sender, EventArgs e) {
        string name = newTeamName.Text.Trim();
        if (string.IsNullOrWhiteSpace(name)) {
            MessageBox.Show("Introdu numele echipei.", "Eroare", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            newTeamName.Focus();
            return;
        }

        NewTeamName = name;

        DialogResult = DialogResult.OK;
        Close();
    }
}