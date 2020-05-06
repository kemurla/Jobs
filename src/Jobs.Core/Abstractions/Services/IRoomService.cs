using System.Threading.Tasks;
using System.Collections.Generic;

using Jobs.Core.ApiModels;

namespace Jobs.Core.Abstractions.Services
{
    public interface IRoomService
    {
        /// <summary>
        /// Returns the overview of the progress for each room.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RoomProgressOverviewModel>> GetRoomsProgressOverviewAsync();
    }
}
