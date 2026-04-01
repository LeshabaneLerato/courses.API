using CourseApi.Models;
using CourseApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CourseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly CourseRepository _repository;

        public CoursesController(CourseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Course>> GetAll() => _repository.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Course> GetById(int id)
        {
            var course = _repository.GetById(id);
            if (course == null) return NotFound();
            return course;
        }

        [HttpPost]
        public ActionResult<Course> Create(Course course)
        {
            var created = _repository.Add(course);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Course course)
        {
            if (id != course.Id) return BadRequest();
            var existing = _repository.GetById(id);
            if (existing == null) return NotFound();
            _repository.Update(course);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null) return NotFound();
            _repository.Delete(id);
            return NoContent();
        }
    }
}