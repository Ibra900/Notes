//using static Android.Content.ClipData;
using Microsoft.Toolkit.Mvvm.Input;
using Notes.ViewModels;

namespace Notes.Views;

public partial class NotePage : ContentPage
{
	NotePageViewModel notePageViewModel;
	public NotePage()
	{
		InitializeComponent();
		this.BindingContext = notePageViewModel = new NotePageViewModel(Navigation);

	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		notePageViewModel.OnAppearing();
	}
}