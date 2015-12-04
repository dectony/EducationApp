using System;
using EducationApp.DataAccess.Entities;

namespace EducationApp.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private bool _disposed;
        private Context _context = new Context();

        private GenericRepository<Theme> _themeRepository;
        private GenericRepository<Quiz> _quizRepository;
        private GenericRepository<QuizQuestion> _questionsRepository;
        private GenericRepository<QuizAnswer> _answersRepository;

        public GenericRepository<Theme> ThemeRepository
        {
            get { return _themeRepository ?? (_themeRepository = new GenericRepository<Theme>(_context)); }
        }

        public GenericRepository<Quiz> QuizRepository
        {
            get { return _quizRepository ?? (_quizRepository = new GenericRepository<Quiz>(_context)); }
        }

        public GenericRepository<QuizQuestion> QuestionsRepository
        {
            get {
                return _questionsRepository ?? (_questionsRepository = new GenericRepository<QuizQuestion>(_context));
            }
        }

        public GenericRepository<QuizAnswer> AnswersRepository
        {
            get { return _answersRepository ?? (_answersRepository = new GenericRepository<QuizAnswer>(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
