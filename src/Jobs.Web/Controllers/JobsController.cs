using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Jobs.Web.ViewModels;
using Jobs.Core.Abstractions.Services;

namespace Jobs.Web.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var jobs = (await _jobService.GetAllAsync())
                .Select(j => new JobViewModel(j))
                .ToList();

            return View(jobs);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(Guid id)
        {
            var statusUpdateResult = await _jobService.UpdateStatusAsync(id);

            if (!statusUpdateResult.Success)
            {
                return BadRequest(statusUpdateResult.Message);
            }

            return Ok();
        }
    }
}