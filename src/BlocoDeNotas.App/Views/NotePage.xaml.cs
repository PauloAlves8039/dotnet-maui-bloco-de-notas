using BlocoDeNotas.App.Models;

namespace BlocoDeNotas.App.Views;

public partial class NotePage : ContentPage
{
    public NotePage()
	{
		InitializeComponent();

        var appDataPath = FileSystem.AppDataDirectory;
        var randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
        
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

    public void LoadNote(string fileName) 
    {
        var note = new Note();
        note.Filename = fileName;

        if (File.Exists(fileName))
        {
            note.Date = File.GetCreationTime(fileName);
            note.Text = File.ReadAllText(fileName);
        }

        BindingContext = note;
    }
}