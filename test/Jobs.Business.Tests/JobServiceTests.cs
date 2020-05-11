using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using Shouldly;

using Xunit;

using Jobs.Data;
using Jobs.Core.Entities;
using Jobs.Business.Services;
using Jobs.Business.Constants;
using Jobs.Business.Tests.Helpers;

namespace Jobs.Business.Tests
{
    public class JobServiceTests
    {
        private readonly JobService _jobService;
        private readonly DemoDbContext _dbContext;

        public JobServiceTests()
        {
            _dbContext = new DemoDbContext(GetInMemoryDatabaseOptions());
            _jobService = new JobService(_dbContext, null);

            Initializer.Seed(_dbContext);
        }

        [Fact]
        public async Task GetAll_Should_Return_All_Jobs()
        {
            var result = await _jobService.GetAllAsync();

            result.Count.ShouldBe(5);
            result.ShouldBeOfType<List<RxJob>>();
        }

        [Fact]
        public async Task UpdateStatus_Should_Update_Status_To_Complete()
        {
            var jobIdForUpate = new Guid("6A39DBDA-F71A-4659-BA5F-03844E36229A");

            var updateStatusResult = await _jobService.UpdateStatusAsync(jobIdForUpate);

            var job = await _dbContext.RxJob.FindAsync(jobIdForUpate);

            updateStatusResult.Success.ShouldBeTrue();
            job.Status.ShouldBe(Statuses.Complete);
        }

        [Fact]
        public async Task UpdateStatus_Should_Throw_Exception_With_Invalid_Id()
            => await Should.ThrowAsync<ArgumentNullException>(
                    async () => await _jobService.UpdateStatusAsync(Guid.NewGuid()));

        [Fact]
        public async Task UpdateStatus_Should_Not_Update_Already_Complete_Job()
        {
            var jobIdForUpate = new Guid("82A62787-036E-4EF8-8A6D-03372E159B9C");

            var updateStatusResult = await _jobService.UpdateStatusAsync(jobIdForUpate);

            updateStatusResult.Success.ShouldBeFalse();
            updateStatusResult.Message.ShouldBe(ErrorMessages.AlreadyComplete);
        }

        private DbContextOptions<DemoDbContext> GetInMemoryDatabaseOptions()
            => new DbContextOptionsBuilder<DemoDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
    }
}
