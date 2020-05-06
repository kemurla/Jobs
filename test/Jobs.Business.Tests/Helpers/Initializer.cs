using System;
using System.Collections.Generic;

using Jobs.Data;
using Jobs.Core.Entities;

namespace Jobs.Business.Tests.Helpers
{
    public static class Initializer
    {
        /// <summary>
        /// Seeds dummy data into the InMemory database.
        /// </summary>
        /// <param name="context"></param>
        public static void Seed(DemoDbContext context)
        {
            var jobs = new List<RxJob>(5)
            {
                new RxJob
                {
                    Id = new Guid("82A62787-036E-4EF8-8A6D-03372E159B9C"),
                    Name = "Job15_9_1",
                    Status = "Complete",
                    Floor = 17,
                    Room = 9,
                    DateCreated = DateTime.UtcNow,
                    StatusNum = 2
                },
                new RxJob
                {
                    Id = Guid.NewGuid(),
                    Name = "Job1_17_0",
                    Status = "Complete",
                    Floor = 20,
                    Room = 1,
                    DateCreated = DateTime.UtcNow,
                    StatusNum = 2
                },
                new RxJob
                {
                    Id = new Guid("6A39DBDA-F71A-4659-BA5F-03844E36229A"),
                    Name = "Job20_23_1",
                    Status = "Not Started",
                    Floor = 11,
                    Room = 2,
                    DateCreated = DateTime.UtcNow,
                    StatusNum = 1
                },
                new RxJob
                {
                    Id = Guid.NewGuid(),
                    Name = "Job20_13_0",
                    Status = "In Progress",
                    Floor = 22,
                    Room = 5,
                    DateCreated = DateTime.UtcNow,
                    StatusNum = 2
                },
                new RxJob
                {
                    Id = Guid.NewGuid(),
                    Name = "Job3_26_0",
                    Status = "Delayed",
                    Floor = 15,
                    Room = 5,
                    DateCreated = DateTime.UtcNow,
                    StatusNum = 1
                }
            };

            context.RxJob.AddRange(jobs);
            context.SaveChanges();
        }
    }
}
