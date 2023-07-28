using MagicCottage_CottageAPI.Data;
using MagicCottage_CottageAPI.Logging;
using MagicCottage_CottageAPI.Models;
using MagicCottage_CottageAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicCottage_CottageAPI.Controllers
{
    [Route("api/CottageAPI")]
    [ApiController]
    public class CottageAPIController : ControllerBase
    {
        private readonly ILogging _logger;
        public CottageAPIController(ILogging logger) 
        {
            _logger= logger;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CottageDTO>> GetCottages()
        {
            _logger.Log("Getting all cottages","");
            return Ok(CottageStore.cottageList);
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
            var cottage = CottageStore.cottageList.FirstOrDefault(u => u.Id == id);
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
            if (CottageStore.cottageList.FirstOrDefault(u => u.Name.ToLower() == cottageDTO.Name.ToLower()) != null)
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
            cottageDTO.Id = CottageStore.cottageList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            CottageStore.cottageList.Add(cottageDTO);
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
            var cottage = CottageStore.cottageList.FirstOrDefault(u => u.Id == id);
            if (cottage == null)
            {
                return BadRequest();
            }
            CottageStore.cottageList.Remove(cottage);
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
            var cottage = CottageStore.cottageList.FirstOrDefault(u => u.Id == id);
            cottage.Name=cottageDTO.Name;
            cottage.Sqft=cottageDTO.Sqft;
            cottage.Occupancy=cottageDTO.Occupancy;

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
            var cottage = CottageStore.cottageList.FirstOrDefault(u => u.Id == id);
            if (cottage == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(cottage, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
