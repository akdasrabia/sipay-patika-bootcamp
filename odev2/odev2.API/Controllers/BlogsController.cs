using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using odev2.Core.Models;
using odev2.Core.Services;

namespace odev2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IService<Blog> _service;

        public BlogsController(IService<Blog> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var blogs = await _service.GetAllAsync();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _service.GetByIdAsync(id);
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Blog blog)
        {
            var blogResponse = await _service.AddAsync(blog);
            return Ok(blogResponse);
        }

        [HttpPut]
        public IActionResult Update(Blog blog)
        {
            _service.UpdateAsync(blog);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var blog = await _service.GetByIdAsync(id);
            _service.RemoveAsync(blog);
            return Ok(blog);
        }

    }
}
