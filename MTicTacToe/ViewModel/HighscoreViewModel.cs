
namespace MTicTacToe.ViewModel {
	public class HighscoreViewModel : BindableObject {

		private int _highscore = 0;
		public int Highscore { 
			get { return _highscore; }
			set { _highscore = value; OnPropertyChanged(); } 
		}

		public HighscoreViewModel() {
			MessagingCenter.Subscribe<MainPageViewModel>(this, MessengerKeys.UpdateHighscore, (sender) => {
				System.Diagnostics.Debug.WriteLine("MessagingCenter subscribe message: ");
				Highscore++;
			});
		}
	}
}
