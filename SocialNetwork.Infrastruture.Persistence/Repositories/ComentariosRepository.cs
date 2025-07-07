using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Infrastruture.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastruture.Persistence.Repositories
{
    public class ComentariosRepository : GenericRepository<Comentarios>, IComentariosRepository
    {
        private readonly ApplicationContext _dbContext;

        public ComentariosRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}