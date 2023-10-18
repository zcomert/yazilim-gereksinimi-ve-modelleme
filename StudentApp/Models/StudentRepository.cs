namespace StudentApp.Models
{
    public static class StudentRepository
    {
        public static List<Student> StudentList { get; set; }
        static StudentRepository()
        {
            StudentList = new List<Student>();
            StudentList.Add(new Student(){Number=10, FirstName="Ahmet", LastName="Güneş"});
            StudentList.Add(new Student(){Number=20, FirstName="Hafza", LastName="Yıldız"});
            StudentList.Add(new Student(){Number=30, FirstName="Nuri", LastName="Irmak"});
        }

        public static Student GetOne(int id)
        {
            foreach (var std in StudentList)
            {
                if(std.Number.Equals(id))
                {
                    return std;
                }
            }
            throw new Exception("Not found!");
        }

        public static void DeleteOne(int id)
        {
            var std = GetOne(id);
            StudentList.Remove(std);
        }

        public static Student CreateOne(Student student)
        {
            StudentList.Add(student);
            return student;
        }

        public static void UpdateOne(int id, Student student)
        {
            foreach (var item in StudentList)
            {
                if(item.Number == id)
                {
                    item.FirstName = student.FirstName;
                    item.LastName = student.LastName;
                    item.Number = student.Number;
                    return;
                }
            }
            throw new Exception("Not found");
        }
    }
}