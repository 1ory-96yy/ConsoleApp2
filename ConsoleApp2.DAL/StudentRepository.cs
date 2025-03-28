using ConsoleApp2.DAL;
using ConsoleApp2.Entities;

namespace ConsoleApp2.DAL
{
    public class StudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository()
        {
            _context = new AppDbContext();
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }
    }
}