using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccess.Entities
{
    public class QuizQuestion
    {
        public int QuizQuestionId { get; set; }
        public string QuestionDescriptor { get; set; }
        public int RightAnswerNumber { get; set; }

        public virtual List<QuizAnswer> Answers { get; set; }
    }
}
