using Microsoft.AspNetCore.Mvc;
using Order.api.Interfaces;
using Order.api.Manager;
using Order.api.Repositories;
using Order.Models.DTO;
using Order.Models.Entity;
using System.Collections.Generic;

namespace Order.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowsController : ControllerBase
    {
        private readonly IWindowRepositories windowRepository;
        private readonly ISubElementRepositories subElementRepositories;
        private Mapper mapper;

        public WindowsController(IWindowRepositories windowRepository, ISubElementRepositories subElementRepositories)
        {
            this.windowRepository = windowRepository;
            this.subElementRepositories = subElementRepositories;
            mapper = new Mapper();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WindowDto>>> GetWindows()
        {
            try
            {
                List<WindowDto> WindowDtoList = new List<WindowDto>();
                var windowList = await windowRepository.GetWindows();
                foreach(Window wnd in windowList)
                {
                    WindowDtoList.Add(await mapper.MapWindowDto(wnd, subElementRepositories));
                }
                return Ok(WindowDtoList);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<WindowDto>> GetWindow(int id)
        {
            try
            {
                Window window = await windowRepository.GetWindow(id);
                if (window == null) return NotFound();
                WindowDto WindowDto = await mapper.MapWindowDto(window, subElementRepositories);

                return WindowDto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Window>> CreateWindow(WindowDto windowDto)
        {
            try
            {
                Window window = await mapper.MapWindow(windowDto);
                if (window == null)
                    return BadRequest();
                await windowRepository.AddWindow(window);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut()]
        public async Task<ActionResult<Window>> UpdateWindow(WindowDto windowDto)
        {
            try
            {
                if (windowDto == null)
                    return NotFound();

                Window window = await mapper.MapWindow(windowDto);
                await windowRepository.UpdateWindow(window);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<HttpResponseMessage>> DeleteWindow(int id)
        {
            try
            {
                await windowRepository.DeleteWindow(id);
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
