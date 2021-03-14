using Business.Abstruct;
using Entities.Concrute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationsController : ControllerBase
    {
        ICommunicationService _communicationService;

        public CommunicationsController(ICommunicationService communicationService)
        {
            _communicationService = communicationService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _communicationService.GetAll();
            if (result.Succcess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int id)
        {
            var result = _communicationService.GetByCustomerId(id);
            if (result.Succcess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("add")]
        public IActionResult Add(Communication communication)
        {
            var result = _communicationService.Add(communication);

            if (result.Succcess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Communication communication)
        {
            var result = _communicationService.Delete(communication);

            if (result.Succcess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPut("update")]
        public IActionResult Update(Communication communication)
        {
            var result = _communicationService.Update(communication);

            if (result.Succcess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
