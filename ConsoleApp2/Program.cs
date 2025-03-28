using ConsoleApp2;
using ConsoleApp2.DAL;
using ConsoleApp2.Entities;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new StudentRepository();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Show all students");
                Console.WriteLine("3. Update student");
                Console.WriteLine("4. Delete student");
                Console.WriteLine("5. View student by ID");
                Console.WriteLine("6. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(repository);
                        break;
                    case "2":
                        ShowAllStudents(repository);
                        break;
                    case "3":
                        UpdateStudent(repository);
                        break;
                    case "4":
                        DeleteStudent(repository);
                        break;
                    case "5":
                        ViewStudentById(repository);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Incorrect input!");
                        break;
                }

                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
                Console.WriteLine();
            }
        }

        static void AddStudent(StudentRepository repository)
        {
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Date of Birth (yyyy-mm-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Email: ");
            string email = Console.ReadLine();

            var student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Email = email
            };

            repository.Add(student);
            Console.WriteLine("Student added successfully!");
        }

        static void ShowAllStudents(StudentRepository repository)
        {
            var students = repository.GetAll();
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.FirstName} {student.LastName}, Date of Birth: {student.DateOfBirth.ToShortDateString()}, Email: {student.Email}");
            }
        }

        static void UpdateStudent(StudentRepository repository)
        {
            Console.Write("Enter student ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var student = repository.GetById(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("First Name: ");
            student.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            student.LastName = Console.ReadLine();
            Console.Write("Date of Birth (yyyy-mm-dd): ");
            student.DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Email: ");
            student.Email = Console.ReadLine();

            repository.Update(student);
            Console.WriteLine("Student updated successfully!");
        }

        static void DeleteStudent(StudentRepository repository)
        {
            Console.Write("Enter student ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            repository.Delete(id);
            Console.WriteLine("Student deleted successfully!");
        }

        static void ViewStudentById(StudentRepository repository)
        {
            Console.Write("Enter student ID to view: ");
            int id = int.Parse(Console.ReadLine());
            var student = repository.GetById(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine($"ID: {student.Id}, Name: {student.FirstName} {student.LastName}, Date of Birth: {student.DateOfBirth.ToShortDateString()}, Email: {student.Email}");
        }
    }
}

