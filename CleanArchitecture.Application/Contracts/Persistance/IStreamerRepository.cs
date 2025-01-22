using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistance
{
    public interface IStreamerRepository : IAsyncRepository<Streamer>
    {
        Task DeleteAsync(Streamer streamerToDelete);
    }
}
