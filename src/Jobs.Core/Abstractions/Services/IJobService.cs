using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Jobs.Core.Entities;

namespace Jobs.Core.Abstractions.Services
{
    public interface IJobService
    {
        /// <summary>
        /// Returns all jobs.
        /// </summary>
        Task<List<RxJob>> GetAllAsync();

        /// <summary>
        /// Updates the status of a given job to complete.
        /// </summary>
        Task<Result> UpdateStatusAsync(Guid id);
    }
}
