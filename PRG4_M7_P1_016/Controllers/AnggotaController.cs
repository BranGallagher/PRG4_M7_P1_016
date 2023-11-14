using Microsoft.AspNetCore.Mvc;
using PRG4_M7_P1_016.Data;
using PRG4_M7_P1_016.Models;
using Microsoft.Extensions.Configuration;

namespace PRG4_M7_P1_016.Controllers
{
    [ApiController]
    [Route("controller")]
    public class AnggotaController : Controller
    {
        private readonly OurDbContext _Context;
        ResponModel response = new ResponModel();

        public AnggotaController(IConfiguration configuration)
        {
            _Context = new OurDbContext(configuration);
        }

        [HttpGet("/GetAllAnggota", Name = "GetAllAnggota")]
        public IActionResult GetAllAnggota()
        {
            try
            {
                response.status = 200;
                response.Messages = "Success";
                response.data = _Context.getAllDataAnggota();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.Messages = ex.Message;
            }
            return Ok(response);
        }

        //DetailData
        [HttpGet("/GetAnggota", Name = "GetAnggota")]
        public IActionResult GetAnggota(int id)
        {
            try
            {
                response.status = 200;
                response.Messages = "Success";
                response.data = _Context.getDataAnggota(id);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.Messages = ex.Message;
            }
            return Ok(response);
        }

        //TambahData
        [HttpPost("/InsertAnggota", Name = "InsertAnggota")]
        public IActionResult InsertAnggota([FromBody] Anggota anggota)
        {
            try
            {
                response.status = 200;
                response.Messages = "Success";
                _Context.insertDataAnggota(anggota);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.Messages = ex.Message;
            }
            return Ok(response);
        }

        //UpdateBuku
        [HttpPost("/UpdateAnggota", Name = "UpdateAnggota")]
        public IActionResult UpdateAnggota([FromBody] Anggota anggota)
        {
            try
            {
                response.status = 200;
                response.Messages = "Success";
                _Context.updateDataAnggota(anggota);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.Messages = ex.Message;
            }
            return Ok(response);
        }

        //DeleteBuku
        [HttpPost("/DeleteAnggota", Name = "DeleteAnggota")]
        public IActionResult DeleteAnggota(int id)
        {
            try
            {
                response.status = 200;
                response.Messages = "Success";
                _Context.deleteDataAnggota(id);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.Messages = ex.Message;
            }
            return Ok(response);
        }
    }
}
