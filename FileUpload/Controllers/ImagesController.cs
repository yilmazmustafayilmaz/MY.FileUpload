using FileUpload.API.DataAccess.Abstract;
using FileUpload.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageUploadDal _upload;

        public ImagesController(IImageUploadDal upload)
        {
            _upload = upload;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _upload.GetAll();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _upload.Get(my => my.Id == id);
            return Ok(result);
        }

        [HttpPost("upload")]
        public IActionResult Upload([FromForm] ImageUpload imageUpload)
        {
            _upload.Add(imageUpload);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _upload.Delete(id);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm] ImageUpload imageUpload)
        {
            _upload.Update(imageUpload);
            return Ok();
        }
    }
}
