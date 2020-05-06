using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using Jobs.Core;
using Jobs.Data;
using Jobs.Core.Entities;
using Jobs.Business.Constants;
using Jobs.Business.Validators;
using Jobs.Core.Abstractions.Services;

namespace Jobs.Business.Services
{
    public class JobService : IJobService
    {
        private readonly DemoDbContext _dbContext;
        private readonly ILogger<JobService> _logger;

        public JobService(
            DemoDbContext dbContext,
            ILogger<JobService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        // Was not sure if pagination is needed?
        public Task<List<RxJob>> GetAllAsync()
            => _dbContext.RxJob
                .Include(j => j.RoomType)
                .Take(12)
                .AsNoTracking()
                .ToListAsync();

        public async Task<Result> UpdateStatusAsync(Guid id)
        {
            var job = await _dbContext.RxJob.FindAsync(id);

            CommonValidator.ThrowIfNull(job);

            if(job.Status == Statuses.Complete)
            {
                return new Result(ErrorMessages.AlreadyComplete);
            }

            job.Status = Statuses.Complete;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, string.Empty);
                return new Result(ErrorMessages.DatabaseIsOffline);

            }

            return new Result();
        }
    }
}
