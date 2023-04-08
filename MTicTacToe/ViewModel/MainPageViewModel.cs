using Microsoft.AspNetCore.SignalR.Client;
using MTicTacToe.Views;
using System.Windows.Input;
using System.Diagnostics;
using Microsoft.Maui.Layouts;

namespace MTicTacToe.ViewModel {
	public class MainPageViewModel {

		public HubConnection hub;

		public delegate void ResetDelegate();
		public ResetDelegate Reset;

		public delegate void UpdateBoardDelegate(char[] board);
		public UpdateBoardDelegate UpdateBoard;

		public char BoardSymbol = 'H';
		public bool TurnOfX = true;
		public bool DidTurn = true;

		public MainPageViewModel() {
			try {
				hub = new HubConnectionBuilder().WithUrl("http://192.168.1.127:5000/hubs/test").Build();
				hub.StartAsync();
				hub.On<char[], bool>("UpdateGameBoard", (board, turnOfX) => { 
					// Tell the client which turn it is
					TurnOfX = turnOfX;
					DidTurn = false;
					UpdateBoard(board);
				});
				hub.On("ResetFromServer", () => { 
					Reset(); 
				});
				hub.On<char>("AssignPlayerSymbol", (symbol) => { 
					Debug.WriteLine("Got symbol:" + symbol); 
					BoardSymbol = symbol; 
					TurnOfX = true; 
				});

			} catch (Exception e) {
				Debug.WriteLine("########################################");
				Debug.WriteLine("########################################");
				Debug.WriteLine(e.StackTrace);
			}
		}

		public ICommand HighscoreBtn => new Command(async () => { 
			await Shell.Current.GoToAsync(nameof(HighscoreView), true);			
		});

		public ICommand ResetBtn => new Command(async () => {
			try {
				await hub.InvokeAsync("RestartGame");
			} 
			catch (Exception e) {
				
			}
		});
	}

	
}
