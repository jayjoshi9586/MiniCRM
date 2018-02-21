using BusinessLogicCore.Implementation;
using DataAccessCore.Entities;
using DataAccessCore.Models;
using MiniCRM.API.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiniCRM.API.Controllers
{
    [JWTAuthenticationFilter]
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        private CategoryLog _categoryLog = new CategoryLog();
        private MiniCRMModel applicationDbContext = new MiniCRMModel();

        [JWTAuthenticationFilter]
        public IEnumerable<CategoryResponseModel> Get()
        {
            return _categoryLog.CategoryGet();
        }

        [JWTAuthenticationFilter]
        [Route("GetBycategoryName")]

        public CategoryResponseModel GetbyCategoryName(String Categoryname)
        {
            return _categoryLog.GetByCategoryname(Categoryname);
        }

        [JWTAuthenticationFilter]
        // GET: api/Beacon/5
        public CategoryResponseModel Get(int id)
        {
            return _categoryLog.CategoryGet(id);
        }

        [JWTAuthenticationFilter]
        [Route("AddCategory")]
        public IHttpActionResult AddCategory(CategoryResponseModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Category category = new Category(model);
            //Beacon beacon = new Beacon()
            //{
            //    Beacon_id = model.Beacon_id,
            //    Beacon_major = model.Beacon_major,
            //    Beacon_minor = model.Beacon_minor,
            //    Beacon_message = model.Beacon_message,
            //    Beacon_rssi = model.Beacon_rssi,
            //    Beacon_title = model.Beacon_title,
            //    Beacon_trigger_interval = model.Beacon_trigger_interval,
            //    Beacon_trigger_proximity = model.Beacon_trigger_proximity,
            //    Beacon_uuid = model.Beacon_uuid,
            //    IsDeleted = false
            //};

            int response = _categoryLog.CategoryInsert(category);

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

        [JWTAuthenticationFilter]
        [Route("EditCategory")]
        public IHttpActionResult EditcategoryName(CategoryModel model)
        {
            Category beacon = new Category(_categoryLog.CategoryGet(model.Category_id));

            if (beacon == null)
            {
                return BadRequest("Invalid Category! Please enter correct CategoryID");
            }

            int result = _categoryLog.CategoryUpdate(model);

            if (result == 1)
            {
                return Ok("Changes Saved Successfully!");
            }

            return InternalServerError();

        }
    }
}
