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
    public class VelovController : Controller
    {
        private readonly VelovService _velovService;

        public VelovController(VelovService velovService)
        {
            _velovService = velovService;
        }

        [HttpGet]
        public ActionResult<List<Velov>> Get()
        {
            return _velovService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetVelov")]
        public ActionResult<Velov> Get(string id)
        {
            var velov = _velovService.Get(id);

            if(velov == null)
            {
                return NotFound();
            }

            return velov;
        }

        [HttpPost]
        public ActionResult<Velov> Create(Velov velov)
        {
            _velovService.Create(velov);

            return CreatedAtRoute("GetVelov", new { id = velov.Id.ToString() }, velov);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Velov velovIn)
        {
            var velov = _velovService.Get(id);

            if (velov == null)
            {
                return NotFound();
            }

            _velovService.Update(id, velovIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var velov = _velovService.Get(id);

            if (velov == null)
            {
                return NotFound();
            }

            _velovService.Remove(velov.Id);

            return NoContent();
        }
    }
}
