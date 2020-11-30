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
                new BookModel(){ Id=1,Title="MVC",Author="AKSB",Description="This is the description of MVC book."},
                new BookModel(){Id=2,Title="C#",Author="John" ,Description="This is the description of C# book."},
                new BookModel(){Id=3,Title="Java",Author="Mayer" ,Description="This is the description of Java book."},
                new BookModel(){Id=4,Title="PHP",Author="Laracast" ,Description="This is the description of PHP book."},
                new BookModel(){Id=5,Title="Dot Net Core",Author="PluralSight" ,Description="This is the description of Dot Net Core book."}
            };
        }
    }
}
