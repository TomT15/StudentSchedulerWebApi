namespace StudentSchedulerWebApi.Model
{
    public class GroupSchedule
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<string>? Students { get; set; }

        public List<Student>? Students2 { get; set; }


        public GroupSchedule(int id, string name, List<string> students)
        {
            Id = id;
            Name = name;
            Students = students;
        }

        public GroupSchedule(int id, string name, List<Student> students)
        {
            Id = id;
            Name = name;
            Students2 = students;
        }
    }
}
