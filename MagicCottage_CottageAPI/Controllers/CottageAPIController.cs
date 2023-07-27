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
        [HttpGet("{id:int}")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CottageDTO> CreateCottage([FromBody]CottageDTO cottageDTO)
        {
            if(cottageDTO == null)
            {
                return BadRequest(cottageDTO);
            }
            if(cottageDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            cottageDTO.Id=CottageStore.cottageList.OrderByDescending(u=>u.Id).FirstOrDefault().Id+1;
            CottageStore.cottageList.Add(cottageDTO);
            return Ok(cottageDTO);
        }
    }
}
