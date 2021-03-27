using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroToEF.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntroToEF.Data.Repositories
{
    internal class QuoteRepo : IQuoteRepo
    {
        private SamuraiContext _context;

        public QuoteRepo()
        {
            // Open connection to DB
            _context = new SamuraiContext();
        }

        public void AddQuote(string text, int samuraiId)
        {
            var quote = new Quote()
            {
                Text = text,
                SamuraiId = samuraiId,
            };

            _context.Quotes.Add(quote);
            _context.SaveChanges();
        }

        public void AddQuotes(List<Quote> quotes)
        {
            // var quoteList = quotes.Split(';').ToList();
            //var newQuoteList = new List<Quote>(quoteList);

            //var quoteList = new List<Quote>()
            //{
            //    new() { Text = "Random quote 1", SamuraiId = samuraiId},
            //    new() { Text = "Random quote 2", SamuraiId = samuraiId},
            //};

            _context.Quotes.AddRange(quotes);
            _context.SaveChanges();
        }

        public Quote GetQuote(int id)
        {
            throw new NotImplementedException();
        }

        public List<Quote> GetQuotes()
        {
            return _context.Quotes.Include(x => x.Samurai).ToList();
        }

        public void UpdateQuote(int id, Quote quote)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuote(int id)
        {
            throw new NotImplementedException();
        }
    }
}