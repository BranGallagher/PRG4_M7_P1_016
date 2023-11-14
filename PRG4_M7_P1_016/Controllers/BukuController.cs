
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PRG4_M7_P1_016.Data;
using PRG4_M7_P1_016.Models;


namespace PRG4_M7_P1_016.Controllers
{
    [ApiController]
    [Route("controller")]

    public class BukuController : ControllerBase
    {
        private readonly OurDbContext _context;
        ResponModel response = new ResponModel();
        
            public BukuController(IConfiguration configuration)
            {
                _context = new OurDbContext(configuration);
            }

        [HttpGet("/GetAllBuku", Name = "GetAllBuku")]
        public IActionResult GetAllBuku()
        {
                try
                {
               
                response.status = 200;
                    response.Messages = "Success";
                    response.data = _context.GetAllData();
                }
                catch (Exception ex)
                {
                response.status = 500;
                response.Messages = ex.Message;
               
                }
            return Ok(response);
        }


        [HttpGet("/GetBuku", Name = "GetBuku")]
        
public IActionResult GetBuku(int id)
        {
            try
            {
                response.status = 200;
                response.Messages= "Success";
                response.data = _context.GetData(id);
            }

            catch (Exception ex)
            {
                response.status = 500;
                response.Messages = ex.Message;
               
            }
            return Ok(response);
        }
        [HttpPost("/InsertBuku", Name = "InsertBuku")]
        public IActionResult InsertBuku([FromBody] Buku buku)
        {
            try
            {
                response.status = 200;
                response.Messages = "Success";
                _context.insertDataBuku(buku);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.Messages = ex.Message;
            }
            return Ok(response);
        }

        //UpdateBuku
        [HttpPost("/UpdateBuku", Name = "UpdateBuku")]
        public IActionResult UpdateBuku([FromBody] Buku buku)
        {
            try
            {
                response.status = 200;
                response.Messages = "Success";
                _context.updateDataBuku(buku);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.Messages = ex.Message;
            }
            return Ok(response);
        }

        //DeleteBuku
        [HttpPost("/DeleteBuku", Name = "DeleteBuku")]
        public IActionResult DeleteBuku(int id)
        {
            try
            {
                response.status = 200;
                response.Messages = "Success";
                _context.deleteDataBuku(id);
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

