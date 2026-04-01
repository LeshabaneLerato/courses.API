using CourseApi.Models;

namespace CourseApi.Repositories
{
    public class CourseRepository
    {
        private readonly List<Course> _courses = new();
        private int _nextId = 1;

        public List<Course> GetAll() => _courses;

        public Course? GetById(int id) => _courses.FirstOrDefault(c => c.Id == id);

        public Course Add(Course course)
        {
            course.Id = _nextId++;
            _courses.Add(course);
            return course;
        }

        public void Update(Course course)
        {
            var index = _courses.FindIndex(c => c.Id == course.Id);
            if (index != -1)
            {
                _courses[index] = course;
            }
        }

        public void Delete(int id)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);
            if (course != null)
                _courses.Remove(course);
        }
    }
}