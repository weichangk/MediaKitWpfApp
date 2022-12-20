using MediaKitWpfApp.Models;
using Serilog;
using System;
using Weick.Orm.Core;

namespace MediaKitWpfApp.Repositores
{
    public class SysParmBaseRepository : BaseRepository<SysParm, int>, ISysParmBaseRepository, IDependency
    {
        public SysParmBaseRepository(IUnitOfWork unitOfWork, ILogger logger, Lazy<IRepository<SysParm>> repository) : base(unitOfWork, logger, repository)
        {
        }
    }
}
