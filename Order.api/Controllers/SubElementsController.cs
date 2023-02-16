using Microsoft.AspNetCore.Mvc;
using Order.api.Interfaces;
using Order.api.Manager;
using Order.api.Repositories;
using Order.Models.DTO;
using Order.Models.Entity;

namespace Order.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubElementsController : ControllerBase
    {
        private readonly ISubElementRepositories subElementRepository;
        private Mapper mapper;
        public SubElementsController(ISubElementRepositories subElementRepository)
        {
            this.subElementRepository = subElementRepository;
            this.mapper = new Mapper();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubElementDto>>> GetSubElements()
        {
            try
            {
                List<SubElementDto> subElementDtos = new List<SubElementDto>();
                var subElements = await subElementRepository.GetSubElements();
                foreach(SubElement subElement in subElements)
                {
                    subElementDtos.Add(await mapper.MapSubElementDto(subElement));
                }
                return Ok(subElementDtos);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SubElementDto>> GetSubElement(int id)
        {
            try
            {
                var subElement = await subElementRepository.GetSubElement(id);
                if (subElement == null) return NotFound();
                return await mapper.MapSubElementDto(subElement);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{searchByWindow}/{windowId:int}")]
        public async Task<ActionResult<SubElementDto>> GetSubElementByWindow(int windowId)
        {
            try
            {
                List<SubElementDto> subElementDtos = new List<SubElementDto>();
                var subElements = await subElementRepository.GetSubElementByWindow(windowId);
                if (subElements == null)
                    return NotFound();
                else
                {
                    foreach (SubElement subElement in subElements)
                    {
                        subElementDtos.Add(await mapper.MapSubElementDto(subElement));
                    }
                }
                return Ok(subElementDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubElement(SubElementDto subElementDto)
        {
            try
            {
                if (subElementDto == null)
                    return BadRequest();
                SubElement subElement = await mapper.MapSubElement(subElementDto);
                await subElementRepository.AddSubElement(subElement);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateSubElement(SubElementDto subElementDto)
        {
            try
            {
                if (subElementDto == null)
                    return NotFound();
                SubElement subElement = await mapper.MapSubElement(subElementDto);

                await subElementRepository.UpdateSubElement(subElement);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<HttpResponseMessage>> DeleteSubElement(int id)
        {
            try
            {
                await subElementRepository.DeleteSubElement(id);
                return StatusCode(StatusCodes.Status200OK,
                    "Deleted data");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}
