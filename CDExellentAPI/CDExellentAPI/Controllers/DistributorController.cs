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
    public class DistributorController :  BaseController
    {
        private readonly IDistributorRepository service;

        public DistributorController(IDistributorRepository service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var dtbts = service.GetAll();
                if (dtbts.Any())
                {
                    return CustomResult(ResponseMessage.SUCCESSFUL, dtbts, HttpStatusCode.OK);
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
                    var dtbt = service.GetById(id);
                    if (dtbt != null)
                    {
                        return CustomResult(ResponseMessage.SUCCESSFUL, dtbt, HttpStatusCode.OK);
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
        public IActionResult Create(DistributorRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dtbt = service.Create(request);
                    return CustomResult(ResponseMessage.CREATE_SUCCESSFUL, request, HttpStatusCode.OK);
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
        public IActionResult Update(int id, DistributorRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dtbt = service.Update(id, request);
                    if (dtbt != null)
                    {
                        return CustomResult(ResponseMessage.UPDATE_SUCCESSFUL, dtbt, HttpStatusCode.OK);
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
                    var dtbt = service.Delete(id);
                    if (dtbt != null)
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
