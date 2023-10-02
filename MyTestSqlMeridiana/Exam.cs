namespace MyTestSqlMeridiana
{
	public class Exam
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public int LessonId { get; set; }
		public DateTime Date { get; set; }
		public int Score { get; set; }

		public virtual Student Student { get; set; }
		public virtual Lesson Lesson { get; set; }
	}
}
