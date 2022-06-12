namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            var result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();


            var albums = context.Albums
                .Where(x => x.ProducerId == producerId)
                .Select(x=> new
                {
                    AlbumName = x.Name,
                    RelDate = x.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProdName = x.Producer.Name,
                    AlbumSongs = x.Songs,
                    AlbumPrice = x.Price
                })
                .ToList();

            foreach (var album in albums.OrderByDescending(x=> x.AlbumPrice))
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.RelDate}");
                sb.AppendLine($"-ProducerName: {album.ProdName}");
                sb.AppendLine($"-Songs:");

                int counter = 1;
                foreach (var item in album.AlbumSongs.OrderByDescending(x=> x.Name).ThenBy(x=> x.Writer.Name))
                {
                    sb.AppendLine($"---#{counter}");
                    counter++;
                    sb.AppendLine($"---SongName: {item.Name}");
                    sb.AppendLine($"---Price: {item.Price:f2}");
                    sb.AppendLine($"---Writer: {item.Writer.Name}");
                }
                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }



            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();

            var songs = context.Songs
                .ToList()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x=> new 
                {
                    SongName = x.Name,
                    WriterName = x.Writer.Name,
                    Performer = x.SongPerformers
                    .Select(x => x.Performer.FirstName + " " + x.Performer.LastName)
                    .FirstOrDefault(),
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration
                })
                .OrderBy(x=> x.SongName)
                .ThenBy(x=> x.WriterName)
                .ThenBy(x=> x.Performer)
                .ToList();
            int counter = 1;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter++}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.Performer}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration:c}");
            }
            return sb.ToString().Trim();
        }
    }
}
