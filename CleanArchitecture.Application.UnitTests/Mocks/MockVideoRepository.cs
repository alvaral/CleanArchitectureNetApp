using AutoFixture;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Application.UnitTests.Mock
{
    public static class MockVideoRepository
    {
        public static void AddDataVideoRepository(StreamerDbContext streamerDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var videos = fixture.CreateMany<Video>().ToList();

            videos.Add(fixture.Build<Video>()
                .With(tr => tr.CreatedBy, "alvaral")
                .Create()
            );

            var options = new DbContextOptionsBuilder<StreamerDbContext>()
                .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{Guid.NewGuid()}")
                .Options;

            streamerDbContextFake.Videos!.AddRange(videos);
            streamerDbContextFake.SaveChanges();
        }

        //public static Mock<VideoRepository> GetVideoRepository()
        //{
        //    var fixture = new Fixture();



        //    fixture.Behaviors.Remove(fixture.Behaviors.OfType<ThrowingRecursionBehavior>().FirstOrDefault());
        //    fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        //    // Crear lista de videos simulados
        //    var videos = fixture.Build<Video>()
        //        .Without(v => v.Streamer) // Ignora la referencia circular
        //        .CreateMany(5)
        //        .ToList();

        //    // Agregar un video específico con propiedades personalizadas
        //    videos.Add(fixture.Build<Video>()
        //        .With(v => v.CreatedBy, "alvaral")
        //        .Without(v => v.Streamer) // Ignora la referencia circular
        //        .Create()
        //    );

        //    var options = new DbContextOptionsBuilder<StreamerDbContext>()
        //        .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{Guid.NewGuid()}")
        //        .Options;

        //    var streamerDbContextFake = new StreamerDbContext(options);
        //    streamerDbContextFake.Videos!.AddRange(videos);

        //    streamerDbContextFake.Videos!.AddRange(videos);
        //    streamerDbContextFake.SaveChanges();

        //    var mockRepository = new Mock<VideoRepository>(streamerDbContextFake);

        //    return mockRepository;
        //}
    }
}
