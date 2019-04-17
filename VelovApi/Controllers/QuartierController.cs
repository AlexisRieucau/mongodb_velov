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
    public class QuartierController : ControllerBase
    {
        private readonly QuartierService _quartierService;

        public QuartierController(QuartierService quartierService)
        {
            _quartierService = quartierService;
        }

        [HttpGet]
        public ActionResult<List<Quartier>> Get()
        {
            return _quartierService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetQuartier")]
        public ActionResult<Quartier> Get(string id)
        {
            var quartier = _quartierService.Get(id);

            if (quartier == null)
            {
                return NotFound();
            }

            return quartier;
        }

        [HttpPost]
        public ActionResult<Quartier> Create(Quartier quartier)
        {
            _quartierService.Create(quartier);

            return CreatedAtRoute("GetQuartier", new { id = quartier.Id.ToString() }, quartier);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Quartier quartierIn)
        {
            var quartier = _quartierService.Get(id);

            if (quartier == null)
            {
                return NotFound();
            }

            _quartierService.Update(id, quartierIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var quartier = _quartierService.Get(id);

            if (quartier == null)
            {
                return NotFound();
            }

            _quartierService.Remove(quartier.Id);

            return NoContent();
        }
    }
}
