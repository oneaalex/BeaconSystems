using SmartBuilding.Web.Models;
using System.Web.Http;
using System.Web.Http.Results;

namespace SmartBuilding.Web.Controllers
{
    public class LoginController : ApiController
    {
        public object Get()
        {
            return Json(new {Data = "Add credentials"});
        }


        public JsonResult<LoginResult> Post(LoginModel model)
        {
            var loginResult = new LoginResult();
            if (model.UserName == "alex" && model.Password  == "alex")
            {
                loginResult.Success = true;
            }
            else
            {
                loginResult.Message = "Invalid login";
            }
            return Json(loginResult);
        }

//        [Route("api/login/{user}/{password}")]
//        public JsonResult<LoginResult> Put(string user, string password)
//        {
//            var loginResult = new LoginResult();
//            if (user == "alex" && password == "alex")
//            {
//                loginResult.Success = true;
//            }
//            else
//            {
//                loginResult.Message = "Invalid login";
//            }
//            return Json(loginResult);
//        }
    }
}
