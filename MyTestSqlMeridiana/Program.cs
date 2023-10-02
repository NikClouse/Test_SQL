namespace MyTestSqlMeridiana
{
	public class Program
	{
		static void Main(string[] args)
		{
			using (var db = new DatabaseContext())
			{
				//Учител
				var teacher1 = new Teacher { Name = "Андрей", Age = 35 };
				var teacher2 = new Teacher { Name = "Виктория", Age = 45 };
				var teacher3 = new Teacher { Name = "Алиса", Age = 25 };

				db.Teachers.Add(teacher1);
				db.Teachers.Add(teacher2);
				db.Teachers.Add(teacher3);
				db.SaveChanges();

				//Студент
				var student1 = new Student { Name = "Максим", TeacherId = 1 };
				var student2 = new Student { Name = "Елена", TeacherId = 2 };
				var student3 = new Student { Name = "Мурад", TeacherId = 3 };

				db.Students.Add(student1);
				db.Students.Add(student2);
				db.Students.Add(student3);
				db.SaveChanges();

				//Урок
				var lesson = new Lesson { Name = "Матиматика" };
				db.Lessons.Add(lesson);
				db.SaveChanges();

				//Экзам
				var exam1 = new Exam { StudentId = 1, LessonId = lesson.Id, Date = new DateTime(2021, 1, 01), Score = 85 };
				var exam2 = new Exam { StudentId = 1, LessonId = lesson.Id, Date = new DateTime(2022, 1, 01), Score = 90 };
				var exam3 = new Exam { StudentId = 1, LessonId = lesson.Id, Date = new DateTime(2023, 1, 01), Score = 95, };

				db.Exams.Add(exam1);
				db.Exams.Add(exam2);
				db.Exams.Add(exam3);
				db.SaveChanges();

				using (var context = new DatabaseContext())
				{
					var teachersWithStudentCount = context.Teachers
					.Select(t => new
					{
						Teacher = t,
						StudentCount = t.Students.Count
					})
					.OrderBy(t => t.StudentCount)
					.ToList();

					foreach (var item in teachersWithStudentCount)
					{
						Console.WriteLine($"Учитель: {item.Teacher.Name}, Количество учеников: {item.StudentCount}");
					}
				}

				//###################################################
				Console.WriteLine();

				using (var context = new DatabaseContext())
				{
					// Получение ученика с максимальным баллом по Математике за указанный период
					var studentWithMaxScore = context.Students
						.Join(context.Exams.Where(e => e.Date >= new DateTime(2021, 01, 01) && e.Date <= new DateTime(2022, 01, 01) && e.LessonId == 1),
							student => student.Id,
							exam => exam.StudentId,
							(student, exam) => new { Student = student, Exam = exam })
						.Join(context.Teachers.Where(t => t.Age <= 40),
							studentExam => studentExam.Student.TeacherId,
							teacher => teacher.Id,
							(studentExam, teacher) => new { StudentExam = studentExam, Teacher = teacher })
						.OrderByDescending(se => se.StudentExam.Exam.Score)
						.Select(se => se.StudentExam.Student)
						.FirstOrDefault();

					// Вывод результатов
					Console.WriteLine("Самый успешный ученик по Математике с 01.01.2021 по 01.01.2022, не брать учителей, у которых возраст старше 40:");
					Console.WriteLine("ID: " + studentWithMaxScore.Id);
					Console.WriteLine("Имя: " + studentWithMaxScore.Name);
				}



				Console.ReadLine();
			}
		}
	}









}
