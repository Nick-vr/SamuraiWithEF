using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToEF.Data.Repositories
{
    internal class QuoteRepo
    {
        private SamuraiContext _context;

        public QuoteRepo()
        {
            // Open connection to DB
            _context = new SamuraiContext();
        }

        public void AddQuote(string text, int samuraiId)
        {
        }
    }
}