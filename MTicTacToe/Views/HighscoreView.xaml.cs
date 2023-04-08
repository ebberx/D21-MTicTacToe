using MTicTacToe.ViewModel;

namespace MTicTacToe.Views;

public partial class HighscoreView : ContentPage
{
	public HighscoreView(HighscoreViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}