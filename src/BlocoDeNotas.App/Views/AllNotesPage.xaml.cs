using BlocoDeNotas.App.Models;

namespace BlocoDeNotas.App.Views;

public partial class AllNotesPage : ContentPage
{
	public AllNotesPage()
	{
		InitializeComponent();
		BindingContext = new AllNotes();
	}

    protected override void OnAppearing()
    {
        ((AllNotes)BindingContext).LoadNotes();
    }
}