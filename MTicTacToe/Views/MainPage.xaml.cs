
using Microsoft.AspNetCore.SignalR.Client;
using MTicTacToe.ViewModel;
using System.Diagnostics;

namespace MTicTacToe;

public partial class MainPage : ContentPage
{
	//bool placeX = true;
	//int count = 0;
	//List<Button> buttons = new List<Button>();

	public MainPage(MainPageViewModel viewModel)
	{
		BindingContext = viewModel;
		viewModel.Reset += ResetBoard;
		viewModel.UpdateBoard += UpdateBoard;
		InitializeComponent();
	}

	private void ResetBoard() {
		btn1.Text = "";
		btn2.Text = "";
		btn3.Text = "";
		btn4.Text = "";
		btn5.Text = "";
		btn6.Text = "";
		btn7.Text = "";
		btn8.Text = "";
		btn9.Text = "";
		//count = 0;
		//buttons.Clear();
		Debug.WriteLine("Reset the board");
	}

	private async void UpdateBoard(char[] board) {
        btn1.Text = board[0].ToString();
        btn2.Text = board[1].ToString();
		btn3.Text = board[2].ToString();
		btn4.Text = board[10].ToString();
		btn5.Text = board[11].ToString();
		btn6.Text = board[12].ToString();
		btn7.Text = board[20].ToString();
		btn8.Text = board[21].ToString();
		btn9.Text = board[22].ToString();
        Debug.WriteLine("Updated the board");
    }

	private async void gridBtnPressed(object sender, EventArgs e) {
		
		Button clickedButton = (Button)sender;
		MainPageViewModel vm = ((MainPageViewModel)BindingContext);

		if (vm.TurnOfX && vm.BoardSymbol == 'X') {
			await ((MainPageViewModel)BindingContext).hub.InvokeAsync("PlacePiece", "X", int.Parse(clickedButton.AutomationId));
		} 
		else if (!vm.TurnOfX && vm.BoardSymbol == 'O') {
			await ((MainPageViewModel)BindingContext).hub.InvokeAsync("PlacePiece", "O", int.Parse(clickedButton.AutomationId));
		}

		vm.DidTurn = true;


		// Clear
		/*
		if (buttons.Count >= 9) {
			foreach (Button b in buttons) {
				b.Text = "";
			}
			buttons.Clear();
			count = 0;
			MessagingCenter.Instance.Send<MainPageViewModel>(((MainPageViewModel)BindingContext), MessengerKeys.UpdateHighscore);
			return;
		}
		*/

		// Already placed 
		//if (clickedButton.Text == "X" || clickedButton.Text == "O") { return; }

		// Place
		/*
		if (placeX) {
			clickedButton.Text = "X";
			placeX = false;
		} else {
			clickedButton.Text = "O";
			placeX = true;
		}

		// Keep track
		buttons.Add(clickedButton);
		count++;
		*/
	}

	
}

