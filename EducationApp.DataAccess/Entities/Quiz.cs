using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccess.Entities
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string QuizName { get; set; }

        public virtual List<QuizQuestion> Questions { get; set; }
        public virtual Theme Theme { get; set; }
    }
}
