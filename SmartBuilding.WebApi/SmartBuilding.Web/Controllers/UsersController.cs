using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartBuilding.Web.DAL.Interface;
using SmartBuilding.Web.EF;

namespace SmartBuilding.Web.Controllers
{
    public class UsersController : ApiController
    {
        // This line of code is a problem!
        //UserRepository _repository = new UserRepository();

        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> Get()
        {
            return _repository.GetUsers();
        }

        public IHttpActionResult Get(int id)
        {
            var user = _repository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        public IHttpActionResult Post(User user)
        {

            try
            {
                _repository.Add(user);
            }
            catch (DbException)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent("Unable to add new user.") };
                return ResponseMessage(response);
            }
            
            return Ok();
        }
    }
}
