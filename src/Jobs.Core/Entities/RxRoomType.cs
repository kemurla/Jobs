using System;
using System.Collections.Generic;

namespace Jobs.Core.Entities
{
    public class RxRoomType
    {
        public RxRoomType()
        {
            RxJob = new HashSet<RxJob>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<RxJob> RxJob { get; set; }
    }
}
