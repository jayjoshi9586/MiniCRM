using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic.Interface;
using BusinessLogicCore.Implementation;
using DataAccess.Interface;
using DataAccessCore.Implementation;
using DataAccessCore.Entities;
using System.Data.Entity;
using DataAccessCore.Identity;

namespace EasyCRM.API.Controllers
{
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        private AdminLog _adminLog = new AdminLog();
        private MiniCRMModel applicationDbContext = new MiniCRMModel();
        AdminLog adminobj = new AdminLog();
        // GET: api/Admin
        public IEnumerable<Admin> Get()
        {
            return adminobj.AdminGet();
        }

        // GET: api/Admin/5
        
        public Admin Get(int id)
        {
            return adminobj.AdminGet(id);
        }
        [Route("GetByUsername")]
        public Admin GetbyUserName(String Username)
        {
            return _adminLog.GetByUsername(Username);
        }
        //[Route("LoginDemo")]
        [HttpPost]
        [Route("LoginDemo")]
        public HttpResponseMessage LoginDemo(LoginTestBindingModel model)
        {
            //Admin admin = new Admin() {Admin_username=model.Username,Admin_pwd=model.Password };
            Admin admin = _adminLog.GetByUsername(model.Username);
            int validate = _adminLog.ValidateUser(model);
            ////MockAuthenticationService demoService = new MockAuthenticationService();
            ////Admin user = demoService.GetUser(model.Username, model.Password);
            if (validate == 0)
            {
                //return N("Username or Password is Incorrect");
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid Username or Password", Configuration.Formatters.JsonFormatter);
            }
            else
            {

                AuthenticationModule authentication = new AuthenticationModule();
                string token = authentication.GenerateTokenForUser(admin.Admin_username, admin.Admin_id);
            //string token = authentication.GenerateTokenForUser(model.sername, admin.Admin_id);
            return Request.CreateResponse(HttpStatusCode.OK, token, Configuration.Formatters.JsonFormatter);
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

        //// PUT: api/Admin/5
        //public IHttpActionResult Put(int id, [FromBody]Admin admin)
        //{
        //    int response = adminobj.AdminUpdate(admin);

        //    if (response == 1)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
            adminobj.AdminDelete(id);
        }
    }
}
