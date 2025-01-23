﻿using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Contracts.Persistance
{
    public interface IUnitOfWork : IDisposable
    {

        IStreamerRepository StreamerRepository { get; }

        IVideoRepository VideoRepository { get; }

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
