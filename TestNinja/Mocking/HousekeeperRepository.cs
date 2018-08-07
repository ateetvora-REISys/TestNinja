using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IHousekeeperRepository
    {
        IQueryable<Housekeeper> Get();
    }

    public class HousekeeperRepository : IHousekeeperRepository
    {
        private static readonly UnitOfWork UnitOfWork = new UnitOfWork();

        public IQueryable<Housekeeper> Get()
        {
            var housekeepers = UnitOfWork.Query<Housekeeper>();
            return housekeepers;
        }
    }
}
