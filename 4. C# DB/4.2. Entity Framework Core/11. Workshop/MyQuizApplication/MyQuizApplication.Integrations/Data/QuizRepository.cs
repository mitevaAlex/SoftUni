using MyQuizApplication.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyQuizApplication.Infrastructure.Data
{
    public class QuizRepository : Repository, IQuizRepository
    {
        public QuizRepository(QuizContext context)
        {
            this.Context = context;
        }
    }
}
