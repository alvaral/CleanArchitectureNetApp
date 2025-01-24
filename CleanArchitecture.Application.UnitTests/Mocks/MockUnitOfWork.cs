using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Application.UnitTests.Mock
{
    public static class MockUnitOfWork
    {

        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<StreamerDbContext>()
                .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{dbContextId}")
                .Options;

            var streamerDbContextFake = new StreamerDbContext(options);
            streamerDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(streamerDbContextFake);


            return mockUnitOfWork;
        }

        //public static Mock<IUnitOfWork> GetUnitOfWork()
        //{
        //    var mockUnitOfWork = new Mock<IUnitOfWork>();
        //    var mockVideoRepository = MockVideoRepository.GetVideoRepository();

        //    mockUnitOfWork.Setup(r => r.VideoRepository).Returns(mockVideoRepository.Object);

        //    return mockUnitOfWork;
        //}
    }
}
