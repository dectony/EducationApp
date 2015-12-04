using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccess.Entities
{
    public class QuizAnswer
    {
        public int QuizAnswerId { get; set; }
        public string Answer { get; set; }

        public virtual QuizQuestion Question { get; set; }
    }
}
