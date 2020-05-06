using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using Jobs.Data;
using Jobs.Core.ApiModels;
using Jobs.Core.Abstractions.Services;

namespace Jobs.Business.Services
{
    public class RoomService : IRoomService
    {
        private readonly DemoDbContext _dbContext;

        public RoomService(DemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RoomProgressOverviewModel>> GetRoomsProgressOverviewAsync()
        {
            var roomOverview = await _dbContext.RxJob
                .Include(x => x.RoomType)
                .GroupBy(x => new
                {
                    x.Status,
                    x.RoomType.Name
                })
                .Select(x => new RoomProgressOverviewModel
                {
                    Status = x.Key.Status,
                    RoomName = x.Key.Name,
                    Count = x.Count()
                })
                .OrderBy(x => x.RoomName)
                .ToListAsync();

            return roomOverview;
        }
    }
}
