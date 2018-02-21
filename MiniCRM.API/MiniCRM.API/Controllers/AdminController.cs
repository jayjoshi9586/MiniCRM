using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Security;
using System.Web.Http;
using BusinessLogic.Interface;
using BusinessLogicCore.Implementation;
using DataAccess.Interface;
using DataAccessCore.Implementation;
using DataAccessCore.Entities;
using System.Data.Entity;
using DataAccessCore.Identity;
using MiniCRM.API.Filters;
using System.Text;
using System.Security.Cryptography;
using DataAccessCore.Models;

namespace EasyCRM.API.Controllers
{
    //[JWTAuthenticationFilter]
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        private AdminLog _adminLog = new AdminLog();
        private MiniCRMModel applicationDbContext = new MiniCRMModel();
        Admin admin = new Admin();
        AdminLog adminobj = new AdminLog();
        // GET: api/Admin
        [JWTAuthenticationFilter]
        public IEnumerable<AdminGetModel> Get()
        {
            //IEnumerable<Admin> admin = adminobj.AdminGet();
            return adminobj.AdminGet();
        }

        // GET: api/Admin/5
        [JWTAuthenticationFilter]
        public AdminGetModel Get(int id)
        {
            return adminobj.AdminGet(id);
        }
        [JWTAuthenticationFilter]
        //[Route("GetByUsername")]
        public Admin GetbyUserName(string model)
        {
            return _adminLog.GetByUsername(model);
        }
        //[Authorize]
        [JWTAuthenticationFilter]
        [Route("ActivateUser")]
        public IHttpActionResult ActivateUser(UsernameSpecificBindingModel model)
        {
            int response = _adminLog.ActivateUser(model.Username);
            if (response==1)
            {
                return Ok("User Activated");
            }

            return BadRequest("Could not activate the user. Please try again.");
        }

        [JWTAuthenticationFilter]
        public IHttpActionResult CreateuserRole(AdminType model)
        {
            int response = _adminLog.CreateRole(model);
            if(response==1)
            {
                return Ok("Role added!");
            }
            return BadRequest("Sorry, could not add the role.");
            
        }

        [JWTAuthenticationFilter]
        [Route("DeActivateUser")]
        public IHttpActionResult DeActivateUser(UsernameSpecificBindingModel model)
        {
            int response = _adminLog.DeActivateUser(model.Username);
            if (response == 1)
            {
                return Ok("User Activated");
            }

            return BadRequest("Could not activate the user. Please try again.");
        }

        [AllowAnonymous]
        [Route("Register")]
        public IHttpActionResult Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Admin admin = new Admin() { Admin_id = model.Admin_id, Admin_username = model.Username, Admin_email = model.Email, Admin_type_id = model.Admin_type_id, Admin_pwd = model.Password,IsDeleted=false };
            
            int response = _adminLog.AdminInsert(admin);

            //int inserData = binding.Save();
            if (response == 1)
            {
                return Ok("Record added to the database");
            }
            else
            {
                return BadRequest("Not able to save the record in database");
            }
        }

        //[Route("LoginDemo")]
        [HttpPost]
        [Route("LoginDemo")]
        public LoginResponseModel LoginDemo(LoginTestBindingModel model)
        {
            //Admin admin = new Admin() {Admin_username=model.Username,Admin_pwd=model.Password };
            Admin admin = _adminLog.GetByUsername(model.Username);
            int validate = _adminLog.ValidateUser(model);
            ////MockAuthenticationService demoService = new MockAuthenticationService();
            ////Admin user = demoService.GetUser(model.Username, model.Password);
            LoginResponseModel loginresponse = new LoginResponseModel();
            if (validate == 0)
            {
                loginresponse.accesstoken = null;
                loginresponse.Admin_id = -1;
                loginresponse.success = false;
                //return N("Username or Password is Incorrect");
                return loginresponse;//Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid Username or Password", Configuration.Formatters.JsonFormatter);
            }
            else
            {
                AuthenticationModule authentication = new AuthenticationModule();
                string token = authentication.GenerateTokenForUser(admin.Admin_username, admin.Admin_id);
                //string token = authentication.GenerateTokenForUser(model.sername, admin.Admin_id);
                loginresponse.accesstoken = token;
                loginresponse.Admin_id = admin.Admin_id;
                loginresponse.success = true;
                return loginresponse; //Request.CreateResponse(HttpStatusCode.OK, token, Configuration.Formatters.JsonFormatter);
            }

        }
        // POST: api/Admin
        public IHttpActionResult Post([FromBody]Admin admin)
        {
            int response = adminobj.AdminInsert(admin);

            if (response == 1)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/Account/EditProfile       
        [JWTAuthenticationFilter]
        [Route("EditProfile")]
        public IHttpActionResult EditProfile(EditProfileBindingModel model)
        {

            int result;
            //var id=User.Identity.GetUserId();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Admin admin = _adminLog.GetByUsername(model.username);
           // ApplicationUser user;//= await UserManager.FindByNameAsync(model.username);
            //user = applicationDbContext.Users.AsNoTracking().Where(a => a.UserName == model.username).FirstOrDefault();

            if (admin == null)
            {
                return BadRequest("No such user. Try Again");
            }

            result = _adminLog.AdminUpdate(model, admin);

            if (result == 1)
            {
                return Ok("Changes Saved Successfully!");
            }

            return InternalServerError();

        }

        // Generate a random number between two numbers
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        // Generate a random string with a given size  
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        // Generate a random password  
        public string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        [JWTAuthenticationFilter]
        [Route("ForgotPassword")]
        public String ForgotPassword(ForgotPasswordBindingModel model)
        {
            String Subject = "Mini-CRM Password Reset Token";

            if (!ModelState.IsValid)
            {
                return "Invalid Request";
            }
            var user = _adminLog.GetByEmail(model.Email);
            if (user == null)
            {
                return "Sorry! No record is linked to that Email.";
            }
            String Passwordtoken = RandomPassword();

            //Creating a SMTP client to send/receive emails
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("jay.joshi.det@gmail.com", "det@1234567@9");

            MailMessage message = new MailMessage();
            message.From = new MailAddress("jay.joshi.det@gmail.com", "Jay Joshi");
            message.To.Add(new MailAddress(model.Email, "Jay Joshi"));
            message.Subject = Subject;
            message.Body = Passwordtoken;
            message.BodyEncoding = UTF8Encoding.UTF8;
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(message);
            return "Mail has been sent with a code to reset your password.";
        }

        [JWTAuthenticationFilter]
        public IHttpActionResult Authorize()
        {
            return Ok("Authorized");

        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
            adminobj.AdminDelete(id);
        }
    }
}
