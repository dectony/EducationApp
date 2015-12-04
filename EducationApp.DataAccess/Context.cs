using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationApp.DataAccess.Entities;

namespace EducationApp.DataAccess
{
    public class Context : DbContext
    {
        public Context() : base("EducationAppDatabase")
        {

        }

        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<QuizAnswer> QuizAnswers { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<QuizQuestion> QuizQustions { get; set; }
    }
}
