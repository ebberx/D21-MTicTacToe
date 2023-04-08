using MTicTacToe.Views;

namespace MTicTacToe;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(HighscoreView), typeof(HighscoreView));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
	}
}
