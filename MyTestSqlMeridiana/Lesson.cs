namespace MyTestSqlMeridiana
{
	public class Lesson
	{
		public int Id { get; set; }
		public string Name { get; set; }


		public virtual ICollection<Exam> Exams { get; set; }
	}
}
