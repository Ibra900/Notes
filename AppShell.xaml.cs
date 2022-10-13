using Notes.ViewModels;
using Notes.Views;

namespace Notes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(Views.NotePage), typeof(Views.NotePage));
        Routing.RegisterRoute(nameof(AddNotePage), typeof(Views.AddNotePage));
    }
}
