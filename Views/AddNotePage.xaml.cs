using Notes.Models;
using Notes.ViewModels;

namespace Notes.Views;

public partial class AddNotePage : ContentPage
{
	public NoteInfo NoteInfo { get; set; }
	public AddNotePage()
	{
		InitializeComponent();
		this.BindingContext = new AddNotePageViewModel();
	}

    public AddNotePage(NoteInfo noteInfo)
    {
        InitializeComponent();
        this.BindingContext = new AddNotePageViewModel();

		if (noteInfo != null)
		{
			((AddNotePageViewModel)BindingContext).NoteInfo = noteInfo;
		}
    }
}