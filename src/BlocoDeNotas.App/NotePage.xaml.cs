namespace BlocoDeNotas.App;

public partial class NotePage : ContentPage
{
    string fileName = Path.Combine(FileSystem.AppDataDirectory, "nota.txt");
    
    public NotePage()
	{
		InitializeComponent();
        if (File.Exists(fileName)) 
        {
            TextEditor.Text = File.ReadAllText(fileName);
        }
	}

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
        File.WriteAllText(fileName, TextEditor.Text);
    }

    private void btnExcluir_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(fileName)) 
        {
            File.Delete(fileName);
        }

        TextEditor.Text = string.Empty;
    }
}