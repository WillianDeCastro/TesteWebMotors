using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiDesafioWebMotors.Infra.Data.Context;
using ApiDesafioWebMotors.Infra.Data.Entities;
using ApiDesafioWebMotors.Domain.Interfaces.Services;
using ApiDesafioWebMotors.Domain.Models;

namespace ApiDesafioWebMotors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly WebMotorsContext _context;
        private readonly IExternalWebMotorsService _extWebMotorsService;

        public AdvertisementController(WebMotorsContext context, IExternalWebMotorsService extWebMotorsService)
        {
            _context = context;
            _extWebMotorsService = extWebMotorsService;
        }

        #region Local
        [HttpGet]
        public IEnumerable<AnuncioWebmotors> GetAnuncios()
        {
            return _context.Anuncios;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnuncioWebmotors([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var anuncioWebmotors = await _context.Anuncios.FindAsync(id);

            if (anuncioWebmotors == null)
            {
                return NotFound();
            }

            return Ok(anuncioWebmotors);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnuncioWebmotors([FromRoute] int id, [FromBody] AnuncioWebmotors anuncioWebmotors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anuncioWebmotors.Id)
            {
                return BadRequest();
            }

            _context.Entry(anuncioWebmotors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnuncioWebmotorsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> PostAnuncioWebmotors([FromBody] AnuncioWebmotors anuncioWebmotors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Anuncios.Add(anuncioWebmotors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnuncioWebmotors", new { id = anuncioWebmotors.Id }, anuncioWebmotors);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnuncioWebmotors([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var anuncioWebmotors = await _context.Anuncios.FindAsync(id);
            if (anuncioWebmotors == null)
            {
                return NotFound();
            }

            _context.Anuncios.Remove(anuncioWebmotors);
            await _context.SaveChangesAsync();

            return Ok(anuncioWebmotors);
        }

        private bool AnuncioWebmotorsExists(int id)
        {
            return _context.Anuncios.Any(e => e.Id == id);
        }
        #endregion


        #region External
        [HttpGet("GetVehicleModels/{markerId}")]
        public async Task<IEnumerable<ModelVehicle>> GetVehicleModels(int markerId)
        {
            return await _extWebMotorsService.GetVehicleModels(markerId);
        }

        [HttpGet("GetVehicleMakers")]
        public async Task<IEnumerable<Maker>> GetVehicleMakers()
        {
            return await _extWebMotorsService.GetVehicleMakers();
        }

        [HttpGet("GetVehicleVersions/{modelId}")]
        public async Task<IEnumerable<VersionVehicle>> GetVehicleVersions(int modelId)
        {
            return await _extWebMotorsService.GetVehicleVersions(modelId);
        }

        [HttpGet("GetVehicles/{pageId}")]
        public async Task<IEnumerable<Vehicles>> GetVehicles(int pageId)
        {
            return await _extWebMotorsService.GetVehicles(pageId);
        }
        #endregion

    }
}