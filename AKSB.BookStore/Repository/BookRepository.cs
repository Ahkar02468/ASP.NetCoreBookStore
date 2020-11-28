using AKSB.BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKSB.BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title,string authorName)
        {
            return DataSource().Where(s => s.Title.Contains(title) && s.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){ Id=1,Title="MVC",Author="AKSB"},
                new BookModel(){Id=2,Title="c#",Author="John" },
                new BookModel(){Id=3,Title="Java",Author="Mayer" },
                new BookModel(){Id=4,Title="PHP",Author="Laracast" },
                new BookModel(){Id=5,Title="Dot Net Core",Author="PluralSight" }
            };
        }
    }
}
