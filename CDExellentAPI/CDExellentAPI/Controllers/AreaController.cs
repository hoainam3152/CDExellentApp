using CDExellentAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CDExellentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : ControllerBase
    {
        private readonly IAreaRepository service;

        public AreaController(IAreaRepository service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var areas = service.GetAll();
                if (areas != null)
                {
                    return Ok(areas);
                }
                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
