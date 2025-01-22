using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetsVideosListQuery : IRequest<List<VideosVm>>
    {
        public string _Username { get; set; } = String.Empty;

        public GetVieosListQuery(string username)
        {
            _Username = username ?? throw new ArgumentNullException(nameof(username));

        }
    }
}
