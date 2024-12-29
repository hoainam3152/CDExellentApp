using CDExellentAPI.DTO.Requests;
using CDExellentAPI.Enums;
using CDExellentAPI.Repositories;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CDExellentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiveController : BaseController
    {
        private readonly IReceiveRepository service;

        public ReceiveController(IReceiveRepository service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var obs = service.GetAll();
                if (obs.Any())
                {
                    return CustomResult(ResponseMessage.SUCCESSFUL, obs, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("id")]
        public IActionResult GetById(int NotificationId, int ReceiverId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ob = service.GetById(NotificationId, ReceiverId);
                    if (ob != null)
                    {
                        return CustomResult(ResponseMessage.SUCCESSFUL, ob, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (Exception ex)
                {
                    return CustomResult(ex.Message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public IActionResult Create(ReceiveRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ob = service.Create(request);
                    return CustomResult(ResponseMessage.CREATE_SUCCESSFUL, ob, HttpStatusCode.OK);
                }
                catch (DbUpdateException)
                {
                    return CustomResult(ResponseMessage.CREATE_FAILED, HttpStatusCode.BadRequest);
                }
                catch (Exception ex)
                {
                    return CustomResult(ex.Message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int NotificationId, int ReceiverId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ob = service.Delete(NotificationId, ReceiverId);
                    if (ob != null)
                    {
                        return CustomResult(ResponseMessage.DELETE_SUCCESSFUL, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (DbUpdateException)
                {
                    return CustomResult(ResponseMessage.DELETE_FAILED, HttpStatusCode.BadRequest);
                }
                catch (Exception ex)
                {
                    return CustomResult(ex.Message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
