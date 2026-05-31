namespace GoMath.Models
{
    public static class StudentStore
    {
        private static List<Student> _students = new List<Student>
        {
            new Student { Id = 1, StudentCode = "HS001", FullName = "Nguyễn Văn An", DateOfBirth = new DateTime(2007, 3, 15), ClassName = "10A1", AverageScore = 8.5 },
            new Student { Id = 2, StudentCode = "HS002", FullName = "Trần Thị Bình", DateOfBirth = new DateTime(2007, 7, 22), ClassName = "10A1", AverageScore = 7.2 },
            new Student { Id = 3, StudentCode = "HS003", FullName = "Lê Minh Châu", DateOfBirth = new DateTime(2006, 11, 8), ClassName = "11B2", AverageScore = 9.1 },
            new Student { Id = 4, StudentCode = "HS004", FullName = "Phạm Thu Dung", DateOfBirth = new DateTime(2006, 5, 30), ClassName = "11B2", AverageScore = 6.0 },
            new Student { Id = 5, StudentCode = "HS005", FullName = "Hoàng Quốc Hùng", DateOfBirth = new DateTime(2005, 1, 14), ClassName = "12C3", AverageScore = 4.8 },
        };
        private static int _nextId = 6;

        public static List<Student> GetAll() => _students.ToList();

        public static Student? GetById(int id) => _students.FirstOrDefault(s => s.Id == id);

        public static void Add(Student student)
        {
            student.Id = _nextId++;
            _students.Add(student);
        }

        public static bool Update(Student student)
        {
            var existing = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existing == null) return false;
            existing.StudentCode = student.StudentCode;
            existing.FullName = student.FullName;
            existing.DateOfBirth = student.DateOfBirth;
            existing.ClassName = student.ClassName;
            existing.AverageScore = student.AverageScore;
            return true;
        }

        public static bool Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null) return false;
            _students.Remove(student);
            return true;
        }

        public static List<Student> Search(string? name, string? className)
        {
            var query = _students.AsQueryable();
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(s => s.FullName.Contains(name, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(className))
                query = query.Where(s => s.ClassName.Equals(className, StringComparison.OrdinalIgnoreCase));
            return query.ToList();
        }

        public static List<string> GetAllClasses() => _students.Select(s => s.ClassName).Distinct().OrderBy(c => c).ToList();
    }
}
