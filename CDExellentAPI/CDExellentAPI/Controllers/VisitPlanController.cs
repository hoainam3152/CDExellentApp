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
    public class VisitPlanController : BaseController
    {
        private readonly IVisitPlanRepository service;

        public VisitPlanController(IVisitPlanRepository service)
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
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ob = service.GetById(id);
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
        public IActionResult Create(VisitPlanRequest request)
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

        [HttpPut]
        public IActionResult Update(int id, VisitPlanRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ob = service.Update(id, request);
                    if (ob != null)
                    {
                        return CustomResult(ResponseMessage.UPDATE_SUCCESSFUL, ob, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (DbUpdateException)
                {
                    return CustomResult(ResponseMessage.UPDATE_FAILED, HttpStatusCode.BadRequest);
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
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ob = service.Delete(id);
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
