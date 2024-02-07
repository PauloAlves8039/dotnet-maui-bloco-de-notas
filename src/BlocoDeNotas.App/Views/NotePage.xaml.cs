using BlocoDeNotas.App.Models;

namespace BlocoDeNotas.App.Views;

public partial class NotePage : ContentPage
{
    string fileName = Path.Combine(FileSystem.AppDataDirectory, "nota.txt");
    
    public NotePage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
        
        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Note note) 
        {
            File.WriteAllText(note.Filename, TextEditor.Text);
        }
    }

    private void btnExcluir_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Note note) 
        {
            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }
        }
    }

    public void LoadNote(string filename) 
    {
        var note = new Note();
        note.Filename = fileName;

        if (File.Exists(fileName))
        {
            note.Date = File.GetCreationTime(filename);
            note.Text = File.ReadAllText(filename);
        }

        BindingContext = note;
    }
}