using Directionary.Web.App_Start;
using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Directionary.Web.Api
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<HttpResponseMessage> Post(HttpRequestMessage request, string userName, string password, bool rememberMe)
        {
            if (!ModelState.IsValid)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(userName, password, rememberMe, shouldLockout: false);

            string result_str = "";
            if (result == 0)
            {
                result_str = "Đăng nhập thành công.";
            }
            else if ((int)result == 1)
            {
                result_str = "Tài khoản bị khóa.";
            }
            else if ((int)result == 2)
            {
                result_str = "Yêu cầu  cập nhật thông tin.";
            }
            else if ((int)result == 3)
            {
                result_str = "Tên tài khoản hoặc mật khẩu không chính xác.";
            }
            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        //return RedirectToLocal(returnUrl);

            //    case SignInStatus.LockedOut:
            //        //return View("Lockout");
            //    case SignInStatus.RequiresVerification:
            //        //return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            //    case SignInStatus.Failure:
            //    default:

            //        //ModelState.AddModelError("", "Invalid login attempt.");
            //        //return View(model);
            //}

            return request.CreateResponse(HttpStatusCode.OK, result_str);
        }





        



    }
}