using Notes.Services.NoteService;

namespace Notes;

public partial class App : Application
{
	public static NoteService _noteService;

	public static NoteService NoteService
	{
		get
		{
			if ( _noteService == null )
			{
				_noteService = new NoteService(Path.Combine(Environment.GetFolderPath
					(Environment.SpecialFolder.LocalApplicationData), "NoteDB.db1"));
			}
			return _noteService;
		}
	}
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
