namespace TeamApp;

public partial class NewTeamWindow : Form
{
    public string NewTeamName;

    public NewTeamWindow() {
        InitializeComponent();
    }

    private void cancelButton_Click(object sender, EventArgs e) {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void addTeamButton_Click(object sender, EventArgs e) {
        NewTeamName = newTeamName.Text;

        DialogResult = DialogResult.OK;
        Close();
    }
}