using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfosController : ControllerBase
    {

        private IUserInfo _userInfo;
        public UserInfosController(IUserInfo userInfo)
        {
            _userInfo = userInfo;
        }

        //Post: api/UserInfos/Authenticate
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userInfo.Authenticate(model.Username, model.Password);
            if (user == null) return BadRequest(new { message="Username and password incorrect"});
            return Ok(user);
        }
           



            // GET: api/UserInfos
            [HttpGet]
            [Authorize]
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }

            // GET api/<UserInfosController>/5
            [HttpGet("{id}")]
            public string Get(int id)
            {
                return "value";
            }

            // POST api/<UserInfosController>
            [HttpPost]
            public void Post([FromBody] string value)
            {
            }

            // PUT api/<UserInfosController>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/<UserInfosController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }


     }
 }

