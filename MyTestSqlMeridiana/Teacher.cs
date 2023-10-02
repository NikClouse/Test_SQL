namespace MyTestSqlMeridiana
{
	public class Teacher
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }

		public virtual ICollection<Student> Students { get; set; }
	}
}
