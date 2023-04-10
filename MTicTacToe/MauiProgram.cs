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
		builder.Services.AddSingleton<HighscoreViewModel>();
		
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<HighscoreView>();
        builder.Services.AddSingleton<NamePage>();

        return builder.Build();
	}
}
