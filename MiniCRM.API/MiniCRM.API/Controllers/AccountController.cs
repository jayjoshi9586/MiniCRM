﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using BusinessLogicCore.Implementation;
using DataAccessCore.Entities;
using DataAccessCore.Implementation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
//using MiniCRM.API.Models;
//using MiniCRM.API.Models;
//using MiniCRM.API.Providers;
using MiniCRM.API.Results;
using Owin;

namespace MiniCRM.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        //private ApplicationUserManager _userManager;
        //private ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        private MiniCRMModel applicationDbContext = new MiniCRMModel();
        private AdminLog _adminLog = new AdminLog();
        private AccountLog _accountLog = new AccountLog();

        public AccountController()
        {
        }

        //public AccountController(ApplicationUserManager userManager,
        //    ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        //{
        //    UserManager = userManager;
        //    AccessTokenFormat = accessTokenFormat;
        //}
        public IEnumerable<Account> Get()
        {
            return _accountLog.AccountGet();
        }
        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        // GET api/Account/UserInfo
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("UserInfo")]
        //public UserInfoViewModel GetUserInfo()
        //{
        //    ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

        //    return new UserInfoViewModel
        //    {
        //        Email = User.Identity.GetUserName(),
        //        HasRegistered = externalLogin == null,
        //        LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
        //    };
        //}

        // POST api/Account/Logout
        //[Route("Logout")]
        //public IHttpActionResult Logout()
        //{
        //    Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
        //    return Ok();
        //}

        //// GET api/Account/ManageInfo?returnUrl=%2F&generateState=true
        //[Route("ManageInfo")]
        //public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
        //{
        //    IdentityUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

        //    if (user == null)
        //    {
        //        return null;
        //    }

        //    List<UserLoginInfoViewModel> logins = new List<UserLoginInfoViewModel>();

        //    foreach (IdentityUserLogin linkedAccount in user.Logins)
        //    {
        //        logins.Add(new UserLoginInfoViewModel
        //        {
        //            LoginProvider = linkedAccount.LoginProvider,
        //            ProviderKey = linkedAccount.ProviderKey
        //        });
        //    }

        //    if (user.PasswordHash != null)
        //    {
        //        logins.Add(new UserLoginInfoViewModel
        //        {
        //            LoginProvider = LocalLoginProvider,
        //            ProviderKey = user.UserName,
        //        });
        //    }

        //    return new ManageInfoViewModel
        //    {
        //        LocalLoginProvider = LocalLoginProvider,
        //        Email = user.UserName,
        //        Logins = logins,
        //        ExternalLoginProviders = GetExternalLogins(returnUrl, generateState)
        //    };
        //}
        [Authorize]
        public IHttpActionResult Authorize()
        {
            return Ok("Authorized");

        }

        //// POST api/Account/ChangePassword
        //[Route("ChangePassword")]
        //public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
        //        model.NewPassword);

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    return Ok();
        //}

        //public void Randompassword()
        //{

        //}

        //// POST api/Account/ChangePassword
        //[Authorize]
        //[Route("ForgotPassword")]
        //public async Task<IHttpActionResult> ForgotPassword(ForgotPasswordBindingModel model)
        //{
        //    String Subject = "new Password";
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var user = UserManager.FindByEmail(model.Email);
        //    if(user==null)
        //    {
        //        return NotFound();
        //    }
        //    String Passwordtoken = UserManager.GeneratePasswordResetToken(user.Id);
        //    await UserManager.SendEmailAsync(user.Id,Subject,Passwordtoken);
        //    //    model.NewPassword);

        //    //if (!result.Succeeded)
        //    //{
        //    //    return GetErrorResult(result);
        //    //}

        //    return Ok();
        //}


        //for login grant_type=password&username=jazzyy9586&password=Det@2018!
        // POST api/Account/ChangePassword

        //[HttpPost]
        //[Route("LoginTest")]
        //public IHttpActionResult LoginTest(LoginTestBindingModel model)
        //{
        //    Admin admin= 
        //    return Ok();

        //}

        //[Authorize]
        //[Route("ForgotPassword")]
        //public String ForgotPassword(ForgotPasswordBindingModel model)
        //{
        //    String Subject = "Mini-CRM Password Reset Token";

        //    if (!ModelState.IsValid)
        //    {
        //        return "Invalid Request";
        //    }
        //    var user = UserManager.FindByEmail(model.Email);
        //    if (user == null)
        //    {
        //        return "Sorry! No record is linked to that Email.";
        //    }
        //    String Passwordtoken = UserManager.GeneratePasswordResetToken(user.Id);            

        //    //Creating a SMTP client to send/receive emails
        //    SmtpClient client = new SmtpClient("smtp.gmail.com");
        //    client.Host = "smtp.gmail.com";
        //    client.Port = 587;
        //    client.EnableSsl = true;
        //    client.UseDefaultCredentials = false;
        //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    client.Credentials = new System.Net.NetworkCredential("jay.joshi.det@gmail.com", "det@1234567@9");            

        //    MailMessage message = new MailMessage();
        //    message.From = new MailAddress("jay.joshi.det@gmail.com", "Jay Joshi");
        //    message.To.Add(new MailAddress(model.Email, "Jay Joshi"));
        //    message.Subject = Subject;
        //    message.Body = Passwordtoken;
        //    message.BodyEncoding = UTF8Encoding.UTF8;
        //    message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        //    client.Send(message);                  
        //    return "Mail has been sent with a code to reset your password.";
        //}

        //// POST api/Account/SetPassword
        //[Authorize]
        //[Route("SetPassword")]
        //public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    return Ok();
        //}

        // POST api/Account/AddExternalLogin
        //[Route("AddExternalLogin")]
        //public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

        //    AuthenticationTicket ticket = AccessTokenFormat.Unprotect(model.ExternalAccessToken);

        //    if (ticket == null || ticket.Identity == null || (ticket.Properties != null
        //        && ticket.Properties.ExpiresUtc.HasValue
        //        && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
        //    {
        //        return BadRequest("External login failure.");
        //    }

        //    ExternalLoginData externalData = ExternalLoginData.FromIdentity(ticket.Identity);

        //    if (externalData == null)
        //    {
        //        return BadRequest("The external login is already associated with an account.");
        //    }

        //    IdentityResult result = await UserManager.AddLoginAsync(User.Identity.GetUserId(),
        //        new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    return Ok();
        //}

        //// POST api/Account/RemoveLogin
        //[Route("RemoveLogin")]
        //public async Task<IHttpActionResult> RemoveLogin(RemoveLoginBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult result;

        //    if (model.LoginProvider == LocalLoginProvider)
        //    {
        //        result = await UserManager.RemovePasswordAsync(User.Identity.GetUserId());
        //    }
        //    else
        //    {
        //        result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(),
        //            new UserLoginInfo(model.LoginProvider, model.ProviderKey));
        //    }

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    return Ok();
        //}

        //// GET api/Account/ExternalLogin 
        //[OverrideAuthentication]
        //[HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        //[AllowAnonymous]
        //[Route("ExternalLogin", Name = "ExternalLogin")]
        //public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        //{
        //    if (error != null)
        //    {
        //        return Redirect(Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
        //    }

        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return new ChallengeResult(provider, this);
        //    }

        //    ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

        //    if (externalLogin == null)
        //    {
        //        return InternalServerError();
        //    }

        //    if (externalLogin.LoginProvider != provider)
        //    {
        //        Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        //        return new ChallengeResult(provider, this);
        //    }

        //    ApplicationUser user = await UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider,
        //        externalLogin.ProviderKey));

        //    bool hasRegistered = user != null;

        //    if (hasRegistered)
        //    {
        //        Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

        //         ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
        //            OAuthDefaults.AuthenticationType);
        //        ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserManager,
        //            CookieAuthenticationDefaults.AuthenticationType);

        //        AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
        //        Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
        //    }
        //    else
        //    {
        //        IEnumerable<Claim> claims = externalLogin.GetClaims();
        //        ClaimsIdentity identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
        //        Authentication.SignIn(identity);
        //    }

        //    return Ok();
        //}

        //// GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
        //[AllowAnonymous]
        //[Route("ExternalLogins")]
        //public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
        //{
        //    IEnumerable<AuthenticationDescription> descriptions = Authentication.GetExternalAuthenticationTypes();
        //    List<ExternalLoginViewModel> logins = new List<ExternalLoginViewModel>();

        //    string state;

        //    if (generateState)
        //    {
        //        const int strengthInBits = 256;
        //        state = RandomOAuthStateGenerator.Generate(strengthInBits);
        //    }
        //    else
        //    {
        //        state = null;
        //    }

        //    foreach (AuthenticationDescription description in descriptions)
        //    {
        //        ExternalLoginViewModel login = new ExternalLoginViewModel
        //        {
        //            Name = description.Caption,
        //            Url = Url.Route("ExternalLogin", new
        //            {
        //                provider = description.AuthenticationType,
        //                response_type = "token",
        //                client_id = Startup.PublicClientId,
        //                redirect_uri = new Uri(Request.RequestUri, returnUrl).AbsoluteUri,
        //                state = state
        //            }),
        //            State = state
        //        };
        //        logins.Add(login);
        //    }

        //    return logins;
        //}

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public IHttpActionResult Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Admin admin = new Admin() {Admin_id=model.Admin_id, Admin_username = model.Username, Admin_email = model.Email, Admin_type_id = model.Admin_type_id, Admin_pwd = model.Password };

            //{ Admin_username = model.u, Admin_email = model.Admin_email, Admin_type_id = model.Admin_type_id, Admin_pwd = model.Admin_pwd };
            
            int response = _adminLog.AdminInsert(admin);
         

            //int inserData = binding.Save();
            if (response==1)
            {
                return Ok("Record added to the database");
            }                
            else
            {
                return BadRequest("Not able to save the record in database");
            }
                
        }
             private Binding binding = new Binding();
        //Admin admin = new Admin();
        //{
        //    admin.Admin_aadhar_id = null;
        //    admin.Admin_contact_no = null;
        //    admin.Admin_id = model.Admin_type_id;
        //    admin.Admin_firstname = null;
        //    admin.Admin_lastname = null;
        //        admin.Admin_username = model.Username;
        //        admin.
        //        admin.
        //        admin.
        //        admin.
        //        admin.


        //}
        //int response = _adminLog.AdminInsert();
        // IAppBuilder app1;
        
        //var user = new ApplicationUser() { UserName = model.Username, Email = model.Email, Admin_type_id = model.Admin_type_id };

        //IdentityResult result = await UserManager.CreateAsync(user, model.Password);
        
            //if (!result.Succeeded)
            //{
            //    return GetErrorResult(result);
            //}

            
    
            
    

        // POST api/Account/EditProfile
        [Authorize]

        //[Route("EditProfile")]
        //public IHttpActionResult EditProfile(EditProfileBindingModel model)
        //{

        //    int result;
        //    //var id=User.Identity.GetUserId();
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    ApplicationUser user;//= await UserManager.FindByNameAsync(model.username);
        //     user = applicationDbContext.Users.AsNoTracking().Where(a => a.UserName == model.username).FirstOrDefault();

        //    if (user == null)
        //    {
        //        return BadRequest("No such user. Try Again");
        //    }

        //    result = _adminLog.AdminUpdate(model, user);

        //    if (result == 1)
        //    {
        //        return Ok("Changes Saved Successfully!");
        //    }

        //    return InternalServerError();

        //}
        //JSON Request type:
        //grant_type=password&username=jazzyy9586&password=Det@2018!
        //[AllowAnonymous]
        //[Route("Login")]
        //public  async Task Login(OAuthGrantResourceOwnerCredentialsContext model)
        //{
        //    ApplicationUser user = await UserManager.FindAsync(model.UserName, model.Password);
            
        //    if (user == null)
        //    {
        //        model.SetError("invalid_grant", "The user name or password is incorrect.");
        //        return;
        //    }
        //    //ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");

        //    ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
        //       OAuthDefaults.AuthenticationType);
        //    ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(UserManager,
        //        CookieAuthenticationDefaults.AuthenticationType);

        //    AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
        //    AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
        //    model.Validated(ticket);
        //    model.Request.Context.Authentication.SignIn(cookiesIdentity);
        //}
        [AllowAnonymous]
        [Route("CreateAccount")]
        public IHttpActionResult CreateAccount(Account model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int response = _accountLog.AccountInsert(model);
            if(response==1)
            {
                return Ok("Account has been added");
            }
            else
            {
                return BadRequest("There was some error please try again.");
            }
            //var account = new Account() { Account_id = model.Account_id, Account_global_email = model.Account_global_email, Account_name = model.Account_name, Account_brand_logo=model.Account_brand_logo };
           // return Ok();
        }

       [AllowAnonymous]
        public Account Get(int id)
        {
            return _accountLog.AccountGet(id);

        }

        //// POST api/Account/RegisterExternal
        //[OverrideAuthentication]
        //[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        //[Route("RegisterExternal")]
        //public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var info = await Authentication.GetExternalLoginInfoAsync();
        //    if (info == null)
        //    {                
        //        return InternalServerError();
        //    }

        //    var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

        //    IdentityResult result = await UserManager.CreateAsync(user);
        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    result = await UserManager.AddLoginAsync(user.Id, info.Login);
        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result); 
        //    }
        //    return Ok();
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && _userManager != null)
        //    {
        //        _userManager.Dispose();
        //        _userManager = null;
        //    }

        //    base.Dispose(disposing);
        //}

        #region Helpers

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
            public string UserName { get; set; }

            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

                if (UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
                }

                return claims;
            }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || String.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                {
                    LoginProvider = providerKeyClaim.Issuer,
                    ProviderKey = providerKeyClaim.Value,
                    UserName = identity.FindFirstValue(ClaimTypes.Name)
                };
            }
        }

        private static class RandomOAuthStateGenerator
        {
            private static RandomNumberGenerator _random = new RNGCryptoServiceProvider();

            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
                }

                int strengthInBytes = strengthInBits / bitsPerByte;

                byte[] data = new byte[strengthInBytes];
                _random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }
        }

        #endregion
    }
}