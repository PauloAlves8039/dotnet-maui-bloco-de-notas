using BlocoDeNotas.App.Models;

namespace BlocoDeNotas.App.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class NotePage : ContentPage
{
    public string ItemId
    {
        set
        {
            LoadNote(value);
        }
    }

    public NotePage()
	{
		InitializeComponent();

        var appDataPath = FileSystem.AppDataDirectory;
        var randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
        
        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Note note) 
        {
            File.WriteAllText(note.Filename, TextEditor.Text);
        }

        await Shell.Current.GoToAsync("..");
    }

    private async void btnExcluir_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Note note) 
        {
            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }
        }

        await Shell.Current.GoToAsync("..");
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