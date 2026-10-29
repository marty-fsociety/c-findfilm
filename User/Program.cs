using System;
using System.IO;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace User {
	class indexVideoContent {
		public Dictionary<int, settingsVideoContent> VideoContent { get; set; } 
	}

	class settingsVideoContent {
		public string Name { get; set; }
		public string Type { get; set; }
		public int Year { get; set; }
	}

	

	class metodsVideoContent {
		public void addFilmOrSeries(indexVideoContent video, int i) {
			var newVideo = new settingsVideoContent();
			Console.Write("Что хочешь добавить? Фильм или сериал?(f/s) ");
			string userVideoContent = Console.ReadLine();
			string type = "initial value";
			if (userVideoContent == "s") {
				newVideo.Type = "Сериал";
			}
			else if(userVideoContent == "f") {
				newVideo.Type = "Фильм";
			}

			Console.Write("Какое у него название? ");
			newVideo.Name = Console.ReadLine();

			Console.Write("Какого он года? ");
			newVideo.Year = Convert.ToInt32(Console.ReadLine());

			video.VideoContent.Add(i, newVideo);

			var options = new JsonSerializerOptions {
				Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
				WriteIndented = true
			};

			using(var stream = new FileStream("vc.json", FileMode.OpenOrCreate)) {
				JsonSerializer.Serialize(stream, video, options);
			}
		}
	}


	class Program {
		public static indexVideoContent video = new indexVideoContent {
			VideoContent = new Dictionary<int, settingsVideoContent>()
		};
		static void Main() {
			int i = 0;
			Console.WriteLine("----------ПОИСК-ФИЛЬМОВ-ИЛИ-СЕРИАЛОВ---------------");
			while (true) {
				metodsVideoContent newvideo = new metodsVideoContent(); {
					newvideo.addFilmOrSeries(Program.video, i);	
				}						
				i += 1;
			}
		}
				
	}
			
}
	
