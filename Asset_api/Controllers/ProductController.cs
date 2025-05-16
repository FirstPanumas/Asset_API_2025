using Asset_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Asset_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        public IActionResult List()
        {

            try
            {

                using NpgsqlConnection conn = new SqlConnect().GetConnection();
                using NpgsqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM table_department ORDER BY DESC ";
                using NpgsqlDataReader reader = cmd.ExecuteReader();
                List<DepartmentModel> list = new List<DepartmentModel>();
                while (reader.Read())
                {
                    list.Add(
                        new DepartmentModel
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Departmentname = reader["departmentname"].ToString(),
                            Shortname = reader["shortname"].ToString()
                        });
                }
                return Ok(list);


            }

            catch (Exception ex)
            {
                return StatusCode(
                   StatusCodes.Status500InternalServerError, new {  message = "ProductController Error : "+ ex.Message });
            }


        }
    }
}




