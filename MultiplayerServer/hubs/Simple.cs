using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace MultiplayerServer.hubs {

	public static class DataStore {
		public static bool PlaceX = true;
		public static char[] Board = new char[23];
	}

	public class Simple : Hub {

		public async Task RestartGame() {

			//Context.Items["placeX"] = true;
			//Context.Items["board"] = new char[9];

			DataStore.PlaceX = true;
			DataStore.Board = new char[23];

			await Clients.Caller.SendAsync("AssignPlayerSymbol", "X");
			await Clients.Others.SendAsync("AssignPlayerSymbol", "O");

			await Clients.All.SendAsync("ResetFromServer");
			await Clients.All.SendAsync("UpdateGameBoard", DataStore.Board, DataStore.PlaceX);
		}

		public async Task PlacePiece(char piece, int location) {

			if (DataStore.Board[location] == 'X' || DataStore.Board[location] == 'O')
				return;
			
			Console.WriteLine(location + "-" + piece);

			if (DataStore.PlaceX && piece == 'X' || piece == 'x') {
				DataStore.Board[location] = piece;
			} 
			else if(!DataStore.PlaceX && piece == 'O' || piece == 'o') {
				DataStore.Board[location] = piece;
			}

			// Next players turn
			DataStore.PlaceX = !DataStore.PlaceX;

			Console.WriteLine(DataStore.Board[0]);

			await Clients.All.SendAsync("UpdateGameBoard", DataStore.Board, DataStore.PlaceX);
		}
	}
}
