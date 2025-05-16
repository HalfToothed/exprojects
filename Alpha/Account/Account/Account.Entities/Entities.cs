namespace Account.Api.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Standard { get; set; }
        public string School { get; set; }
    }

    public class Database
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }
}
