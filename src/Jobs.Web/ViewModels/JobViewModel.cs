using System;
using System.ComponentModel.DataAnnotations;

using Jobs.Core.Entities;

namespace Jobs.Web.ViewModels
{
    public class JobViewModel
    {
        public JobViewModel(RxJob entity)
        {
            MapFromEntity(entity);
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int? Floor { get; set; }

        public string Status { get; set; }

        [Display(Name = "Room Name")]
        public string RoomName { get; set; }

        private void MapFromEntity(RxJob entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Floor = entity.Floor;
            Status = entity.Status;
            RoomName = entity.RoomType.Name;
        }
    }
}
