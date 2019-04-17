using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VelovApi.Models;
using VelovApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace VelovApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourismeController : ControllerBase
    {
        private readonly TourismeService _tourismeService;

        public TourismeController(TourismeService tourismeService)
        {
            _tourismeService = tourismeService;
        }

        [HttpGet]
        public ActionResult<List<Tourisme>> Get()
        {
            return _tourismeService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetTourisme")]
        public ActionResult<Tourisme> Get(string id)
        {
            var tourisme = _tourismeService.Get(id);

            if (tourisme == null)
            {
                return NotFound();
            }

            return tourisme;
        }

        [HttpPost]
        public ActionResult<Tourisme> Create(Tourisme tourisme)
        {
            _tourismeService.Create(tourisme);

            return CreatedAtRoute("GetTourisme", new { id = tourisme.Id.ToString() }, tourisme);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Tourisme tourismeIn)
        {
            var tourisme = _tourismeService.Get(id);

            if (tourisme == null)
            {
                return NotFound();
            }

            _tourismeService.Update(id, tourismeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var tourisme = _tourismeService.Get(id);

            if (tourisme == null)
            {
                return NotFound();
            }

            _tourismeService.Remove(tourisme.Id);

            return NoContent();
        }
    }
}
