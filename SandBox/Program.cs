using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationApp.DataAccess;
using EducationApp.DataAccess.Entities;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Context())
            {
                var test = new Theme();
                test.ContentFilePath = "TestPath";
                test.ThemeName = "TestName";
                test.Quizes = new List<Quiz>();
                test.Quizes.Add(new Quiz
                {
                    QuizName = "TestQuiz",
                    Questions = new List<QuizQuestion>
                    {
                        new QuizQuestion
                        {
                            QuestionDescriptor = "Yes or No?",
                            RightAnswerNumber = 1,
                            Answers = new List<QuizAnswer>
                            {
                                new QuizAnswer
                                {
                                   Answer = "Yes"
                                },
                                new QuizAnswer
                                {
                                   Answer = "No"
                                },
                            }
                        }
                    }
                   
                });
                db.Themes.Add(test);
                db.SaveChanges();
            }
        }
    }
}
