using System.Security.Cryptography.X509Certificates;
using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();

await MultipleEntitiesQuery();
//await AddNewDirectorWithVideo();
//await AddNewActorWithVideo();
//await AddNewStreamerWithVideoId();
// await TrackingNoTracking();
//await QueryLinq();
//await QueryMethods();
//await QueryFilter();
// QueryStreaming();
//await AddNewRecords();

Console.WriteLine("Presiona cualquier tecla para terminar el programa");
Console.ReadKey();

async Task MultipleEntitiesQuery()
{
    //var videoWithActores = await dbContext!.Videos!.Include(q => q.Actores).FirstOrDefaultAsync(q => q.Id == 1);


    var actor = await dbContext!.Actores!.Select(q => q.Nombre)
        .ToListAsync();
}

async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Nombre = "Lorenzo",
        Apellido = "Basteri",
        VideoId = 1,
    };

    await dbContext.AddAsync(director); // para que se genere actor.Id
    await dbContext.SaveChangesAsync();
}
async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Nombre = "Brad",
        Apellido = "Pitt"
    };

    await dbContext.AddAsync(actor); // para que se genere actor.Id
    await dbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1,
    };

    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}
async Task AddNewStreamerWithVideoId()
{


    var batmanForever = new Video
    {
        Nombre = "Batman Forever",
        StreamerId = 6,
    };

    await dbContext.AddAsync(batmanForever);
    await dbContext.SaveChangesAsync();
}
async Task AddNewStreamerWithVideo()
{
    var pantalla = new Streamer
    {
        Nombre = "Pantalla"
    };

    var hungerGames = new Video
    {
        Nombre = "Hunger Games",
        Streamer = pantalla,
    };

    await dbContext.AddAsync(hungerGames);
    await dbContext.SaveChangesAsync();
}
async Task TrackingAndNotTracking()
{
    var streamerWithTracking = await dbContext!.Streamers!.FirstOrDefaultAsync( x => x.Id == 1);
    var streamerWithNoTracking = await dbContext!.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);

    streamerWithTracking.Nombre = "Netflix Super";
    streamerWithNoTracking.Nombre = "Amazon Plus";

    await dbContext!.SaveChangesAsync();
}

async Task QueryLinq()
{
    Console.WriteLine($"Ingrese el servicio de streaming");
    var streamerNombre = Console.ReadLine();
    var streamers = await (from i in dbContext.Streamers
                           where EF.Functions.Like(i.Nombre, $"%{streamerNombre}%")
                           select i).ToListAsync();

    foreach(var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}
async Task QueryMethods()
{
    var streamers = dbContext!.Streamers!;

    var firstAsync = await streamers.Where(y => y!.Nombre!.Contains("a")).FirstAsync();

    var firstOrDefaultAsync = await streamers.Where(y => y!.Nombre!.Contains("a")).FirstOrDefaultAsync();

    var firstOrDefault_v2 = await streamers.FirstOrDefaultAsync(y => y!.Nombre!.Contains("a"));

    var singleAsync = await streamers.Where(y => y!.Nombre!.Contains("a")).SingleAsync();

    var singleOrDefaultAsync = await streamers.Where(y => y.Id == 1).SingleOrDefaultAsync();

    var resultado = await streamers.FindAsync(1);

}
async Task QueryFilter()
{
    Console.WriteLine($"Ingresa una compañia de streaming: ");
    var streamingNombre = Console.ReadLine();
    var streamers = await dbContext!.Streamers!.Where(x => x.Nombre.Equals(streamingNombre)).ToListAsync();

    foreach(var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }

    //var streamerPartialResults = await dbContext.Streamers.Where(x=> x.Nombre.Contains(streamingNombre)).ToListAsync();

    var streamerPartialResults = await dbContext.Streamers.Where(x =>EF.Functions.Like(x.Nombre, $"%{streamingNombre}%")).ToListAsync();


    foreach (var streamer in streamerPartialResults)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}
void QueryStreaming()
{
    var streamers = dbContext!.Streamers!.ToList();

    foreach(var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }

}
async Task AddNewRecords()
{

    Streamer streamer = new()
    {
        Nombre = "Disney Plus",
        Url = "https://www.disneyplus.com"
    };

    dbContext!.Streamers!.Add(streamer);

    await dbContext.SaveChangesAsync();

    var movies = new List<Video>
    {
        new Video
        {
            Nombre = "La Cenicienta",
            StreamerId = streamer.Id,

        },
        new Video
        {
            Nombre = "1001 dálmatas",
            StreamerId = streamer.Id,
        },
        new Video
        {
            Nombre = "El Jorobado de Notredame",
            StreamerId = streamer.Id,
        },
        new Video
        {
            Nombre = "Starwars",
            StreamerId = streamer.Id,
        }
    };

    await dbContext.AddRangeAsync(entities: movies);
    await dbContext.SaveChangesAsync();

}

