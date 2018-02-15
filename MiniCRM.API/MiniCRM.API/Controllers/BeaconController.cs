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
namespace MiniCRM.API.Controllers
{
    [JWTAuthenticationFilter]
    [RoutePrefix("api/Beacon")]
    public class BeaconController : ApiController
    {
        private BeaconLog _beaconLog = new BeaconLog();
        private MiniCRMModel applicationDbContext = new MiniCRMModel();
        // GET: api/Beacon
        public IEnumerable<Beacon> Get()
        {
            return _beaconLog.BeaconGet();
        }

        [JWTAuthenticationFilter]
        [Route("GetByUsername")]
        public Beacon GetbyBeaconName(UsernameSpecificBindingModel model)
        {
            return _beaconLog.GetByBeaconname(model.Username);
        }

        [JWTAuthenticationFilter]
        [Route("ActivateUser")]
        public IHttpActionResult ActivateUser(UsernameSpecificBindingModel model)
        {
            int response = _beaconLog.ActivateBeacon(model.Username);
            if (response == 1)
            {
                return Ok("User Activated");
            }

            return BadRequest("Could not activate the user. Please try again.");
        }

        [JWTAuthenticationFilter]
        [Route("DeActivateBeacon")]
        public IHttpActionResult DeActivateUser(UsernameSpecificBindingModel model)
        {
            int response = _beaconLog.DeActivateBeacon(model.Username);
            if (response == 1)
            {
                return Ok("User Activated");
            }

            return BadRequest("Could not activate the user. Please try again.");
        }
        // GET: api/Beacon/5
        public Beacon Get(int id)
        {
            return _beaconLog.BeaconGet(id);
        }

        // POST: api/Beacon
        [JWTAuthenticationFilter]
        [Route("AddBeacon")]
        public IHttpActionResult AddBeacon(AddBeaconBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Beacon beacon = new Beacon()
            {
                Beacon_id =model.Beacon_id,
                Beacon_major = model.Beacon_major,
                Beacon_minor =model.Beacon_minor,
                Beacon_message =model.Beacon_message,
                Beacon_rssi =model.Beacon_rssi,
                Beacon_title =model.Beacon_title,
                Beacon_trigger_interval =model.Beacon_trigger_interval,
                Beacon_trigger_proximity =model.Beacon_trigger_proximity,
                Beacon_uuid =model.Beacon_uuid,
                IsDeleted = false
            };

            int response = _beaconLog.BeaconInsert(beacon);

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

        // PUT: api/Beacon/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Beacon/5
        public void Delete(int id)
        {
        }
    }
}
