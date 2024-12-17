using CDExellentAPI.Enums;
using CDExellentAPI.Repositories;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CDExellentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : BaseController
    {
        private readonly IAreaRepository service;

        public AreaController(IAreaRepository service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var areas = service.GetAll();
                if (areas.Any())
                {
                    return CustomResult(ResponseMessage.SUCCESSFULLY, areas, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
