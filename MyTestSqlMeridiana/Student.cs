namespace MyTestSqlMeridiana
{
	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int TeacherId { get; set; }

		public virtual Teacher Teacher { get; set; }
		public virtual ICollection<Exam> Exams { get; set; }
	}
}
