namespace MTicTacToe;
using MTicTacToe.ViewModel;
using MTicTacToe.Views;
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddScoped<HighscoreViewModel>();
		
		builder.Services.AddScoped<MainPage>();
		builder.Services.AddScoped<HighscoreView>();

		return builder.Build();
	}
}
