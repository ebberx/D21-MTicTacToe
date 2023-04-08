using Microsoft.AspNetCore.Hosting;
using System.Reflection.PortableExecutable;

namespace MultiplayerServer {
	class Program {

		public static void Main(String[] args) {

			// Server
			Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults((app) => {
				app.UseUrls("http://*:5000");
				app.UseContentRoot(Directory.GetCurrentDirectory());
				app.UseStartup<Startup>();
			}).Build().Run();
		}
	}
}

