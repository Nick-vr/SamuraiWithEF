using IntroToEF.Data.Entities;
using System.Collections.Generic;

namespace IntroToEF.Data.Repositories
{
    internal interface IQuoteRepo
    {
        void AddQuote(string text, int samuraiId);

        void AddQuotes(List<Quote> quotes);

        void DeleteQuote(int id);

        Quote GetQuote(int id);

        List<Quote> GetQuotes();

        void UpdateQuote(int id, Quote quote);
    }
}