using System.Runtime.Intrinsics.Arm;
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
                cmd.CommandText = "SELECT * FROM asset.table_department ORDER BY id DESC  ";
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
                   StatusCodes.Status500InternalServerError, new { message = "ProductController Error : " + ex.Message });
            }


        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(DepartmentModel departmentModel)
        {
            try
            {
                using NpgsqlConnection conn = new SqlConnect().GetConnection();
                using NpgsqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO asset.table_department(departmentname , shortname) VALUES (@departmentname,@shortname)";
                cmd.Parameters.AddWithValue("departmentname", departmentModel.Departmentname!);
                cmd.Parameters.AddWithValue("shortname", departmentModel.Shortname!);

                if (cmd.ExecuteNonQuery() != 0)
                {
                    return Ok(new { message = "Create Success" });
                }
                return StatusCode(StatusCodes.Status501NotImplemented);
            }
            catch (Exception ex)
            {
                return StatusCode(
                   StatusCodes.Status500InternalServerError, new { message = "ProductController Error : " + ex.Message });
            }

        }



        [HttpPut]
        [Route("[action]")]

        public IActionResult Update(DepartmentModel departmentModel)
        {
            try
            {
                using NpgsqlConnection conn = new SqlConnect().GetConnection();
                using NpgsqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE asset.table_department SET departmentname = @departmentname , shortname = @shortname WHERE id = @id ";
                cmd.Parameters.AddWithValue("id", departmentModel.Id);
                cmd.Parameters.AddWithValue("departmentname", departmentModel.Departmentname!);
                cmd.Parameters.AddWithValue("shortname", departmentModel.Shortname!);

                if (cmd.ExecuteNonQuery() != 0)
                {
                    return Ok(new { message = "Update Success" });
                }
                return StatusCode(StatusCodes.Status501NotImplemented);
            }
            catch (Exception ex)
            {
                return StatusCode(
                   StatusCodes.Status500InternalServerError, new { message = "ProductController Error : " + ex.Message });
            }
        }

        [HttpDelete]
        [Route("[action]/{id}")]

        public IActionResult Delete(int id)
        {
            try
            {

                using NpgsqlConnection conn = new SqlConnect().GetConnection();
                using NpgsqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM asset.table_department WHERE id = @id";
                cmd.Parameters.AddWithValue("id", id);

                if (cmd.ExecuteNonQuery() != 0)
                {
                    return Ok(new { message = "Delete Success" });
                }
                return StatusCode(StatusCodes.Status501NotImplemented);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "ProductController Error : " + ex.Message });
            }
        }
    }
}





