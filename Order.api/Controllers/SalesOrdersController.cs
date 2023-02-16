using Microsoft.AspNetCore.Mvc;
using Order.api.Interfaces;
using Order.api.Repositories;
using Order.Models.Entity;

namespace Order.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrdersController : ControllerBase
    {
        private readonly ISalesOrderRepositories salesOrderRepository;
        public SalesOrdersController(ISalesOrderRepositories salesOrderRepository)
        {
            this.salesOrderRepository = salesOrderRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrder>>> GetSalesOrders()
        {
            try
            {
                return Ok(await salesOrderRepository.GetSalesOrders());
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SalesOrder>> GetSalesOrder(int id)
        {
            try
            {
                var result = await salesOrderRepository.GetSalesOrder(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateSalesOrder(SalesOrder salesOrder)
        {
            try
            {
                if (salesOrder == null)
                    return BadRequest();
                await salesOrderRepository.AddSalesOrder(salesOrder);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateSalesOrder(SalesOrder salesOrder)
        {
            try
            {
                if (salesOrder == null)
                    return BadRequest();
                await salesOrderRepository.UpdateSalesOrder(salesOrder);
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
                await salesOrderRepository.DeleteSalesOrder(id);
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
