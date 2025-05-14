using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Linq.Expressions;

namespace Asset_api
{
    [ApiController]
    [Route("api/[contrller]")]
    public class ProductController : ControllerBase
    {



        [HttpGet]
        [Route("action")]
        public IActionResult List()
        {

            try { 
            
                using NpgsqlConnection conn = new NpgsqlConnection();
                using NpgsqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FORM table_department ORDER BY id DESC";
                using NpgsqlDataReader reader = cmd.ExecuteReader();
                List<DepartmentModels>
            }
            catch (Exception ex) 
            {
                return StatusCode
                        (StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }

            return Ok();
        }

        [HttpPost]
        [Route("action")]
        public IActionResult Create()
        {

            try { }
            catch (Exception ex)
            {
                return StatusCode(
                   StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
            return Ok();
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public IActionResult Update(int id)
        {
            return Ok(new { message = "id is " + id });
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult Remove(int id)
        {
            return Ok(new { message = "id = " + id });
        }

    }
}
