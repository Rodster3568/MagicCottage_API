using MagicCottage_CottageAPI.Data;
using MagicCottage_CottageAPI.Models;
using MagicCottage_CottageAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicCottage_CottageAPI.Controllers
{
    [Route("api/CottageAPI")]
    [ApiController]
    public class CottageAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CottageDTO>> GetCottages()
        {
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
    }
}
