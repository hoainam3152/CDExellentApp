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
    public class UserController : BaseController
    {
        private readonly IUserRepository service;

        public UserController(IUserRepository service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var urs = service.GetAll();
                if (urs.Any())
                {
                    return CustomResult(ResponseMessage.SUCCESSFUL, urs, HttpStatusCode.OK);
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
                    var user = service.GetById(id);
                    if (user != null)
                    {
                        return CustomResult(ResponseMessage.SUCCESSFUL, user, HttpStatusCode.OK);
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
        public IActionResult Create(UserRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = service.Create(request);
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
        public IActionResult Update(int id, UserRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = service.Update(id, request);
                    if (user != null)
                    {
                        return CustomResult(ResponseMessage.UPDATE_SUCCESSFUL, user, HttpStatusCode.OK);
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
                    var user = service.Delete(id);
                    if (user != null)
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
