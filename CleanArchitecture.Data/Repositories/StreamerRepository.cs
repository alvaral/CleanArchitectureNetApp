using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contracts.Persistance;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class StreamerRepository : RepositoryBase<StreamerRepository>,IStreamerRepository
    {
        public StreamerRepository(StreamerDbContext context) : base(context) 
        {

        }
    }
}
