using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Shouldly;

using Xunit;

using Jobs.Data;
using Jobs.Business.Services;
using Jobs.Business.Constants;
using Jobs.Business.Tests.Helpers;

namespace Jobs.Business.Tests
{
    public class JobServiceTests
    {
        [Fact]
        public async Task GetAll_Should_Return_All_Jobs()
        {
            var options = GetInMemoryDatabaseOptions();

            var context = new DemoDbContext(options);

            Initializer.Seed(context);

            var jobService = new JobService(context, null);
            var result = await jobService.GetAllAsync();

            result.Count.ShouldBe(5);
        }

        [Fact]
        public async Task UpdateStatus_Should_Update_Status_To_Complete()
        {
            var options = GetInMemoryDatabaseOptions();

            var context = new DemoDbContext(options);

            Initializer.Seed(context);

            var jobService = new JobService(context, null);

            var jobIdForUpate = new Guid("6A39DBDA-F71A-4659-BA5F-03844E36229A");

            var updateStatusResult = await jobService.UpdateStatusAsync(jobIdForUpate);

            var job = await context.RxJob.FindAsync(jobIdForUpate);

            updateStatusResult.Success.ShouldBeTrue();
            job.Status.ShouldBe(Statuses.Complete);
        }

        [Fact]
        public async Task UpdateStatus_Should_Throw_Exception_With_Invalid_Id()
        {
            var options = GetInMemoryDatabaseOptions();

            var context = new DemoDbContext(options);

            Initializer.Seed(context);

            var jobService = new JobService(context, null);

            await Should.ThrowAsync<ArgumentNullException>(
                async () => await jobService.UpdateStatusAsync(Guid.NewGuid()));
        }

        [Fact]
        public async Task UpdateStatus_Should_Not_Update_Already_Complete_Job()
        {
            var options = GetInMemoryDatabaseOptions();

            var context = new DemoDbContext(options);

            Initializer.Seed(context);

            var jobService = new JobService(context, null);

            var jobIdForUpate = new Guid("82A62787-036E-4EF8-8A6D-03372E159B9C");

            var updateStatusResult = await jobService.UpdateStatusAsync(jobIdForUpate);

            updateStatusResult.Success.ShouldBeFalse();
            updateStatusResult.Message.ShouldBe(ErrorMessages.AlreadyComplete);
        }

        private DbContextOptions<DemoDbContext> GetInMemoryDatabaseOptions()
        {
            return new DbContextOptionsBuilder<DemoDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }
    }
}
