using MagicCottage_CottageAPI.Data;
using MagicCottage_CottageAPI.Logging;
using MagicCottage_CottageAPI.Models;
using MagicCottage_CottageAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicCottage_CottageAPI.Controllers
{
    [Route("api/CottageAPI")]
    [ApiController]
    public class CottageAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogging _logger;
        public CottageAPIController(ILogging logger,ApplicationDbContext db) 
        {
            _logger= logger;
            _db= db;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CottageDTO>> GetCottages()
        {
            _logger.Log("Getting all cottages","");
            return Ok(_db.Cottages.ToList());
        }
        [HttpGet("{id:int}", Name ="GetCottage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CottageDTO> GetCottage(int id)
        {
            if (id == 0)
            {
                _logger.Log("Get Cottage Error with Id " + id,"error");
                return BadRequest();
            }
            var cottage =_db.Cottages.FirstOrDefault(u => u.Id == id);
            if (cottage == null)
            {
                return NotFound();
            }
            return Ok(cottage);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CottageDTO> CreateCottage([FromBody] CottageDTO cottageDTO)
        {
            if (_db.Cottages.FirstOrDefault(u => u.Name.ToLower() == cottageDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Cottage already exists");
                return BadRequest(ModelState);
            }
            if (cottageDTO == null)
            {
                return BadRequest(cottageDTO);
            }
            if (cottageDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Cottage model = new()
            {
                Amenity = cottageDTO.Amenity,
                Details = cottageDTO.Details,
                Id = cottageDTO.Id,
                ImageUrl = cottageDTO.ImageUrl,
                Name = cottageDTO.Name,
                Occupancy = cottageDTO.Occupancy,
                Rate = cottageDTO.Rate,
                Sqft = cottageDTO.Sqft
            };
            _db.Cottages.Add(model);
            _db.SaveChanges();
            return CreatedAtRoute("GetCottage", new { id = cottageDTO.Id }, cottageDTO);
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteCottage")]
        public IActionResult DeleteCottage(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var cottage = _db.Cottages.FirstOrDefault(u => u.Id == id);
            if (cottage == null)
            {
                return BadRequest();
            }
            _db.Cottages.Remove(cottage);
            _db.SaveChanges();
            return NoContent();
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateCottage")]
        public IActionResult UpdateCottage(int id, [FromBody]CottageDTO cottageDTO)
        {
            if(cottageDTO==null || id != cottageDTO.Id)
            {
                return BadRequest();
            }
            Cottage model = new()
            {
                Amenity = cottageDTO.Amenity,
                Details = cottageDTO.Details,
                Id = cottageDTO.Id,
                ImageUrl = cottageDTO.ImageUrl,
                Name = cottageDTO.Name,
                Occupancy = cottageDTO.Occupancy,
                Rate = cottageDTO.Rate,
                Sqft = cottageDTO.Sqft
            };
            _db.Cottages.Update(model);
            _db.SaveChanges();
            return NoContent();
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("{id:int}", Name = "UpdatePartialCottage")]
        public IActionResult UpdatePartialCottage(int id, JsonPatchDocument<CottageDTO> patchDTO)
        {
            if(patchDTO==null || id==0)
            {
                return BadRequest();
            }
            var cottage = _db.Cottages.AsNoTracking().FirstOrDefault(u => u.Id == id);
            CottageDTO cottageDTO = new()
            {
                Amenity = cottage.Amenity,
                Details = cottage.Details,
                Id = cottage.Id,
                ImageUrl = cottage.ImageUrl,
                Name = cottage.Name,
                Occupancy = cottage.Occupancy,
                Rate = cottage.Rate,
                Sqft = cottage.Sqft
            };
            if (cottage == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(cottageDTO, ModelState);
            Cottage model = new Cottage()
            {
                Amenity = cottageDTO.Amenity,
                Details = cottageDTO.Details,
                Id = cottageDTO.Id,
                ImageUrl = cottageDTO.ImageUrl,
                Name = cottageDTO.Name,
                Occupancy = cottageDTO.Occupancy,
                Rate = cottageDTO.Rate,
                Sqft = cottageDTO.Sqft
            };
            _db.Cottages.Update(model);
            _db.SaveChanges();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
