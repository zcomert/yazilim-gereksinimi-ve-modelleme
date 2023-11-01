namespace StudentApp.Models
{
    public class StudentRepository
    {
        public List<Student> StudentList { get; set; }
        public StudentRepository()
        {
            StudentList = new List<Student>();
            StudentList.Add(new Student() { Number = 10, FirstName = "Ahmet", LastName = "Güneş" });
            StudentList.Add(new Student() { Number = 20, FirstName = "Hafza", LastName = "Yıldız" });
            StudentList.Add(new Student() { Number = 30, FirstName = "Nuri", LastName = "Irmak" });
        }

        // CRUD
        public Student GetOneStudent(int id)
        {
            /*
            foreach (var std in StudentList)
            {
                if (std.Number.Equals(id))
                {
                    return std;
                }
            }
            throw new Exception("Not found!");*/
            var result = StudentList
            .Where(std => std.Number.Equals(id))
            .SingleOrDefault();
            return result;
        }

        public List<Student> GetAllStudent()
        {
            return StudentList;
        }

        public Student CreateOneStudent(Student student)
        {
            var result = StudentList
            .Where(std => std.Number.Equals(student.Number))
            .SingleOrDefault();
            if (result != null)
                return null;
            StudentList.Add(student);
            return student;
        }

        public void UpdateOneStudent(int id, Student student)
        {
            foreach (var item in StudentList)
            {
                if (item.Number == id)
                {
                    item.FirstName = student.FirstName;
                    item.LastName = student.LastName;
                    item.Number = student.Number;
                    return;
                }
            }
            throw new Exception("Not found");
        }

        public void DeleteOneStudent(int id)
        {
            var std = GetOneStudent(id);
            StudentList.Remove(std);
        }
    }
}