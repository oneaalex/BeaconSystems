using System.Text.RegularExpressions;
using SmartBuilding.Web.Models;
using System.Web.Http;
using System.Web.Http.Results;

namespace SmartBuilding.Web.Controllers
{
    public class SignUpController : ApiController
    {
        public object Get()
        {
            return Json(new { Data = "Add user and password" });
        }

        public JsonResult<SignUpResult> Post(SignUpModel model)
        {
            var signUpResult = new SignUpResult();

            if (!(Regex.IsMatch(model.UserName, @"^[a-zA-Z0-9]*$") && (4 <= model.UserName.Length) && (model.UserName.Length <=12)))
            {
                signUpResult.Message = "Invalid username characters";
            }
            else if (!((Regex.IsMatch(model.Password, @"^[a-zA-Z]+[0-9]*$")) && (6 <= model.Password.Length) && (model.Password.Length <= 12)))
            {
                signUpResult.Message = "Invalid password";
            }
            else
            {
                signUpResult.Success = true;
            }
            return Json(signUpResult);
        }
    }
}
