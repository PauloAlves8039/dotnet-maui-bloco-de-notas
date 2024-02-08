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

    private async void ItemAdd_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePage));
    }
}