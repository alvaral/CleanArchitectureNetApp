using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistance;
using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetsVideosListQueryHandler : IRequestHandler<GetsVideosListQuery, List<VideosVm>>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public GetsVideosListQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<List<VideosVm>> Handle(GetsVideosListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _videoRepository.GetVideoByUsername(request._Username);


            return _mapper.Map<List< VideosVm >>(videoList);
        }
    }
}
