namespace StudentSchedulerWebApi.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, DateTime> Restraints { get; set; }
        public DateTime Created { get; set; }

        public Student(int id, string name, Dictionary<string, DateTime> restraints)
        {
            Id = id;
            Name = name;
            Restraints = restraints;
            Created = DateTime.Now;
        }
    }
}
